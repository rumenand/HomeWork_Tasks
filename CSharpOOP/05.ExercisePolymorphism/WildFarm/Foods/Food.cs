using System;
using System.Linq;

namespace WildFarm.Foods
{
    public abstract class Food
    {
        public Food(int qty)
        {
            this.Quantity = qty;
        }
        public int Quantity { get; set; }
       
    }
}
