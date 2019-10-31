
namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams) : base(name,price)
        {

        }

        public Food(string name) :base(name)
        {

        }

        public Food(string name, decimal price) : base(name,price)
        {

        }

        public double Grams { get; set; }
    }
}
