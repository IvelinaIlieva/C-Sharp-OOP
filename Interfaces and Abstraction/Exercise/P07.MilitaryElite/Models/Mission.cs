namespace MilitaryElite.Models
{
    public class Mission
    {
        private string state;
        public string CodeName { get; }

        //inProgress or Finished
        public string State
        {
            get => this.state;
            private set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
                else
                {
                    this.state = null;
                }
            }
        }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public void CompleteMission() => State = "Finished";

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
