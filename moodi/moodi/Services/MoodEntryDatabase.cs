using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using moodi.Models;

namespace moodi.Services
{
    public class MoodEntryDatabase
    {
        readonly SQLiteAsyncConnection database;

        public MoodEntryDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<MoodEntry>().Wait();
        }

        public Task<List<MoodEntry>> GetMoodEntries()
        {
            return database.Table<MoodEntry>().ToListAsync();
        }

        public Task<MoodEntry> GetMoodEntry(int id)
        {
            return database.Table<MoodEntry>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveMoodEntry(MoodEntry entry)
        {
            if (entry.ID != 0)
            {
                return database.UpdateAsync(entry);
            }
            else
            {
                return database.InsertAsync(entry);
            }
        }

        public Task<int> DeleteMoodEntry(MoodEntry entry)
        {
            return database.DeleteAsync(entry);
        }
    }
}
