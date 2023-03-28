using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public class ItemsService
    {
        private static List<Item> Items { get; } = new List<Item>();

        static ItemsService()
        {
            var items = Enumerable.Range(0, 1000)
                .Select(x => new Item(x, $"Item_Name_{x}"));

            Items.AddRange(items);
        }

        public async Task<IEnumerable<Item>> GetBunchOfItemsAsync(int? start = 0, int? count = 50)
        {
            if (count > 50)
                count = 50;

            // 2
            var randomDelay = new Random().Next(3000, 8000);

            //

            await Task.Delay(randomDelay);

            return Items.Skip(start.Value * count.Value).Take(count.Value);
        }

    }

    public class Item
    {
        public Item(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public int Code { get; set; }
        public string Name { get; set; }
    }
}
