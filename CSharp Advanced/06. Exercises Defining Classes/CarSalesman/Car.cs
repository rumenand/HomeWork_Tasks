using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string[] args, List<Engine> engines)
        {
            this.Model = args[0];
            this.Engine = engines.Where(x => x.Model == args[1]).FirstOrDefault();
            this.Weight = -1;
            this.Color = "n/a";
            if (args.Length == 4)
            {
                this.Weight = int.Parse(args[2]);
                this.Color = args[3];
            }
            else if (args.Length == 3)
            {
                int number = 0;
                bool result = int.TryParse(args[2], out number);
                if (result) this.Weight = number;
                else  this.Color = args[2];
            }    
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Model);
            sb.Append($":{ Environment.NewLine}  ");
            sb.Append(this.Engine.Model);
            sb.Append($":{ Environment.NewLine}    Power: ");
            sb.Append(this.Engine.Power);
            sb.Append($"{ Environment.NewLine}    Displacement: ");
            sb.Append((this.Engine.Displacement > -1) ? this.Engine.Displacement.ToString() : "n/a");
            sb.Append($"{ Environment.NewLine}    Efficiency: ");
            sb.Append(this.Engine.Efficiency);
            sb.Append(Environment.NewLine);
            sb.Append($"  Weight: ");
            sb.Append(this.Weight > -1 ? this.Weight.ToString() : "n/a");
            sb.Append(Environment.NewLine);
            sb.Append($"  Color: ");
            sb.Append(this.Color);
            return sb.ToString();
        }
    }
}
