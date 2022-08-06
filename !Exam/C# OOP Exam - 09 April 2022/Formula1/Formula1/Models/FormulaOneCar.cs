namespace Formula1.Models
{
    using System;
    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private const int MinModelNameLength = 3;
        private const int MinHorsePower = 900;
        private const int MaxHorsePower = 1050;
        private const double MinEngineDisplacement = 1.6;
        private const double MaxEngineDisplacement = 2.0;
        
        private string model;
        private int horsepower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinModelNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horsepower;
            private set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDisplacement;
            private set
            {
                if (value < MinEngineDisplacement || value > MaxEngineDisplacement)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps) 
            => EngineDisplacement / Horsepower * laps;
    }
}
