namespace MilitaryElite.Models
{
    public class Repair
    {
        public string PartName { get; }
        public int WorkedHours { get; }

        public Repair(string partName, int workedHours)
        {
            PartName = partName;
            WorkedHours = workedHours;
        }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {WorkedHours}";
        }
    }
}
