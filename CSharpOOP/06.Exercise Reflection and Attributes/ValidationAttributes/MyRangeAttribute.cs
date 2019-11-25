
namespace ValidationAttributes
{
    using System;
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj.GetType() == typeof(int))
            {
                var value = (int)obj;
                if (value > minValue && value < maxValue)
                {
                    return true;
                }
                return false;
            }
            throw new ArgumentException("Invalid type!");
        }
    }
}
