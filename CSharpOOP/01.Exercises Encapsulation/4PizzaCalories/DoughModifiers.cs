using System;
using System.Collections.Generic;

namespace _4PizzaCalories
{
    class DoughModifiers
    {
        private Dictionary<string,double> listTypes;
        private Dictionary<string, double> listBakes;

        public DoughModifiers()
        {
            listTypes = new Dictionary<string, double>();
            listBakes = new Dictionary<string, double>();
            listTypes.Add("white", 1.5);
            listTypes.Add("wholegrain", 1);
            listBakes.Add("chewy", 1.1);
            listBakes.Add("crispy", 0.9);
            listBakes.Add("homemade", 1);
        } 

        internal double GetTypeValue(string value)
        {
            if (this.listTypes.ContainsKey(value)) return this.listTypes[value];
            return -1;
        }

        internal double GetBakeValue(string value)
        {
            if (this.listBakes.ContainsKey(value)) return this.listBakes[value];
            return -1;
        }
    }
}
