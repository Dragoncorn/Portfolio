// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System.Drawing;
using System;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            var randomXY = new Random(seed);
            var randomDirection = new Random(2);
            double x = 1, y = 0;

            //var dir = 1;
            for (int i = 0; i <= iterationsCount; i++)
            {
                pixels.SetPixel(x, y);
                var xx = x; var yy = y;
                var dir = randomDirection.Next(2);
                x = GetNewX(dir,xx,yy);
                y = GetNewY(dir, xx, yy);
            }
        }

        public static double GetNewX(int direction, double x, double y)
        {
            if (direction == 0)
                return (x * Math.Cos(Math.PI / 4) - y * Math.Sin(Math.PI / 4)) / Math.Sqrt(2);
            else
                return (x * Math.Cos(Math.PI / 4*3) - y * Math.Sin(Math.PI / 4*3)) / Math.Sqrt(2)+1;
        }

        public static double GetNewY(int direction, double x, double y)
        {
            if (direction == 0)
                return (x * Math.Sin(Math.PI / 4) + y * Math.Cos(Math.PI / 4)) / Math.Sqrt(2);
            else
                return (x * Math.Sin(Math.PI / 4 * 3) + y * Math.Cos(Math.PI / 4 * 3)) / Math.Sqrt(2);
        }
    }
}