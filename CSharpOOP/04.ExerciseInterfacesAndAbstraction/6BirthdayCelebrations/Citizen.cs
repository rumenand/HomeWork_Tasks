using System;

namespace _6BirthdayCelebrations
{
    public class Citizen : IID, IBirthtable
    {
        public Citizen(string name, int age, string id, DateTime birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDay = birthday;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
