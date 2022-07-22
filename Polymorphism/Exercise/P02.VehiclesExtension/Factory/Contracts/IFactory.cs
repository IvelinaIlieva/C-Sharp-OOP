namespace VehiclesExtension.Factory.Contracts
{
    using Models;
    public interface IFactory
    {
        Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
