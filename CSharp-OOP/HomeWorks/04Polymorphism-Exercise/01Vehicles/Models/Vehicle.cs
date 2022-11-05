namespace _01Vehicles.Models
{
    using Contracts;
    using Exceptions;
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            bool canDrive = FuelQuantity>= FuelConsumption * distance;
            if (!canDrive)
            {
                throw new LowFuelException($"{GetType().Name} needs refueling");
            }
            FuelQuantity = FuelQuantity - (FuelConsumption * distance);
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity = FuelQuantity + fuel;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
