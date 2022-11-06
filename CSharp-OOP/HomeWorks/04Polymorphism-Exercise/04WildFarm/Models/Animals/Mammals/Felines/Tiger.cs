namespace WildFarm.Models.Animals.Mammals.Felines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Contracts;
    using WildFarm.Exceptions;

    public class Tiger : Feline
    {
        private const double GainValue = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(IFood food)
        {
            var animalType = GetType().Name;
            var foodType = food.GetType().Name;
            if (foodType == "Seeds" || foodType == "Fruit" || foodType == "Vegetable")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }
            FoodEaten += food.Quantity;
            Weight += FoodEaten * GainValue;
        }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
