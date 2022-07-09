using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            Name = name;
            this.players = new List<Player>();
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
        
        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Average(p => p.SkillLevel()), 0);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (this.players.Any(p => p.Name == playerName))
            {
                Player player = this.players.First(p => p.Name == playerName);
                this.players.Remove(player);
            }
            else
            {
                throw new ArgumentException(string.Format(Exceptions.PlayerException, playerName, Name));
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
