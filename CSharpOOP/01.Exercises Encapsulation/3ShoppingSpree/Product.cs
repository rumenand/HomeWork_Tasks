using System;

namespace _3ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;      

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public decimal Cost
        {
            get { return cost; }
            private set 
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");
                this.cost = value; 
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }

    }
}
