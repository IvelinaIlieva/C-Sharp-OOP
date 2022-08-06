namespace Formula1.Models
{
    using System;
    using Contracts;
    using Utilities;

    public class Pilot : IPilot
    {
        private const int MinPilotNameLength = 5;

        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinPilotNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value;
            }
        }
        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }
        public int NumberOfWins { get; private set; }
        public bool CanRace { get; private set; }
        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace() 
            => NumberOfWins++;

        public override string ToString()
            => $"Pilot {FullName} has {NumberOfWins} wins.";
        
    }
}
