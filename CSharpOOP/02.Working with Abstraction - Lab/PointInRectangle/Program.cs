using System;
using System.Linq;

namespace PointInRectangle
{
    class Program
    {
        static void Main()
        {
            var rectangle = createRectangle();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var checkPoint = createPoint();
                Console.WriteLine(rectangle.Contains(checkPoint));
            }
        }
       
        private static int [] getIntegerData()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        private static Rectangle createRectangle()
        {
            var rectangleData = getIntegerData();
            return new Rectangle(new Point(rectangleData[0], rectangleData[1]),
                                 new Point(rectangleData[2], rectangleData[3]));
        }

        private static Point createPoint()
        {
            var pointData = getIntegerData();
            return new Point(pointData[0], pointData[1]);
        }
    }
}
