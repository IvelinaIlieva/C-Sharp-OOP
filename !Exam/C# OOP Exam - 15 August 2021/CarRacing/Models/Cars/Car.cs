namespace CarRacing.Models.Cars
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private const int VinLength = 17;

        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length != VinLength)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                this.fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
            => FuelAvailable -= FuelConsumptionPerRace;
    }
}
