using System;
using System.Collections.Generic;
using System.Text;

namespace OldestFamilyMember
{
    class Person
    {
        private string name;
        private int age;

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int number) : this()
        {
            this.age = number;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
