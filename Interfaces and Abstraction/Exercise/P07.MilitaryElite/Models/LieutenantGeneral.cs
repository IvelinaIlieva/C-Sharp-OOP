namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; }

        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary, List<Private> privates) 
            : base(firstName, lastName, id, salary)
        {
            Privates = privates;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (Private priv in Privates)
            {
                sb.AppendLine(priv.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
