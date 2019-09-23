using System;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return  fuelConsumption; }
            set {  fuelConsumption = value; }
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
            double fuelNeeded = distance/100 * fuelConsumption;
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

    }
}
