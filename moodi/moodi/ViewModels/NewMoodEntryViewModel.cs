﻿using moodi.Models;
using moodi.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;

namespace moodi.ViewModels
{
    class NewMoodEntryViewModel : BaseMoodViewModel
    {
        private string _notes;
        private MoodImage _selectedMood;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command<MoodImage> MoodTapped { get; set; }

        public List<SvgCachedImage> MoodSVGImages { get; set; }

        public NewMoodEntryViewModel()
        {
            SaveCommand = new Command(OnSave, () => _selectedMood != null);
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
            MoodTapped = new Command<MoodImage>(OnMoodTapped);

            MoodSVGImages = new List<SvgCachedImage>();

            PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }
        private MoodImage SelectedMood
        {
            get => _selectedMood;
            set => SetProperty(ref _selectedMood, value);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            SelectedMood = null;
        }

        public void InitMoodImage(SvgCachedImage svgImage)
        {
            ApplyTintTransform(svgImage);
            MoodSVGImages.Add(svgImage);
        }

        private void OnMoodTapped(MoodImage moodImage)
        {
            if (moodImage == null)
                return;

            if (SelectedMood != null) // previously selected mood
            {
                var prevMoodImgIndex = MoodImages.FindIndex(x => x == SelectedMood);
                if (prevMoodImgIndex != -1)
                {
                    ApplyTintTransform(MoodSVGImages[prevMoodImgIndex]);
                }
            }

            var moodImgIndex = MoodImages.FindIndex(x => x == moodImage);
            if (moodImgIndex == -1)
                return;

            ApplyTintTransform(MoodSVGImages[moodImgIndex], moodImage);
            SelectedMood = moodImage;
            SaveCommand.ChangeCanExecute(); // can now save mood
        }

        private async void OnSave()
        {
            MoodEntry newEntry = new MoodEntry()
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now,
                MoodLevel = MoodImageDataStore.GetNumItems() - MoodImages.FindIndex(x => x == SelectedMood),
                MaxMoodLevel = MoodImageDataStore.GetNumItems(),
                Notes = Notes == null || Notes.Length == 0 ? "<No Note>" : Notes,
                MoodImageInfo = SelectedMood
            };

            await MoodEntryDataStore.AddItemAsync(newEntry);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
