namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private const int PowerDecreaseValue = 10;

        private int power;

        public Dye(int power)
        {
            Power = power;
        }
        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.power = value;
            }
        }
        public void Use() 
            => Power -= PowerDecreaseValue;

        public bool IsFinished() 
            => Power == 0;
    }
}
