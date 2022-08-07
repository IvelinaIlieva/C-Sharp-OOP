namespace Gym.IO
{
    using Contracts;
    using System;
    using System.IO;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            //File.WriteAllText("output.txt", message);
            Console.WriteLine(message);
        }
    }
}
