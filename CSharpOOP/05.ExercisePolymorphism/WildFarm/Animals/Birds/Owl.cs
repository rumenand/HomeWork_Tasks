
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AcceptedFood = new string[] { "Meat"};
        }
        protected override string[] AcceptedFood { get; set; }

        public override void Feed(Food food)
        {
            if (this.IsAcceptable(food))
                this.Weight += food.Quantity * 0.25;
        }

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }

       
    }
}
