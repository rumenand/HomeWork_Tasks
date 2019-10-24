using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;
        public string Name { get; set; }

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return this.products.Sum(x => x.Calories);
        }

        public int GetProductCount()
        {
            return this.products.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {GetProductCount()} products:");
            sb.Append(Environment.NewLine);
            sb.Append(string.Join(Environment.NewLine, this.products));               
            return sb.ToString();
        }
    }
}
