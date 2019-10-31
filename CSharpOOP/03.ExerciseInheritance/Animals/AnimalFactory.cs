using System;
namespace Animals
{
    public class AnimalFactory
    {           
       public static Animal CreateAnimal(string type, string [] args)
       {
           switch(type)
            {
                case "Dog": return new Dog(args[0], int.Parse(args[1]), args[2]);
                case "Cat": return new Cat(args[0], int.Parse(args[1]), args[2]);
                case "Frog": return new Frog(args[0], int.Parse(args[1]), args[2]);
                case "Tomcat":
                    if (args.Length == 3) return new Tomcat(args[0], int.Parse(args[1]), args[2]);
                    else return new Tomcat(args[0], int.Parse(args[1]));                    
                case "Kitten":
                    if (args.Length == 3)  return new Kitten(args[0], int.Parse(args[1]), args[2]);
                    return new Kitten(args[0], int.Parse(args[1]));
                default: throw new ArgumentException("Invalid input!");
            }
       }
        
    }
}
