namespace VehiclesExtension.Models
{
    using Contracts;
    public class Bus : Vehicle, IBus
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {

        }

        public override double FuelConsumptionModifier => 1.4;
    }
}
