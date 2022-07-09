namespace P05.FootballTeamGenerator
{
    public static class Exceptions
    {
        public const string StatsException = "{0} should be between 0 and 100.";
        public const string NameException = "A name should not be empty.";
        public const string PlayerException = "Player {0} is not in {1} team.";
        public const string TeamException = "Team {0} does not exist.";
    }
}
