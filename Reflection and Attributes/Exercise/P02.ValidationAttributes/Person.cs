namespace ValidationAttributes
{
    using Utilities;

    public class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRangeAttribute(minAge, maxAge)]
        public int Age { get; set; }
    }
}
