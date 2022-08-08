using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") break;
                string[] tokens = command.Split();
                Box box = new Box
                {
                    SerialNum = tokens[0],
                    Item = new Item
                    {
                        Name = tokens[1],
                        Price = decimal.Parse(tokens[3])
                    },
                ItemQuantity = int.Parse(tokens[2])
                };
                boxes.Add(box);
            }
            List<Box> ordered = boxes.OrderByDescending(box=>box.Price).ToList();

            foreach (Box box in ordered)
            {
                Console.WriteLine(box.SerialNum);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }               
    }
    class Box
    {
        public string SerialNum { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal Price
        { 
            get
            {
                return this.ItemQuantity * this.Item.Price;
            } 
        }
    }
}
