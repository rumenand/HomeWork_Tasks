using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age):base(name,age)
        {
            base.Name = name;
            this.Age = age;
        }
        public int Age
        {
            get { return base.age; }
            set
            {
                if (value >15) throw new ArgumentException("Child age cannot be more than 15");
                base.age = value;
            }
        }
    }
}
