﻿namespace EasterRaces.Models.Cars.Entities
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private const int MinLengthOfModelName = 4;

        private readonly int minHorsePower;
        private readonly int maxHorsePower;
        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinLengthOfModelName)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value,
                        MinLengthOfModelName));
                }
                this.model = value;
            }
        }
        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
        public double CubicCentimeters { get; }
        public double CalculateRacePoints(int laps) 
            => CubicCentimeters / HorsePower * laps;
    }
}
