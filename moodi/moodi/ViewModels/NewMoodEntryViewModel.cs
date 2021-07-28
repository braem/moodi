using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using moodi.Models;
using moodi.Services;

namespace moodi.ViewModels
{
    class NewMoodEntryViewModel : BaseViewModel
    {
        private string _notes;
        private MoodImage _selectedMood;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command<MoodImage> MoodTapped { get; set; }

        public List<SvgCachedImage> MoodSVGImages { get; set; }

        public List<MoodImage> MoodImages { get; set; }

        public NewMoodEntryViewModel()
        {
            Title = "New Mood Entry";

            SaveCommand = new Command(OnSave, () => _selectedMood != null);
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
            MoodTapped = new Command<MoodImage>(OnMoodTapped);

            MoodSVGImages = new List<SvgCachedImage>();

            MoodImages = MoodImageStore.MoodImages;

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

        public void OnAppearing()
        {
            SelectedMood = null;
        }

        public void InitMoodImage(SvgCachedImage svgImage)
        {
            ViewModelUtils.ApplyTintTransform(svgImage);
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
                    ViewModelUtils.ApplyTintTransform(MoodSVGImages[prevMoodImgIndex]);
                }
            }

            var moodImgIndex = MoodImages.FindIndex(x => x == moodImage);
            if (moodImgIndex == -1)
                return;

            ViewModelUtils.ApplyTintTransform(MoodSVGImages[moodImgIndex], moodImage);
            SelectedMood = moodImage;
            SaveCommand.ChangeCanExecute(); // can now save mood
        }

        private async void OnSave()
        {
            MoodEntry newEntry = new MoodEntry()
            {
                Date = DateTime.Now,
                Notes = Notes == null || Notes.Length == 0 ? "<No Note>" : Notes,
                MoodImageSvgPath = SelectedMood.SvgPath,
                MoodImageSvgHexColor = SelectedMood.SvgHexColor
            };

            await App.Database.SaveMoodEntry(newEntry);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
