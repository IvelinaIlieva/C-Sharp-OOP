namespace VehiclesExtension.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        double TankCapacity { get; }
        string Drive(double distance);
        string DriveEmpty(double distance);
        void Refuel(double liters);
    }
}
