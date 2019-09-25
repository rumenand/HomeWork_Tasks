using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var tiresList = new List<Tire []>();
            string input;
            while((input = Console.ReadLine()) != "No more tires")
            {
                var tireInfo = input.Split();
                var tires = new Tire[tireInfo.Length/2];
                for (int i=0; i<tires.Length;i++)
                {
                    tires[i] = new Tire(int.Parse(tireInfo[i * 2]), double.Parse(tireInfo[i * 2 + 1]));                  
                }
                tiresList.Add(tires);
            }
            var enginesList = new List<Engine>();
            while((input = Console.ReadLine()) != "Engines done")
            {
                var engineInfo = input.Split();
                enginesList.Add(new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1])));
            }
            var carsList = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                var carInfo = input.Split();
                carsList.Add(new Car(carInfo[0], carInfo[1], int.Parse(carInfo[2]), 
                    double.Parse(carInfo[3]), double.Parse(carInfo[4]),
                    enginesList[int.Parse(carInfo[5])], tiresList[int.Parse(carInfo[6])] ));
            }
            Func<Car, bool> checker = n => n.Year>=2017 
            && n.Engine.HorsePower>300 && (n.GetAllTiresPressure() >= 9) 
            && n.GetAllTiresPressure()<=10;
            var specialCars = carsList.Where(checker).ToList();
            foreach (var spCar in specialCars)
            {
                spCar.Drive(20);
                Console.WriteLine($"Make: {spCar.Make}");
                Console.WriteLine($"Model: {spCar.Model}");
                Console.WriteLine($"Year: {spCar.Year}");
                Console.WriteLine($"HorsePowers: {spCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {spCar.FuelQuantity}");
            }            
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
    }

    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }


        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year,
            double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year,
        double fuelQuantity, double fuelConsumption, Engine engine,
        Tire[] tires)
        : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance / 100 * fuelConsumption;
            if ((fuelQuantity - fuelNeeded) > 0) fuelQuantity -= fuelNeeded;
            else Console.WriteLine("Not enough fuel to perform this trip!");
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
        }

        public double GetAllTiresPressure()
        {
            double allPressure = 0;
            foreach (var tire in tires)
            {
                allPressure += tire.Pressure;
            }
            return allPressure;
        }

    }
}
