
namespace PlayersAndMonsters.Core
{
    using System;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new ManagerController();

        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        writer.WriteLine(controller.AddPlayer(input[1],input[2]));
                    }
                    else if (input[0] == "AddCard")
                    {
                        writer.WriteLine(controller.AddCard(input[1], input[2]));
                    }
                    else if (input[0] == "AddPlayerCard")
                    {
                        writer.WriteLine(controller.AddPlayerCard(input[1], input[2]));
                    }
                    else if (input[0] == "Fight")
                    {
                        writer.WriteLine(controller.Fight(input[1],input[2]));
                    }
                    else if (input[0] == "Report")
                    {
                        writer.WriteLine(controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                   // writer.WriteLine(ex.ToString());
                }
            }
        }
    }
}
