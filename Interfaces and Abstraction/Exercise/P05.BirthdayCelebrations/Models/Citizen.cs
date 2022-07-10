namespace BirthdayCelebrations.Models
{
    using Interfaces;
  
    public class Citizen : IIdentifiable, IBirthable
    {
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }
        public string BirthDate { get; }

        public Citizen(string id, string name, int age, string birthDate)
        {
            Id = id;
            Name = name;
            Age = age;
            BirthDate = birthDate;
        }
    }
}
