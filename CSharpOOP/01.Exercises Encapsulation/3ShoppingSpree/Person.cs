using System;
using System.Collections.Generic;

namespace _3ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            set { bagOfProducts = value; }
        }


        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");
                this.money = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }

        public void AddProduct(Product product)
        {
            this.bagOfProducts.Add(product);
        }
    }
}
