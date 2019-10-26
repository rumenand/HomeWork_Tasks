using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rabbits
{
    public class Cage
    {
        List<Rabbit> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => this.data.Count; }

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity) data.Add(rabbit);
        }

        public bool RemoveRabbit(string name)
        {
            var index = data.FindIndex(x => x.Name == name);
            if (index>-1)
            {
                data.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x=>x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = data.Where(x => x.Name == name).FirstOrDefault();
            if (rabbit != null) rabbit.Available = false;
            return rabbit;
        }

        public Rabbit [] SellRabbitsBySpecies(string species)
        {
            var result = data.Where(x => x.Species == species);
            foreach (var rabbit in result)
            {
                rabbit.Available = false;
            }
            return result.ToArray();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var result = this.data.Where(x => x.Available == true);
            sb.Append($"Rabbits available at {this.Name}:");
            sb.Append(Environment.NewLine);            
            sb.Append(string.Join(Environment.NewLine, result));
            return sb.ToString();
        }
    }
}
