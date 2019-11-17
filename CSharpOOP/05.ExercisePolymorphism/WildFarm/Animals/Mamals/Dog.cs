using WildFarm.Foods;

namespace WildFarm.Animals.Mamals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            this.AcceptedFood = new string[] { "Meat" };
        }

        protected override string[] AcceptedFood { get; set; }

        public override void Feed(Food food)
        {
            if (this.IsAcceptable(food))
                this.Weight += food.Quantity * 0.40;
        }

        public override string MakeSound()
        {
            return "Woof!";
        }
    }
}
