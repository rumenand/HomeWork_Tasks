namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
 
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}