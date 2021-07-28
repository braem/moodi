using System;
using System.Diagnostics;
using Xamarin.Forms;
using moodi.Models;

namespace moodi.ViewModels
{
    [QueryProperty(nameof(MoodEntryID), nameof(MoodEntryID))]
    class MoodEntryDetailViewModel : BaseViewModel
    {
        private string _moodEntryID;
        private MoodEntry _moodEntry;

        public MoodEntryDetailViewModel()
        {
            Title = "Mood Entry Detail";
        }

        public string MoodEntryID // needs to be a string for QueryProperty to work..
        {
            get => _moodEntryID;
            set
            {
                _moodEntryID = value;
                LoadMoodEntryID(int.Parse(value));
            }
        }
        public MoodEntry Mood
        {
            get => _moodEntry;
            set => SetProperty(ref _moodEntry, value);
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
    }
}
