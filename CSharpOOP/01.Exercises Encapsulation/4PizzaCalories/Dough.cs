using System;

namespace _4PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Chewy = 1.1;
        private const double Crispy = 0.9;
        private const double Homemade = 1.0;
        private int weight;
        private double typeModifier;
        private double bakeModifier;

        public Dough(string flour, string bakingTech, int weight)
        {
            this.Flour = flour;
            this.BakingTechn = bakingTech;
            this.Weight = weight;            
        }

        private string Flour
        {
            set
            {
                var type = GetTypeValue(value);
                if (type != 0) this.typeModifier = type;
                else throw new ArgumentException("Invalid type of dough.");                
            }
        }

        private double GetTypeValue(string v)
        {
            switch(v.ToLower())
            {
                case "white": return White;
                case "wholegrain": return Wholegrain;
                case "chewy": return Chewy;
                case "crispy": return Crispy;
                case "homemade": return Homemade;
                default: return 0;
            }
        }

        private string BakingTechn
        {
            set
            {
                var type = GetTypeValue(value);
                if (type != 0) this.bakeModifier = type;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }

        private int Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            return this.weight * 2*bakeModifier*typeModifier;
        }
    }
}
