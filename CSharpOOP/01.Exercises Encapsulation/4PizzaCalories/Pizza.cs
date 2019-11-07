using System;
using System.Collections.Generic;

namespace _4PizzaCalories
{
    public class Pizza
    {
        private List<Topping> topping;
        private Dough dough;
        private string name;

        public Pizza(string name)
        {
            this.Name = name;
            this.topping = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 1 || value.Length >15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }       
        
        public void AddTopping(Topping topping)
        {
            if (this.topping.Count == 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            this.topping.Add(topping);
        }

        public double GetCalories()
        {
            double result = 0;
            result = this.dough.GetCalories();
            this.topping.ForEach(x=>result += x.GetCalories());
            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetCalories():F2} Calories.";
        }
    }
}
