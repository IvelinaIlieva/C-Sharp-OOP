namespace P01._Square_Root
{
    using System;

    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                double result = Math.Sqrt(number);

                if (double.IsNaN(result))
                {
                    throw new ArithmeticException("Invalid number.");
                }

                Console.WriteLine(result);
            }
            catch(ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
