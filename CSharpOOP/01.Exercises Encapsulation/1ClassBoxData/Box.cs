using System;

namespace _1ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            if (length <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            if (width <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            if (height <= 0) throw new ArgumentException("Height cannot be zero or negative.");
            this.length = length;
            this.width = width;
            this.height = height;
        }        

        public string SurfaceArea()
        {
            double result = 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
            return $"Surface Area - {result:F2}";
        }

        public string LateralSurface()
        {
            double result = 2 * this.length * this.height + 2*this.width * this.height;
            return $"Lateral Surface Area - {result:F2}";
        }

        public string Volume()
        {
            double result = this.length * this.width * this.height;
            return $"Volume - {result:F2}";
        }
    }
}
