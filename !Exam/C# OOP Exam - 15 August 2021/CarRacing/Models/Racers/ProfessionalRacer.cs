namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string InitialRacingBehavior = "strict";
        private const int DrivingExperienceIncreasement = 10;

        public ProfessionalRacer(string username, ICar car) 
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
