namespace Vehicles.Factory
{
    using System;
    using Contracts;
    using Models;

    public class Factory : IFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
           
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new ArgumentException("Invalid vehicle");
            }

            return vehicle;
        }
    }
}
