using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base (name,weight,wingSize)
        {
            this.AcceptedFood = new string[]{ "Vegetable", "Fruit", "Meat", "Seeds" };
        }
        protected override string[] AcceptedFood { get; set; }

        public override void Feed(Food food)
        {
            if (this.IsAcceptable(food))
                this.Weight += food.Quantity * 0.35;
        }

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
