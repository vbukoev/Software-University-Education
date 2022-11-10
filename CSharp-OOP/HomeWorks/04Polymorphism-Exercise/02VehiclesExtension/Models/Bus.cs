namespace Vehicles.Models
{
    using Contracts;

    public class Bus : Vehicle, IBus
    {
        private const double AirConditionConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption + AirConditionConsumption, tankCapacity)
        {
        }


        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= AirConditionConsumption;
            return base.Drive(distance);
        }

        
    }
}
