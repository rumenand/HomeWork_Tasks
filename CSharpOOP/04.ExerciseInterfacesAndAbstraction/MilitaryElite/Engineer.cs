using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corp, IEnumerable<string> repairs ) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.Repairs = GetRepairs(repairs);
        }      

        public List<Repair> Repairs 
        { 
            get => this.repairs;
            private set => this.repairs = value; 
        }

        private List<Repair> GetRepairs(IEnumerable<string> repairs)
        {
            var data = repairs.ToArray();
            var listSelected = new List<Repair>();
            for (int i = 0; i < data.Length - 1; i +=2)
            {               
                listSelected.Add(new Repair(data[i], int.Parse(data[i + 1])));                
            }
            return listSelected;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var item in Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
