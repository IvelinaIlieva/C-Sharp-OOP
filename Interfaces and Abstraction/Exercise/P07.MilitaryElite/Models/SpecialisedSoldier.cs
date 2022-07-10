namespace MilitaryElite.Models
{
    using System.Text;
    using Interfaces;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public string Corps
        {
            get => this.corps;
            private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    this.corps = string.Empty;
                }
            }
        }

        protected SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary)
        {
            Corps = corps;
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
           sb.AppendLine(base.ToString());
           sb.AppendLine($"Corps: {Corps}");
           return sb.ToString().TrimEnd();
        }
    }
}
