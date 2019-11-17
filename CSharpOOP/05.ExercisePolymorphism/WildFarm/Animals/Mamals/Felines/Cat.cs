
using WildFarm.Foods;

namespace WildFarm.Animals.Mamals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.AcceptedFood = new string[] { "Vegetable", "Meat"};
        }

        protected override string[] AcceptedFood { get; set; }

        public override void Feed(Food food)
        {
            if (this.IsAcceptable(food))
                this.Weight += food.Quantity * 0.30;
        }

        public override string MakeSound()
        {
            return "Meow";
        }
    }
}
