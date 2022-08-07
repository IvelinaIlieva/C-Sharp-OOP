namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string InitialRacingBehavior = "aggressive";
        private const int DrivingExperienceIncreasement = 5;

        public StreetRacer(string username, ICar car) 
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {

        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += DrivingExperienceIncreasement;
        }
    }
}
