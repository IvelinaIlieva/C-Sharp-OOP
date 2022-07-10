namespace MilitaryElite.Models
{
    using Interfaces;
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; }

        public Private(string firstName, string lastName, int id, decimal salary) 
            : base(firstName, lastName, id)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary :f2}";
        }
    }
}
