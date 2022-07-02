using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList list = new RandomList() {"Iva", "Plamen", "Todor"};
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
