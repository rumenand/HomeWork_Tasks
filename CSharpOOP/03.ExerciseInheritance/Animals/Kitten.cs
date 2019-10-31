
namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender) : base(name, age, gender)
        {
            this.Gender = "Female";
        }

        public Kitten(string name, int age):base(name,age)
        {
            this.Gender = "Female";
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
