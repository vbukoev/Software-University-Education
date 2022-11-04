namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double Default_Sports_Car_Fuel_Consumption = 10;
        public SportCar(int hp, double fuel) : base(hp, fuel)
        {
        }
        public override double FuelConsumption => Default_Sports_Car_Fuel_Consumption;
    }
}
