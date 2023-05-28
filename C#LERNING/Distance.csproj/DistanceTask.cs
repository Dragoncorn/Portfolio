using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{   
            double xa = GetLengthSegment(x, y, ax, ay);
            double xb = GetLengthSegment(x, y, bx, by);
            double ab = GetLengthSegment(ax, ay, bx, by);
            double p = (xa + xb + ab) / 2; // Полупериметр
            double squareTriangle = Math.Sqrt(p * (p - xa) * (p - xb) * (p - ab));
            if ((xa * xa > xb * xb + ab * ab) || (xb * xb > xa * xa + ab * ab) || (ax == bx && ay == by) )
                return Math.Min(GetLengthSegment(x, y, ax, ay), GetLengthSegment(x, y, bx, by));
            else
                return 2 * squareTriangle / ab;
        }

        public static double GetLengthSegment(double x, double y, double ax, double ay)
        {
            return Math.Sqrt((x-ax)*(x-ax)+(y-ay)*(y-ay));
        }
    }    
}