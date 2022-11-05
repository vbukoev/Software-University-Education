namespace Vehicles.Contracts
{
    public interface Vehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        int TankCapacity { get; }
        string Drive(double distance);
        void Refuel(double fuel);
    }
}
