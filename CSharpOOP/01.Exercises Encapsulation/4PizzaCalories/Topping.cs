using System;

namespace _4PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;
        private double typeValue = 0;
        private int weight = 0;
        private string typeName;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get => this.typeName;
            set
            {
                this.typeName = value;           
                this.typeValue = GetTypeOfModifier(value);
                if (typeValue ==0) throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }        

        private int Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                this.weight = value;
            }                
        }

        public double GetCalories()
        {
            return this.Weight * 2 * this.typeValue;
        }

        private double GetTypeOfModifier(string type)
        {
            switch (type.ToLower())
            {
                case "meat": return Meat;
                case "veggies": return Veggies;
                case "cheese": return Cheese;
                case "sauce": return Sauce;
            }
            return 0;
        }
    }
}
