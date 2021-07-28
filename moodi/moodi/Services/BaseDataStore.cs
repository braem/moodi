using moodi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace moodi.Services
{
    class BaseDataStore<T> : IDataStore<T> where T : BaseModel
    {
        public List<T> Items { get; set; }

        public BaseDataStore()
        {
            Items = new List<T>();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Items.Where((T arg) => arg.ID == item.ID).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = Items.Where((T arg) => arg.ID == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(Guid id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public int GetNumItems()
        {
            return Items.Count();
        }
    }
}
