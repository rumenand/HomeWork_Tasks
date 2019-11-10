
namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base (id,firstName,lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; private set; }

        public virtual string GetName()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }

        public override string ToString()
        {
            return GetName();
        }
    }
}
