namespace CarRacing.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Cars;
    using Models.Cars.Contracts;
    using Models.Maps;
    using Models.Maps.Contracts;
    using Models.Racers;
    using Models.Racers.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),
                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException(ExceptionMessages.InvalidCarType)
            };

            this.cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, car),
                nameof(StreetRacer) => new StreetRacer(username, car),
                _ => throw new ArgumentException(ExceptionMessages.InvalidRacerType)
            };

            this.racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null || racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,
                    (racerOne == null ? racerOneUsername : racerTwoUsername)));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer racer in this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
