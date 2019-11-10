using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Private[] privates)
            : base(id,firstName,lastName,salary)
        {
            this.ListPrivates = privates;
        }
        public Private[] ListPrivates { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in ListPrivates)
            {
                sb.Append($"  {item.ToString()}");
                sb.Append(Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
    }
}

