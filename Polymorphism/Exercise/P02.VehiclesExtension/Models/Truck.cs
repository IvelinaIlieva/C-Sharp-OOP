namespace VehiclesExtension.Models
{
    using Contracts;
    public class Truck : Vehicle, ITruck
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity,  fuelConsumptionPerKm, tankCapacity)
        {

        }

        public override double RefuelModifier => 0.95;
        public override double FuelConsumptionModifier => 1.6;
       
    }
}
