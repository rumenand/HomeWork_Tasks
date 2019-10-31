
namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Product(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
