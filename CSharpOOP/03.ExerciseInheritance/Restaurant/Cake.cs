
namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams,calories)
        {

        }
        public Cake(string name) : base(name,5m,250,1000)
        {
            
        }

        public Cake(string name, decimal price) : base(name,price,250,1000)
        {

        }

        
    }
}
