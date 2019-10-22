using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Bag
    {
        public Dictionary<string,List<ValuableItem>> Items { get; private set; }
        public long totalCapacity { get;set; }

        private long currentAmount;

        public Bag(long capacity)
        {
            this.Items = new Dictionary<string, List<ValuableItem>>();
            this.totalCapacity = capacity;
            this.currentAmount = 0;
        }

        public void TryInsertInBag(string realName, string item, long value)
        {
            bool suitableItem = false;
            if (currentAmount + value <= totalCapacity)
            {
                switch (item)
                {
                    case "Gem":
                        if (!Items.ContainsKey("Gold") || value + GetItemSum(item) > GetItemSum("Gold")) return;
                        suitableItem = true;
                        break;
                    case "Cash":
                        if (!Items.ContainsKey("Gem") || value + GetItemSum(item) > GetItemSum("Gem")) return;
                        suitableItem = true;
                        break;
                    case "Gold":
                        suitableItem = true;
                        break;
                }
                if (suitableItem)
                {
                    if (!Items.ContainsKey(item)) Items.Add(item, new List<ValuableItem>());
                    var index = Items[item].FindIndex(x => x.Name == realName);
                    if (index > -1) Items[item][index].Value += value;
                    else Items[item].Add(new ValuableItem(realName, value));
                    currentAmount += value;
                }
            }
        }        

        public long GetItemSum(string item)
        {
            if (Items.ContainsKey(item)) return Items[item].Sum(x => x.Value);
            return 0;
        }       
    }
}
