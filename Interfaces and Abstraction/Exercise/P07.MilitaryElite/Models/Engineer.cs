namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; }

        public Engineer(string firstName, string lastName, int id, decimal salary, string corps, List<Repair> repairs)
            : base(firstName, lastName, id, salary, corps)
        {
            Repairs = repairs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
