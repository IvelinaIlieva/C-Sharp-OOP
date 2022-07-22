namespace Vehicles.Models
{
    using Contracts;

    public class Truck : Vehicle, ITruck
    {
        private const double FuelConsumptionCoefIncreasement = 1.6;
        private const double FuelRefuelCoefDecreasement = 0.95;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }

        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            protected set => base.FuelConsumptionPerKm = FuelConsumptionCoefIncreasement + value;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * FuelRefuelCoefDecreasement);
        }
    }
}
