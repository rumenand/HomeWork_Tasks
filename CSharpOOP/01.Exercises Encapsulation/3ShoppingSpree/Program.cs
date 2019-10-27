using System;
using System.Collections.Generic;
using System.Linq;

namespace _3ShoppingSpree
{
    class Program
    {
        static void Main()
        {
            List<Person> people;
            List<Product> products;
            try
            {
                people = new List<Person>(Console.ReadLine()
                .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split("=")).Select(x => new Person(x[0], decimal.Parse(x[1]))));
                products = new List<Product>(Console.ReadLine()
                .Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split("=")).Select(y => new Product(y[0], decimal.Parse(y[1]))));
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                var curPerson = people.Where(x => x.Name == tokens[0]).FirstOrDefault();
                var curProduct = products.Where(x => x.Name == tokens[1]).FirstOrDefault();
                if (curProduct != null && curPerson != null)
                {
                    if (curProduct.Cost > curPerson.Money)
                    {
                        Console.WriteLine($"{curPerson.Name} can't afford {curProduct.Name}");
                        continue;
                    }
                    else
                    {
                        curPerson.BagOfProducts.Add(curProduct);
                        curPerson.Money -= curProduct.Cost;
                        Console.WriteLine($"{curPerson.Name} bought {curProduct.Name}");
                    }
                }
            }
            foreach (var person in people)
            {
                var result = (person.BagOfProducts.Any()) ? string.Join(", ", person.BagOfProducts.Select(x=>x.Name))
                    : "Nothing bought";
                Console.WriteLine($"{person.Name} - {result}");
            }

        }        
    }
}
