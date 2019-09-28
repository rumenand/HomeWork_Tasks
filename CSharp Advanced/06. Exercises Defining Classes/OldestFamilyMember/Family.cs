using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Family
    {
        private List<Person> listOfpPepople;
        public Family()
        {
            this.listOfpPepople = new List<Person>();
        }

        public void AddMember(Person member)
        {
            listOfpPepople.Add(member);
        }

        public Person GetOldestMember()
        {
            return listOfpPepople.OrderByDescending(x => x.Age).First();
        }
    }
}
