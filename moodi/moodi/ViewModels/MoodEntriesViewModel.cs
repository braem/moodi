using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using moodi.Models;
using moodi.Views;

namespace moodi.ViewModels
{
    class MoodEntriesViewModel : BaseViewModel
    {
        private MoodEntry _selectedEntry;
        public MoodEntry SelectedMoodEntry
        {
            get => _selectedEntry;
            set
            {
                SetProperty(ref _selectedEntry, value);
                _ = OnMoodEntrySelected(value);
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ObservableCollection<MoodEntry> MoodEntries { get; }
        public Command LoadMoodEntriesCommand{ get; }
        public Command AddMoodEntryCommand { get; }
        public Command<MoodEntry> MoodEntryTapped { get; }
        public Command<MoodEntry> MoodEntryDeleted { get; }
        public Command SettingsTapped { get; }

        public MoodEntriesViewModel()
        {
            Title = "Moods";
            MoodEntries = new ObservableCollection<MoodEntry>();
            
            LoadMoodEntriesCommand = new Command(async () => await ExecuteLoadMoodEntriesCommand());
            AddMoodEntryCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(NewMoodEntryPage)));

            MoodEntryTapped = new Command<MoodEntry>(async (MoodEntry entry) => await OnMoodEntrySelected(entry));
            MoodEntryDeleted = new Command<MoodEntry>(async (MoodEntry entry) => await DeleteMoodEntry(entry));

            SettingsTapped = new Command(async () => await Shell.Current.GoToAsync(nameof(SettingsPage)));
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedMoodEntry = null;
        }

        private async Task ExecuteLoadMoodEntriesCommand()
        {
            IsBusy = true;

            try
            {
                MoodEntries.Clear();
                var entries = await App.Database.GetMoodEntries();
                var tempList = entries.ToList();
                tempList.Sort((x, y) => y.Date.CompareTo(x.Date));
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

        private async Task DeleteMoodEntry(MoodEntry moodEntry)
        {
            try
            {
                await App.Database.DeleteMoodEntry(moodEntry);
                MoodEntries.Remove(moodEntry);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task OnMoodEntrySelected(MoodEntry moodEntry)
        {
            if (moodEntry == null)
                return;

            // This will push the MoodEntryDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MoodEntryDetailPage)}?{nameof(MoodEntryDetailViewModel.MoodEntryID)}={moodEntry.ID}");
        }
    }
}
