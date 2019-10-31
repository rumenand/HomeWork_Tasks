namespace Animals
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                var args = Console.ReadLine().Split();
                Animal newType = null;
                try
                {
                    newType = AnimalFactory.CreateAnimal(type, args);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
              if (newType != null) Console.WriteLine(newType);
            }
            
        }
    }
}
