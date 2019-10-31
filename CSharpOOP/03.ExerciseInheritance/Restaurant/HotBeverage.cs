
namespace Restaurant
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters) : base(name, price,milliliters)
        {

        }

        public HotBeverage(string name) : base(name)
        {

        }
    }
}
