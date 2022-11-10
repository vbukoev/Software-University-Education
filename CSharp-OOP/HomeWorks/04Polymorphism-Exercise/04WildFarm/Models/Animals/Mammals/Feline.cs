namespace WildFarm.Models.Animals.Mammals
{
    using Contracts;

    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
