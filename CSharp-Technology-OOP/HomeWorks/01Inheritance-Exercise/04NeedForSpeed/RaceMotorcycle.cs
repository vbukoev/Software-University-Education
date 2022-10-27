namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_RACE_MOTORCYCLE_FUEL_CONSUMPTION = 8;
        public RaceMotorcycle(int hp, double fuel) : base(hp, fuel)
        {
        }
        public override double FuelConsumption => DEFAULT_RACE_MOTORCYCLE_FUEL_CONSUMPTION;
    }
}
