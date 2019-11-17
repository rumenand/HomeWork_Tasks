using WildFarm.Foods;
namespace WildFarm.Animals.Mamals
{
    public class  Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.AcceptedFood = new string[] { "Vegetable", "Fruit"};
        }

        protected override string[] AcceptedFood { get; set; }

        public override void Feed(Food food)
        {
            if (this.IsAcceptable(food))
                this.Weight += food.Quantity * 0.10;
        }

        public override string MakeSound()
        {
            return "Squeak";
        }
    }
}
