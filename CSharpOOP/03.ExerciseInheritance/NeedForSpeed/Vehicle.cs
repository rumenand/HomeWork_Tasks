
namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HoursePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 1.25;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public int HoursePower { get; set; }
        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            var currentConsumption = this.FuelConsumption;
            if (currentConsumption == 0) currentConsumption = DefaultFuelConsumption;
            var fuelNeeded = kilometers * currentConsumption;
            this.Fuel -= fuelNeeded;
        }
    }
}
