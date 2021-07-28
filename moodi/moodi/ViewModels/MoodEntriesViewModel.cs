using moodi.Models;
using moodi.Views;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using System.Globalization;

namespace moodi.ViewModels
{
    class MoodEntriesViewModel : BaseMoodViewModel
    {
        private MoodEntry _selectedEntry;

        public ObservableCollection<MoodEntry> MoodEntries { get; }
        public Command LoadMoodEntriesCommand{ get; }
        public Command AddMoodEntryCommand { get; }
        public Command<MoodEntry> MoodEntryTapped { get; }

        public MoodEntriesViewModel()
        {
            Title = "Moods";
            MoodEntries = new ObservableCollection<MoodEntry>();
            
            LoadMoodEntriesCommand = new Command(async () => await ExecuteLoadMoodEntriesCommand());

            MoodEntryTapped = new Command<MoodEntry>(OnMoodEntrySelected);

            AddMoodEntryCommand = new Command(OnAddMoodEntry);
        }

        async Task ExecuteLoadMoodEntriesCommand()
        {
            IsBusy = true;

            try
            {
                MoodEntries.Clear();
                var entries = await MoodEntryDataStore.GetItemsAsync(true);
                var tempList = entries.ToList();
                tempList.Sort((x,y) => y.Date.CompareTo(x.Date));
                foreach (var entry in tempList)
                {
                    MoodEntries.Add(entry);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            SelectedMoodEntry = null;
        }

        public MoodEntry SelectedMoodEntry
        {
            get => _selectedEntry;
            set
            {
                SetProperty(ref _selectedEntry, value);
                OnMoodEntrySelected(value);
            }
        }

        private async void OnAddMoodEntry(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewMoodEntryPage));
        }

        async void OnMoodEntrySelected(MoodEntry moodEntry)
        {
            if (moodEntry == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MoodEntryDetailPage)}?{nameof(MoodEntryDetailViewModel.MoodEntryID)}={moodEntry.ID}");
        }
    }
}
