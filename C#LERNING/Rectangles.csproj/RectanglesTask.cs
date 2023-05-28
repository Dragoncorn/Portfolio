using System;
using System.Drawing;

namespace Rectangles
{
	public static class RectanglesTask
	{
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        // public static bool AreIntersected(Rectangle r1, Rectangle r2)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {   
            // Вычислим проекции
            // На ось X
            int leftBorder1Rect = Math.Min(r1.Left, r1.Left + r1.Width);
            int rightBorder1Rect = Math.Max(r1.Left, r1.Left + r1.Width);
            int leftBorder2Rect = Math.Min(r2.Left, r2.Left + r2.Width);
            int rightBorder2Rect = Math.Max(r2.Left, r2.Left + r2.Width);
            // На ось Y
            int upBorder1Rect = Math.Min(r1.Top, r1.Top + r1.Height);
            int downBorder1Rect = Math.Max(r1.Top, r1.Top + r1.Height);
            int upBorder2Rect = Math.Min(r2.Top, r2.Top + r2.Height);
            int downBorder2Rect = Math.Max(r2.Top, r2.Top + r2.Height);
            // пересекаются / не пересекаются 
            bool a = true, b = true;
            if (((leftBorder1Rect <= leftBorder2Rect) && (rightBorder1Rect >= leftBorder2Rect)) ||
                 ((leftBorder1Rect <= rightBorder2Rect) && (rightBorder1Rect >= rightBorder2Rect)) ||
                 ((leftBorder2Rect <= leftBorder1Rect) && (rightBorder2Rect >= leftBorder1Rect)) ||
                 ((leftBorder2Rect <= rightBorder1Rect) && (rightBorder2Rect >= rightBorder1Rect)))
            {
                //Console.Write("Есть пересечение по ОХ ");
                a = true;
            }
            else
            {
                //Console.Write("Нет пересечение по ОХ ");
                a = false;
            }
            if (((upBorder1Rect <= upBorder2Rect) && (downBorder1Rect >= upBorder2Rect)) ||
                 ((upBorder1Rect <= downBorder2Rect) && (downBorder1Rect >= downBorder2Rect)) ||
                 ((upBorder2Rect <= upBorder1Rect) && (downBorder2Rect >= upBorder1Rect)) ||
                 ((upBorder2Rect <= downBorder1Rect) && (downBorder2Rect >= downBorder1Rect)))
            {
                //Console.WriteLine("Есть пересечение по ОY");
                b = true;
            }
            else
            {
                //Console.WriteLine("Нет пересечение по ОY");
                b = false;
            }
            return a && b;
        }

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            int leftBorder1Rect = Math.Min(r1.Left, r1.Left + r1.Width);
            int rightBorder1Rect = Math.Max(r1.Left, r1.Left + r1.Width);
            int leftBorder2Rect = Math.Min(r2.Left, r2.Left + r2.Width);
            int rightBorder2Rect = Math.Max(r2.Left, r2.Left + r2.Width);
            // На ось Y
            int upBorder1Rect = Math.Min(r1.Top, r1.Top + r1.Height);
            int downBorder1Rect = Math.Max(r1.Top, r1.Top + r1.Height);
            int upBorder2Rect = Math.Min(r2.Top, r2.Top + r2.Height);
            int downBorder2Rect = Math.Max(r2.Top, r2.Top + r2.Height);
            int[] arrX = { leftBorder1Rect, rightBorder1Rect, leftBorder2Rect, rightBorder2Rect };
            int[] arrY = { upBorder1Rect, downBorder1Rect, upBorder2Rect, downBorder2Rect };
            if (AreIntersected(r1, r2))
            {
                return SortArrayAndReturnLength(arrX) * SortArrayAndReturnLength(arrY);
            }
            else
                return 0;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            // На ось X
            int leftBorder1Rect = Math.Min(r1.Left, r1.Left + r1.Width);
            int rightBorder1Rect = Math.Max(r1.Left, r1.Left + r1.Width);
            int leftBorder2Rect = Math.Min(r2.Left, r2.Left + r2.Width);
            int rightBorder2Rect = Math.Max(r2.Left, r2.Left + r2.Width);
            // На ось Y
            int upBorder1Rect = Math.Min(r1.Top, r1.Top + r1.Height);
            int downBorder1Rect = Math.Max(r1.Top, r1.Top + r1.Height);
            int upBorder2Rect = Math.Min(r2.Top, r2.Top + r2.Height);
            int downBorder2Rect = Math.Max(r2.Top, r2.Top + r2.Height);
            if (r1 == r2)  // Совпадают
                return 0;
            else
            {
                if (AreIntersected(r1, r2)) // пересикаются
                {                                  // 1 во 2
                    if (((leftBorder1Rect <= leftBorder2Rect) && (rightBorder2Rect <= rightBorder1Rect)) &&
                            ((upBorder1Rect <= upBorder2Rect) && (downBorder2Rect <= downBorder1Rect)))
                        return 1;
                    else if (((leftBorder2Rect <= leftBorder1Rect) && (rightBorder1Rect <= rightBorder2Rect)) &&
                       ((upBorder2Rect <= upBorder1Rect) && (downBorder1Rect <= downBorder2Rect)))
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
        }

        public static int SortArrayAndReturnLength(int[] a)
        {
             int[] array = a;
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            int difference =(array[1] - array[2]);
            return difference;
        }   
    }
}