namespace CarRacing.Models.Maps
{
    using Contracts;
    using Racers.Contracts;
    using Utilities.Messages;

    public class Map : IMap
    {
        private const double StrictCoefficient = 1.2;
        private const double AggressiveCoefficient = 1.1;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceToWinRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience *
                                         (racerOne.RacingBehavior == "strict" ? StrictCoefficient : AggressiveCoefficient);

            double chanceToWinRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience *
                                         (racerTwo.RacingBehavior == "strict" ? StrictCoefficient : AggressiveCoefficient);

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                (chanceToWinRacerOne > chanceToWinRacerTwo ? racerOne.Username : racerTwo.Username));
        }
    }
}
