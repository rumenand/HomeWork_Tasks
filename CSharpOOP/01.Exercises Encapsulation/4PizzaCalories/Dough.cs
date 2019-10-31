using System;

namespace _4PizzaCalories
{
    public class Dough
    {
        private DoughModifiers doughTypes;
        private int weight;
        private double typeModifier;
        private double bakeModifier;

        public Dough(string flour, string bakingTech, int weight)
        {
            doughTypes = new DoughModifiers();
            this.Flour = flour;
            this.BakingTechn = bakingTech;
            this.Weight = weight;            
        }

        private string Flour
        {            
            set
            {
                var type = doughTypes.GetTypeValue(value.ToLower());
                if (type != -1) this.typeModifier = type;
                else throw new ArgumentException("Invalid type of dough.");                
            }
        }

        private string BakingTechn
        {
            set
            {
                var type = doughTypes.GetBakeValue(value.ToLower());
                if (type != -1) this.bakeModifier = type;
                else throw new ArgumentException("Invalid type of dough");
            }
        }

        private int Weight
        {
            set
            {
                if (value < 0 || value > 200)
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
