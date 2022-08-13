namespace EasterRaces.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Drivers.Contracts;
    using Models.Drivers.Entities;
    using Models.Races.Contracts;
    using Models.Races.Entities;
    using Repositories.Entities;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository cars;
        private readonly DriverRepository drivers;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = type switch
            {
                "Muscle" => new MuscleCar(model, horsePower),
                "Sports" => new SportsCar(model, horsePower),
                _ => null
            };

            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            const int MinDriversCount = 3;

            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MinDriversCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName,
                    MinDriversCount));
            }

            List<IDriver> topThree = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(MinDriversCount).ToList();

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(string.Format(OutputMessages.DriverFirstPosition, topThree[0].Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, topThree[1].Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverThirdPosition, topThree[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
