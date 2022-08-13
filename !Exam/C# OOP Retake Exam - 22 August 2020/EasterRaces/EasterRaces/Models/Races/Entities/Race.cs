namespace EasterRaces.Models.Races.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Drivers.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int MinLengthOfName = 5;
        private const int MinRaceCount = 1;

        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            this.drivers = new List<IDriver>();
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
        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MinRaceCount)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinRaceCount));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers 
            => this.drivers.AsReadOnly();
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Any(d=>d.Name == driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            this.drivers.Add(driver);
        }
    }
}
