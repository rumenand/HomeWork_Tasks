using System;
using System.Linq;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        protected abstract string [] AcceptedFood { get; set; }

        public abstract void Feed (Food food);

        public abstract string MakeSound();
        public bool IsAcceptable(Food food)
        {
            if (!this.AcceptedFood.Contains(food.GetType().Name))
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            this.FoodEaten += food.Quantity;
            return true;
        }
    }
}
