using System;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : IBrowser, IDialer
    {
        public string Browse(string[] sites)
        {
            var sb = new StringBuilder();
            for (int i=0; i<sites.Length; i++)
            {
                if (sites[i].Any(x=>char.IsDigit(x))) sb.Append("Invalid URL!");
                else sb.Append($"Browsing: {sites[i]}!");
                if (i != sites.Length - 1) sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public string Dial(string[] numbers)
        {
            var sb = new StringBuilder();
            for (int i= 0; i<numbers.Length; i++)
            {
                if (numbers[i].Any(x => char.IsLetter(x))) sb.Append("Invalid number!");
                else sb.Append($"Calling... {numbers[i]}");
                if (i != numbers.Length - 1) sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
