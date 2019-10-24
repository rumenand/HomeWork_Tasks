using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> salads;
        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.salads = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            this.salads.Add(salad);
        }

        public bool Buy(string name)
        {
            var index = salads.FindIndex(x => x.Name == name);
            if (index > -1)
            {
                salads.RemoveAt(index);
                return true;
            }
            return false;
        }

        public Salad GetHealthiestSalad()
        {
            return salads.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Name} have {this.salads.Count} salads:");
            sb.Append(Environment.NewLine);
            sb.Append(string.Join(Environment.NewLine, this.salads));
            return sb.ToString();
        }
    }
}
