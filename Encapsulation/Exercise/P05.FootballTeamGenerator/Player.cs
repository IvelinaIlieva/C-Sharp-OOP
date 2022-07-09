using System;

namespace P05.FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Exceptions.NameException);
                }
                this.name = value;
            }

        }
        public Stats Stats { get; }
        public double SkillLevel() => (Stats.Endurance + Stats.Dribble + Stats.Passing + Stats.Shooting + Stats.Sprint) / 5.0;
    }
}
