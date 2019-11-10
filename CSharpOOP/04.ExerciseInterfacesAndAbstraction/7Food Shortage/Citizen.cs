using System;

namespace FoodShortage
{
    public class Citizen : IID, IBirthtable, IBuyer
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

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
