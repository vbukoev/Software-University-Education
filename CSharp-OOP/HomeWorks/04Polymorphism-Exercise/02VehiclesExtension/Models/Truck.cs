using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double CONSUMPTION_FROM_THE_AIR_CONDITIONER = 1.6;
        private const double FUEL_WASTE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption + CONSUMPTION_FROM_THE_AIR_CONDITIONER, tankCapacity)
        {
        }
        public override void Refuel(double fuel)
        {
            if (fuel <= 0) throw new NegativeFuelException();

            if (fuel + this.FuelQuantity > this.TankCapacity) throw new MoreFuelException($"Cannot fit {fuel} fuel in the tank");

            this.FuelQuantity = FuelQuantity + fuel * FUEL_WASTE;
        }
    }
}
