
namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumption, double tankFuel) : base(fuelQuantity, consumption, tankFuel)
        {
            this.AirConditionerConsumtion = 1.4;
            this.Name = "Bus";
        } 

        public string DriveEmpty(double distance)
        {
            var fuel = this.FuelConsumption*distance;
            if (fuel > this.FuelQuantity) return $"{this.Name} needs refueling";
            this.FuelQuantity -= fuel;
            return $"{this.Name} travelled {distance} km";
        }
    }
}
