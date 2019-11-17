
namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double consumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = consumption;
        }
        public string Name { get; set; }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }

        protected double AirConditionerConsumtion { get; set; }

        public string Drive(double distance)
        {
            var fuel = this.NeededFuelForDistance(distance);
            if (fuel > this.FuelQuantity) return $"{this.Name} needs refueling";
            this.FuelQuantity -= fuel;
            return $"{this.Name} travelled {distance} km";
        }

        public abstract void RefuelTank(double refillAmount);

        private double NeededFuelForDistance(double distance)
        {
            return (this.FuelConsumption + this.AirConditionerConsumtion) * distance;
        }
    }
}
