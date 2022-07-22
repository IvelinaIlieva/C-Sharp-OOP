namespace Vehicles.Models
{
    using Contracts;

    public class Car : Vehicle, ICar
    {
        private const double FuelConsumptionCoefIncreasement = 0.9;
        
        public Car(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }

        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            protected set => base.FuelConsumptionPerKm = FuelConsumptionCoefIncreasement + value;
        }
    }
}
