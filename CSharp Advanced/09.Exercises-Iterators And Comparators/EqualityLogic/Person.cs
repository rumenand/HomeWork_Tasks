using System;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other == null) return false;
            else  if (this.Name == other.Name && this.Age == other.Age) return true;
            return false;
        }

        public override int GetHashCode()
        {
            string combined = this.Name + "|" + this.Age.ToString();
            return combined.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0) result = this.Age.CompareTo(other.Age);
            return result;
        }
    }
}
