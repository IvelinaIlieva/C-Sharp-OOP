namespace ValidationAttributes
{
    using System;
    using Validator = Utilities.Validator;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Iv",
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
