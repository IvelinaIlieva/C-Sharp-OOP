namespace VehiclesExtension.Models
{
    using System;
    using Contracts;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity 
        {
            get => this.fuelQuantity;

            private set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionPerKm { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual double RefuelModifier => 1;
        public virtual double FuelConsumptionModifier => 0;

        public virtual string Drive(double distance)
        {
            if (distance * (FuelConsumptionPerKm + FuelConsumptionModifier) > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * (FuelConsumptionPerKm + FuelConsumptionModifier);

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            if (distance * FuelConsumptionPerKm > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * (FuelConsumptionPerKm);

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters * RefuelModifier > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters * RefuelModifier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
