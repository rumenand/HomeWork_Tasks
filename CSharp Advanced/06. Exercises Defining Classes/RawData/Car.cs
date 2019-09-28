using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire [] Tires { get; set; }
        public Car(string [] args)
        {
            this.Model = args[0];
            this.Engine = new Engine();
            this.Engine.EngineSpeed = int.Parse(args[1]);
            this.Engine.EnginePower = int.Parse(args[2]);
            this.Cargo = new Cargo();
            this.Cargo.CargoWeight = int.Parse(args[3]);
            this.Cargo.CargoType = args[4];
            this.Tires = new Tire[4];
            this.Tires[0] = new Tire();
            this.Tires[1] = new Tire();
            this.Tires[2] = new Tire();
            this.Tires[3] = new Tire();
            this.Tires[0].TirePressure = double.Parse(args[5]);
            this.Tires[0].TireAge = int.Parse(args[6]);
            this.Tires[1].TirePressure = double.Parse(args[7]);
            this.Tires[1].TireAge = int.Parse(args[8]);
            this.Tires[2].TirePressure = double.Parse(args[9]);
            this.Tires[2].TireAge = int.Parse(args[10]);
            this.Tires[3].TirePressure = double.Parse(args[11]);
            this.Tires[3].TireAge = int.Parse(args[12]);
        }
    }
}
