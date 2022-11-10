namespace WildFarm.Models.Animals.Birds
{
    using Contracts;

    public class Hen : Bird
    {
        private const double GainValue = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override void Eat(IFood food)
        {
            FoodEaten += food.Quantity;
            Weight += FoodEaten * GainValue;
        }
        public override string ProduceSound()
         => "Cluck";
    }
}
