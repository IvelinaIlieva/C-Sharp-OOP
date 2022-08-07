namespace CarRacing.Models.Racers
{
    using System;
    using System.Text;
    using Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private const int MinDrivingExperience = 0;
        private const int MaxDrivingExperience = 100;

        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        
        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;
            protected set
            {
                if (value < MinDrivingExperience || value > MaxDrivingExperience)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                this.car = value;
            }
        }
        public virtual void Race()
            => Car.Drive();

        public bool IsAvailable() 
            => Car.FuelAvailable - Car.FuelConsumptionPerRace > 0;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.GetType().Name}: {Username}")
                .AppendLine($"--Driving behavior: {RacingBehavior}")
                .AppendLine($"--Driving experience: {DrivingExperience}")
                .AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
