using System;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corp;
        }
        public string Corps
        {
            get => this.corps;
            set
            {
                if (value == "Airforces" || value == "Marines") this.corps = value;
                else throw new ArgumentException("Invalid corps!");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            return sb.ToString().Trim();
        }

    }
}
