namespace VehiclesExtension.Models
{
    using Contracts;
    public class Car : Vehicle, ICar
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {

        }

        public override double FuelConsumptionModifier => 0.9;
    }
}
