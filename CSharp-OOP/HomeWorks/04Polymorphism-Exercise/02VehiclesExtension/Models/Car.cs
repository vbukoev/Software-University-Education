namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CONSUMPTION_FROM_THE_AIR_CONDITIONER = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption + CONSUMPTION_FROM_THE_AIR_CONDITIONER, tankCapacity)
        {
        }
    }
}
