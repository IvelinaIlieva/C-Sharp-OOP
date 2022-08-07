namespace Easter.Models.Workshops
{
    using System.Linq;
    using Bunnies.Contracts;
    using Contracts;
    using Dyes.Contracts;
    using Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (IDye dye in bunny.Dyes.Where(d => !d.IsFinished()))
            {
                while (!dye.IsFinished())
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (bunny.Energy == 0 || egg.IsDone())
                    {
                        break;
                    }
                }

                if (bunny.Energy == 0 || egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
