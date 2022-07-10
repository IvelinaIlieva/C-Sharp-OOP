namespace MilitaryElite.Models
{
    using Interfaces;
    public abstract class Soldier 
        : ISoldier
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Id { get; set; }

        protected Soldier(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
