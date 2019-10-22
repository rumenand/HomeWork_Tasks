using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class ValuableItem
    {
        public string Name { get; set; }
        public long Value { get; set; }

        public ValuableItem(string name, long value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
