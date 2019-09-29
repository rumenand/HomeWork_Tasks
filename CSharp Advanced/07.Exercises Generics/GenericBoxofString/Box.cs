using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T>
    {
        private T Value;

        public Box ( T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value.ToString()}";
        }
    }
}
