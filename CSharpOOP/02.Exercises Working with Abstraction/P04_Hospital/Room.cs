
using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        public List<string> Patients { get; set; }

        public Room()
        {
            this.Patients = new List<string>();
        }
    }
}
