
namespace Animals
{
    public class Cat : Animal
    {        
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public Cat(string name, int age):base(name,age)
        {

        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}
