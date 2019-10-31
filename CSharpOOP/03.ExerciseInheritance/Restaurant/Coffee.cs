namespace Restaurant
{
    public class Coffee : HotBeverage
    {      
        public Coffee(string name, decimal price, double milliliters) : base(name, price , milliliters)
        {
          
        }
        public Coffee(string name) : base(name)
        {
            this.Price = 3.50m;
            this.Milliliters = 50;
        }
        public double Caffeine { get; set; }
        double CoffeeMilliliters = 50;
        decimal CoffeePrice = 3.50m;

    }
}
