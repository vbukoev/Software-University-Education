namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic; 

    using Contracts;
    using Exceptions;
    using Models.Animals.Birds;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;
    using Models.Foods;

    public class Engine
    {
        private readonly List<IAnimal> animals;
        public Engine()
        {
            this.animals = new List<IAnimal>();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();
                try
                {
                    IAnimal animal = CreateAnimal(animalInfo);
                    IFood food = CreateFood(foodInfo);
                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (InvalidFoodException ife)
                {
                    Console.WriteLine(ife.Message);
                }
            }
            PrintAnimals();
        }

        private IFood CreateFood(string[] foodInfo)
        {
            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);
            IFood food = null;
            if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            return food;
        }

        private IAnimal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            IAnimal animal = null;
            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegion = animalInfo[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = animalInfo[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            return animal;
        }

        private void PrintAnimals()
        {
            foreach (IAnimal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
