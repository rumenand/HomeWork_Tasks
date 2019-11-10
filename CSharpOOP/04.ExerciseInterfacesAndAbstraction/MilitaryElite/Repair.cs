
namespace MilitaryElite
{
    public class Repair
    {
        public Repair(string name, int hours)
        {
            this.Name = name;
            this.WorkingHours = hours;
        }
        public string Name { get; set; }
        public int WorkingHours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.WorkingHours}";
        }
    }
}
