
namespace MilitaryElite
{
    public class Mission
    {
        public Mission(string name, string state)
        {
            this.CodeName = name;
            this.State = state;
        }
        public string CodeName { get;}
        public string State { get; set; }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
