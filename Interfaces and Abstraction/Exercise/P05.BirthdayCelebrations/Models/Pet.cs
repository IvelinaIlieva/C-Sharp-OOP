namespace BirthdayCelebrations.Models
{
    using Interfaces;
    public class Pet : IBirthable
    {
        public string Name { get; }
        public string BirthDate { get; }

        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
