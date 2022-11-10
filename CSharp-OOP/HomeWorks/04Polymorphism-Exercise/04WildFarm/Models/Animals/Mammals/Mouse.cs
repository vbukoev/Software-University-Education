namespace WildFarm.Models.Animals.Mammals
{
    using Contracts;
    using Exceptions;

    public class Mouse : Mammal
    {
        private const double GainValue = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override void Eat(IFood food)
        {
            var animalType = GetType().Name;
            var foodType = food.GetType().Name;
            if (foodType == "Meat" || foodType == "Seeds")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }
            FoodEaten += food.Quantity;
            Weight += FoodEaten * GainValue;
        }
        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
