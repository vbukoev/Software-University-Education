using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                people = People();
                products = Products();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;
                var personName = input.Split().First();
                var productName = input.Split().Last();
                Person currPerson = people.Find(x => x.Name == personName);
                Product currProduct = products.Find(x => x.Name == productName);
                if (currPerson != null && currProduct != null)
                {
                    currPerson.BuyProduct(currProduct);
                }
            }
            foreach (var person in people)
            {
                if (person.Bag.Any()) Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                else Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }

        private static List<Product> Products()
        {
            List<Product> products = new List<Product>();
            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < info.Length; i++)
            {
                string name = info[i].Split('=', StringSplitOptions.RemoveEmptyEntries).First();
                decimal cost = decimal.Parse(info[i].Split('=', StringSplitOptions.RemoveEmptyEntries).Last());
                products.Add(new Product(name, cost));
            }
            return products;
        }

        private static List<Person> People()
        {
            List<Person> people = new List<Person>();
            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < info.Length; i++)
            {
                string name = info[i].Split('=', StringSplitOptions.RemoveEmptyEntries).First();
                decimal money = decimal.Parse(info[i].Split('=', StringSplitOptions.RemoveEmptyEntries).Last());
                people.Add(new Person(name, money));
            }
            return people;
        }
    }
}
