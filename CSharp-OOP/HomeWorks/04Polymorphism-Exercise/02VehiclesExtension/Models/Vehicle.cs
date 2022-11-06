namespace Vehicles.Models
{
    using Contracts;
    using Exceptions;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public int TankCapacity { get; protected set; }
        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
                
            }
        }

        public double FuelConsumption { get; protected set; }

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
            if (fuel <= 0) throw new NegativeFuelException();

            if (fuel + FuelQuantity > TankCapacity) throw new MoreFuelException($"Cannot fit {fuel} fuel in the tank");

            FuelQuantity = FuelQuantity + fuel;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
