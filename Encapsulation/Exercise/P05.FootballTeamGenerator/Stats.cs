using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.StatsException, nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint 
        {
            get => this.sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.StatsException, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble 
        {
            get => this.dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.StatsException, nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.StatsException, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(Exceptions.StatsException, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }
    }
}
