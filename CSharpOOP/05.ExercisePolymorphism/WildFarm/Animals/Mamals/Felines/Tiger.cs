
using WildFarm.Foods;

namespace WildFarm.Animals.Mamals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.AcceptedFood = new string[] { "Meat"};
        }

        protected override string[] AcceptedFood { get; set; }

        public override void Feed(Food food)
        {
            if (this.IsAcceptable(food))
                this.Weight += food.Quantity * 1.00;
        }

        public override string MakeSound()
        {
            return "ROAR!!!";
        }
    }
}
