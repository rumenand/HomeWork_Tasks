using System;

namespace _3ShoppingSpree
{
    public class Product
    {
        private string name;
        public decimal Cost { get; set; }

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

    }
}
