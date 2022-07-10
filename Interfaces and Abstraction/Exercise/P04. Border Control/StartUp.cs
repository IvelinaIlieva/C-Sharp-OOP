namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> visitors = new List<IIdentifiable>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length > 2)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    Citizen citizen = new Citizen(id, name, age);
                    visitors.Add(citizen);
                }
                else
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    Robot robot = new Robot(id, model);
                    visitors.Add(robot);
                }
            }

            string lastOfFakeId = Console.ReadLine();

            foreach (var visitor in visitors)
            {
                if (visitor.Id.Substring(visitor.Id.Length - lastOfFakeId.Length, lastOfFakeId.Length) == lastOfFakeId)
                {
                    Console.WriteLine(visitor.Id);
                }
            }
        }
    }
}
