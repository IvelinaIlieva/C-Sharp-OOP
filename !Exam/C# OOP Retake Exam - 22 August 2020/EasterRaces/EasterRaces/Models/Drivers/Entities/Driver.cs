namespace EasterRaces.Models.Drivers.Entities
{
    using System;
    using Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class Driver : IDriver
    {
        private const int MinLengthOfName = 5;

        private string name;
        private ICar _car;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinLengthOfName)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinLengthOfName));
                }
                this.name = value;
            }
        }

        public ICar Car
        {
            get => this._car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.CarInvalid);
                }
                this._car = value;
            }
        }

        public int NumberOfWins { get; private set; }
        public bool CanParticipate 
            => Car != null;

        public void WinRace() 
            => NumberOfWins++;

        public void AddCar(ICar car)
        {
            Car = car;
        }
    }
}
