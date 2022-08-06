namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities;

    public class Race : IRace
    {
        private const int MinRaceNameLength = 5;
        private const int MinNumberOfLaps = 1;

        private string raceName;
        private int numberOfLaps;
        private readonly List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinRaceNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < MinNumberOfLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
        }
        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots 
            => this.pilots.AsReadOnly();
        public void AddPilot(IPilot pilot) 
            => this.pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {this.pilots.Count}")
                .AppendLine($"Number of laps: {numberOfLaps}")
                .AppendLine($"Took place: {(TookPlace == true ? "Yes" : "No")}");

            return sb.ToString().TrimEnd();
        }
    }
}
