
namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumption) : base(fuelQuantity, consumption)
        {
            this.AirConditionerConsumtion = 1.6;
            this.Name = "Truck";
        }       

        public override void RefuelTank(double refillAmount)
        {
            this.FuelQuantity += refillAmount * 0.95;
        }
    }
}
