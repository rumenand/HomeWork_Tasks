using System;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Fins { get; set; }

        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Fish: {this.Name}");
            sb.Append(Environment.NewLine);
            sb.Append($"Color: {this.Color}");
            sb.Append(Environment.NewLine);
            sb.Append($"Number of fins: {this.Fins}");
            return sb.ToString();
        }        
    }
}
