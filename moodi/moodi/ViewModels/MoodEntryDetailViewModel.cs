using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace moodi.ViewModels
{
    [QueryProperty(nameof(MoodEntryID), nameof(MoodEntryID))]
    class MoodEntryDetailViewModel : BaseViewModel
    {
        private string _moodEntryID;
        private DateTime _date;
        private string _notes;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }
        public string MoodEntryID // needs to be a string for QueryProperty to work..
        {
            get { return _moodEntryID; }
            set
            {
                _moodEntryID = value;
                LoadMoodEntryID(int.Parse(value));
            }
        }

        public async void LoadMoodEntryID(int moodEntryID)
        {
            try
            {
                var entry = await App.Database.GetMoodEntry(moodEntryID);
                Date = entry.Date;
                Notes = entry.Notes;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Mood Entry");
            }
        }
    }
}
