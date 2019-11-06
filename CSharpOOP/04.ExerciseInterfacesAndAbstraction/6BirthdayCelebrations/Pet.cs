using System;

namespace _6BirthdayCelebrations
{
    public class Pet : IBirthtable
    {
        public Pet(string name, DateTime birthday)
        {
            this.Name = name;
            this.BirthDay = birthday;
        }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
