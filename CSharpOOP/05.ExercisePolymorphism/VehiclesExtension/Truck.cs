using System;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumption, double tankFuel) : base(fuelQuantity, consumption, tankFuel)
        {
            this.AirConditionerConsumtion = 1.6;
            this.Name = "Truck";
        }       

        public override void RefuelTank(double refillAmount)
        {
            if (refillAmount <= 0) throw new ArgumentException("Fuel must be a positive number");
            var newFuel = this.FuelQuantity + (refillAmount * 0.95);
            if (newFuel > this.TankCapacity) throw new ArgumentException($"Cannot fit {refillAmount} fuel in the tank");
            this.FuelQuantity = newFuel;
        }
    }
}
