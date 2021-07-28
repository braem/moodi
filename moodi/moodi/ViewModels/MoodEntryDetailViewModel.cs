using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace moodi.ViewModels
{
    [QueryProperty(nameof(MoodEntryID), nameof(MoodEntryID))]
    class MoodEntryDetailViewModel : BaseMoodViewModel
    {
        private string _moodEntryID;
        private DateTime _date;
        private int _moodLevel;
        private string _notes;
        public Guid ID { get; set; }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        public int MoodLevel
        {
            get => _moodLevel;
            set => SetProperty(ref _moodLevel, value);
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
                LoadMoodEntryID(Guid.Parse(value));
            }
        }

        public async void LoadMoodEntryID(Guid moodEntryID)
        {
            try
            {
                var entry = await MoodEntryDataStore.GetItemAsync(moodEntryID);
                ID = entry.ID;
                Date = entry.Date;
                MoodLevel = entry.MoodLevel;
                Notes = entry.Notes;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Mood Entry");
            }
        }
    }
}
