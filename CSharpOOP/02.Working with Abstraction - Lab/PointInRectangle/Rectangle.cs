
namespace PointInRectangle
{
    class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;
        public Point TopLeft { get => this.topLeft; }
        public Point BottomRight { get => this.bottomRight; }

        public Rectangle (Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }
        public bool Contains(Point point)
        {
            bool isInHorizontal = this.TopLeft.X <= point.X &&  this.BottomRight.X >= point.X;
            bool isInVertical =  this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;
            bool isInRectangle = isInHorizontal && isInVertical;
            return isInRectangle;
        }
    }
}
