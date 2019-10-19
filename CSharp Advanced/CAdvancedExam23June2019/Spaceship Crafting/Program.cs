using System;
using System.Collections.Generic;
using System.Linq;

namespace Spaceship_Crafting
{
    class AdvancedItems
    {
        public string Name { get; }
        public int Value { get; }

        public AdvancedItems(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }       

        public override int GetHashCode()
        {
            return this.Value.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            AdvancedItems other = obj as AdvancedItems;
            if (other == null) return false;
            else if (this.Value == other.Value) return true;
            return false;
        }
    }
    class Program
    {
        static void Main()
        {
            var chemical = new Queue<int>(getIntegerInput());
            var physical = new Stack<int>(getIntegerInput());
            var materials = setAdvancedItems();
            while (chemical.Count > 0 && physical.Count > 0)
            {
                var sum = chemical.Dequeue() + physical.Peek();
                var checkedItem = new AdvancedItems("", sum);
                if (materials.ContainsKey(checkedItem))
                {
                    materials[checkedItem]++;
                    physical.Pop();
                }
                else physical.Push(physical.Pop() + 3);
            }

            if (materials.All(x => x.Value > 0)) Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            else Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            Console.Write("Liquids left: ");
            Console.WriteLine((chemical.Count == 0) ? "none" : string.Join(", ", chemical));
            Console.Write("Physical items left: ");
            Console.WriteLine((physical.Count == 0) ? "none" : string.Join(", ", physical));
            foreach (var item in materials.OrderBy(x => x.Key.Name))
            {
                Console.WriteLine($"{item.Key.Name}: {item.Value}");
            }
        }

        private static Dictionary<AdvancedItems, int> setAdvancedItems()
        {
            var list = new Dictionary<AdvancedItems, int>();
            list.Add(new AdvancedItems("Glass", 25), 0);
            list.Add(new AdvancedItems("Aluminium", 50), 0);
            list.Add(new AdvancedItems("Lithium", 75), 0);
            list.Add(new AdvancedItems("Carbon fiber", 100), 0);
            return list;
        }

        private static IEnumerable<int> getIntegerInput()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}