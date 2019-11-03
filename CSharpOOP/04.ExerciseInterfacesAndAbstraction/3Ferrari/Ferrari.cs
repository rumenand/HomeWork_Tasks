using System.Text;

namespace _3Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string dirverName)
        {
            this.Model = "488-Spider";
            this.DriverName = dirverName;
        }
        public string Model { get; set; }
        public string DriverName { get; set; }
        public string OnBrakes()
        {
            return "Brakes!";
        }

        public string OnGasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Model);
            sb.Append("/");
            sb.Append(this.OnBrakes());
            sb.Append("/");
            sb.Append(this.OnGasPedal());
            sb.Append("/");
            sb.Append(this.DriverName);
            return sb.ToString();
        }
    }
}
