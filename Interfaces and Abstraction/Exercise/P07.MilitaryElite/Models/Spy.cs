namespace MilitaryElite.Models
{
    using Interfaces;
    using System.Text;
    public class Spy : Soldier, ISpy
    {
        public int CodeNumber { get;  }

        public Spy(string firstName, string lastName, int id, int codeNumber) 
            : base(firstName, lastName, id)
        {
            CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().ToString().TrimEnd();
        }
    }
}
