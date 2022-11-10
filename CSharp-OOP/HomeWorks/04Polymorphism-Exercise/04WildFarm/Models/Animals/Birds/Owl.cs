namespace WildFarm.Models.Animals.Birds
{
    using Contracts;
    using Exceptions;

    public class Owl : Bird
    {
        private const double GainValue = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override void Eat(IFood food)
        {
            var animalType = GetType().Name;
            var foodType = food.GetType().Name;
            if (foodType == "Fruit" || foodType == "Seeds" || foodType == "Vegetable")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }
            FoodEaten += food.Quantity;
            Weight += FoodEaten * GainValue;
        }
        public override string ProduceSound()
         => "Hoot Hoot"; 
    }
}
