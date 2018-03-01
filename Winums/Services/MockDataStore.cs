using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winums
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        List<int> nums;

        public MockDataStore()
        {
            items = new List<Item>();
            nums = RandomNumGen.GenDrawSequence();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = nums[0].ToString() },
                new Item { Id = Guid.NewGuid().ToString(), Text = nums[1].ToString() },
                new Item { Id = Guid.NewGuid().ToString(), Text = nums[2].ToString() },
                new Item { Id = Guid.NewGuid().ToString(), Text = nums[3].ToString() },
                new Item { Id = Guid.NewGuid().ToString(), Text = nums[4].ToString() },
                new Item { Id = Guid.NewGuid().ToString(), Text = nums[5].ToString() },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
