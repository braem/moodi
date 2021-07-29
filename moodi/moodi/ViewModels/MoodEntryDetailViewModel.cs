using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using moodi.Models;

namespace moodi.ViewModels
{
    [QueryProperty(nameof(MoodEntryID), nameof(MoodEntryID))]
    class MoodEntryDetailViewModel : BaseViewModel
    {
        private string _moodEntryID;
        public string MoodEntryID // needs to be a string for QueryProperty to work..
        {
            get => _moodEntryID;
            set
            {
                _moodEntryID = value;
                LoadMoodEntryID(int.Parse(value));
            }
        }

        private MoodEntry _moodEntry;
        public MoodEntry Mood
        {
            get => _moodEntry;
            set => SetProperty(ref _moodEntry, value);
        }

        public Command MoodEntryDeleted { get; }

        public MoodEntryDetailViewModel()
        {
            Title = "Mood Entry Detail";

            MoodEntryDeleted = new Command(async () => await DeleteMoodEntry());
        }

        public async void LoadMoodEntryID(int moodEntryID)
        {
            try
            {
                var entry = await App.Database.GetMoodEntry(moodEntryID);
                Mood = entry;

                Title = "Entry for " + entry.Date.ToString("MMM/d/yyyy");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Mood Entry");
            }
        }

        private async Task DeleteMoodEntry()
        {
            try
            {
                await App.Database.DeleteMoodEntry(Mood);

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
