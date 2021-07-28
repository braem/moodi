using moodi.Models;
using System;

namespace moodi.Services
{
    class MoodEntriesDataStore : BaseDataStore<MoodEntry>
    {
        public MoodEntriesDataStore()
        {
            //Items.Add(new MoodEntry { ID = Guid.NewGuid(), Date = DateTime.Now, MoodLevel=5, MaxMoodLevel=7, Notes="aaa" });
        }
    }
}
