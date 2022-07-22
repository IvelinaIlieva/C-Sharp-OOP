namespace Vehicles
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

            IFactory factory = new Factory.Factory();

            IVehicle car = factory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            IVehicle truck = factory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
