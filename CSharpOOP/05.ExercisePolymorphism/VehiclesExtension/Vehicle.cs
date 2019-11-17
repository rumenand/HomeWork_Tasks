using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double consumption, double tankFuel)
        {
            this.FuelConsumption = consumption;
            this.TankCapacity = tankFuel;
            if (fuelQuantity > tankFuel) this.FuelQuantity = 0;
            else this.FuelQuantity = fuelQuantity;
        }
        public string Name { get; set; }
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; set; }

        protected double AirConditionerConsumtion { get; set; }

        public string Drive(double distance)
        {
            var fuel = this.NeededFuelForDistance(distance);
            if (fuel > this.FuelQuantity) return $"{this.Name} needs refueling";
            this.FuelQuantity -= fuel;
            return $"{this.Name} travelled {distance} km";
        }

        public virtual void RefuelTank(double refillAmount)
        {
            if (refillAmount <= 0) throw new ArgumentException("Fuel must be a positive number");
            if (this.FuelQuantity + refillAmount > this.TankCapacity)
                throw new ArgumentException($"Cannot fit {refillAmount} fuel in the tank");
            this.FuelQuantity += refillAmount;
        }

        protected double NeededFuelForDistance(double distance)
        {
            return (this.FuelConsumption + this.AirConditionerConsumtion) * distance;
        }        
    }
}
