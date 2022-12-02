using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> bagItems;

        public Bag(int capacity)
        {
            Capacity = capacity;
            bagItems = new List<Item>();
        }

        public int Capacity { get; set; } = 100;
        public int Load => bagItems.Select(x => x.Weight).Sum();
        public IReadOnlyCollection<Item> Items => bagItems.AsReadOnly();
        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            bagItems.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!bagItems.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = bagItems.Find(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }
            bagItems.Remove(item);

            return item;
        }
    }
}
