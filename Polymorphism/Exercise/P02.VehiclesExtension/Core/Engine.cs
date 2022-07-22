namespace VehiclesExtension.Core
{
    using System;
    using Contracts;
    using IO;
    using VehiclesExtension.IO.Contracts;
    using VehiclesExtension.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicle car;
        private readonly IVehicle truck;
        private readonly IVehicle bus;

        public Engine(IVehicle car, IVehicle truck, IVehicle bus)
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }
        public void Start()
        {
            int countOfCommands = int.Parse(reader.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] cmdArgs = reader.ReadLine().Split();
                string cmd = cmdArgs[0];
                string type = cmdArgs[1];

                try
                {
                    if (cmd.StartsWith("Drive"))
                    {
                        double distance = double.Parse(cmdArgs[2]);

                        switch (type)
                        {
                            case "Car":
                                writer.WriteLine(car.Drive(distance));
                                break;

                            case "Truck":
                                writer.WriteLine(truck.Drive(distance));
                                break;

                            case "Bus":

                                writer.WriteLine(cmd == "DriveEmpty" 
                                    ? bus.DriveEmpty(distance) 
                                    : bus.Drive(distance));

                                break;
                        }
                    }
                    else if (cmd == "Refuel")
                    {
                        double quantity = double.Parse(cmdArgs[2]);

                        switch (type)
                        {
                            case "Car":
                                car.Refuel(quantity);
                                break;

                            case "Truck":
                                truck.Refuel(quantity);
                                break;

                            case "Bus":
                                bus.Refuel(quantity);
                                break;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid Operation");
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
            writer.WriteLine(bus.ToString());
        }
    }
}
