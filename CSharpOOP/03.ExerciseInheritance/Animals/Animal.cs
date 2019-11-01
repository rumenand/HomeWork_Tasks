using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
       
        public Animal(string name, int age, string gender)
        {            
            this.Name = name;
            this.Age = age;
            this.Gender = gender;       
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Invalid input!");
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0) throw new ArgumentException("Invalid input!");
                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Invalid input!");
                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append(Environment.NewLine);
            sb.Append($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(Environment.NewLine);
            sb.Append(this.ProduceSound());
            return sb.ToString();
        }
    }
}
