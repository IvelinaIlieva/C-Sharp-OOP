namespace ExplicitInterfaces.Models
{
    using Contracts;
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }
        public string Name { get; }
        public string Country { get; }
        string IResident.GetName()
        {
            return "Mr/Ms/Mrs ";
        }

        public int Age { get; }
        string IPerson.GetName()
        {
            return Name;
        }
    }
}
