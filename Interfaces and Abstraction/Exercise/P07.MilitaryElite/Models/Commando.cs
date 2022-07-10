namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; }

        public Commando(string firstName, string lastName, int id, decimal salary, string corps, List<Mission> missions) 
            : base(firstName, lastName, id, salary, corps)
        {
            Missions = missions;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            if (Missions.Count != 0)
            {
                foreach (var mission in Missions)
                {
                    if (mission.State == null)
                    {
                        continue;
                    }

                    sb.AppendLine(mission.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
