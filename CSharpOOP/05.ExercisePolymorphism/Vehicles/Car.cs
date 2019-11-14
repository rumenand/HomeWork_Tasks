

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumption) : base (fuelQuantity,consumption)
        {
            this.AirConditionerConsumtion = 0.9;
            this.Name = "Car";
        }        

        public override void RefuelTank(double refillAmount)
        {
            this.FuelQuantity += refillAmount;
        }
    }
}
