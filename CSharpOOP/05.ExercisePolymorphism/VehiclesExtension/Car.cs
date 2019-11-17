

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumption, double tankFuel) : base (fuelQuantity,consumption, tankFuel)
        {
            this.AirConditionerConsumtion = 0.9;
            this.Name = "Car";
        }  
    }
}
