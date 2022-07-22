namespace Raiding
{
    using Core;
    using Core.Contracts;
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
