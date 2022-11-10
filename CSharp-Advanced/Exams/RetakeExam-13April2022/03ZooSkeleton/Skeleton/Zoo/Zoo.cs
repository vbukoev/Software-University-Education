using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == string.Empty)
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "carnivore" && animal.Diet != "herbivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Species == species)
                {
                    count++;
                    Animals.RemoveAt(i);
                    i--;
                }
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var item in Animals)
            {
                if (item.Length <= maximumLength && item.Length >= minimumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}