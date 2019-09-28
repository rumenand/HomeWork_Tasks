using System;

namespace CarSalesman
{
    class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string [] args)
        {
            this.Model = args[0];
            this.Power = int.Parse(args[1]);
            this.Displacement = -1;
            this.Efficiency = "n/a";
            if (args.Length == 4)
            {
                this.Displacement = int.Parse(args[2]);
                this.Efficiency = args[3];
            }
            else if (args.Length == 3)
            {
                int number = 0;
                bool result = int.TryParse(args[2], out number);
                if (result) this.Displacement = number;
                else this.Efficiency = args[2];
            }
        }
    }
}
