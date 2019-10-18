using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        public List<Fish> fishInPool;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }
        private int currentFinsCount;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
            this.currentFinsCount = 0;
        }

        public void Add(Fish fish)
        {
            if (GetIndexOf(fish.Name) < 0 && this.currentFinsCount<this.Size)
            {
                this.currentFinsCount += fish.Fins;
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            int index = GetIndexOf(name);
            if (index > -1)
            {
                fishInPool.RemoveAt(index);
                return true;
            }
            return false;
        }

        public Fish FindFish(string name)
        {
            int index = GetIndexOf(name);
            if (index > -1)
            {               
                return fishInPool[index];
            }
            return null;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.Append("Aquarium Info:");
            sb.Append(Environment.NewLine);
            sb.Append($"Aquarium: {this.Name} ^ Size: {this.Size}");
            sb.Append(Environment.NewLine);
            foreach (var fish in fishInPool)
            {
                sb.Append(fish.ToString());
            }
            return sb.ToString();
        }

        private int GetIndexOf(string name)
        {
            return fishInPool.FindIndex(x => x.Name == name);
        }        
    }
}
