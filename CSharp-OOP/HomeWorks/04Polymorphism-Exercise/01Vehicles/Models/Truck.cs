namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double CONSUMPTION_FROM_THE_AIR_CONDITIONER = 1.6;
        private const double FUEL_WASTE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + CONSUMPTION_FROM_THE_AIR_CONDITIONER)
        {
        }
        public override void Refuel(double fuel)//overriding the refuel method of the vehicle class
        {
            base.Refuel(fuel * FUEL_WASTE);
        }
    }
}
