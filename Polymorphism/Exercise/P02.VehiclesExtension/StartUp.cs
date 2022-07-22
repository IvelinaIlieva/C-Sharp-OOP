namespace VehiclesExtension
{
    using Core;
    using Core.Contracts;
    using Factory.Contracts;
    using IO;
    using IO.Contracts;
    using Models.Contracts;
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new Reader();

            string[] carInfo = reader.ReadLine().Split();
            string[] truckInfo = reader.ReadLine().Split();
            string[] busInfo = reader.ReadLine().Split();

            IFactory factory = new Factory.Factory();

            IVehicle car = factory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            IVehicle truck = factory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            IVehicle bus = factory.CreateVehicle(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}
