using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahmots
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Начальная позиция:");
                int start = int.Parse(Console.ReadLine());
                Console.WriteLine("Конечная позиция:");
                int finish = int.Parse(Console.ReadLine());
                int startx = start / 10;
                int starty = start % 10;
                int finishx = finish / 10;
                int finishy = finish % 10;
                if (king(startx, starty, finishx, finishy))
                    Console.WriteLine("Король сможет так сходить");
                else
                    Console.WriteLine("Король НЕ сможет так сходить");
                if (elefant(startx, starty, finishx, finishy))
                    Console.WriteLine("Слон сможет так сходить");
                else
                    Console.WriteLine("Слон НЕ сможет так сходить");
                if (rook(startx, starty, finishx, finishy))
                    Console.WriteLine("Ладья сможет так сходить");
                else
                    Console.WriteLine("Ладья НЕ сможет так сходить");
                if ((rook(startx, starty, finishx, finishy)) || (elefant(startx, starty, finishx, finishy)))
                    Console.WriteLine("Ферзь сможет так сходить");
                else
                    Console.WriteLine("Ферзь НЕ сможет так сходить");
                if (horse(startx, starty, finishx, finishy))
                    Console.WriteLine("Конь сможет так сходить");
                else
                    Console.WriteLine("Конь НЕ сможет так сходить");
            }
        }

        public static bool king(int xs, int ys, int xf, int yf)
        {
            if ((xs - 1 == xf) && (ys - 1 == yf))
                return true;
            else if ((xs == xf) && (ys - 1 == yf))
                return true;
            else if ((xs + 1 == xf) && (ys - 1 == yf))
                return true;
            else if ((xs - 1 == xf) && (ys == yf))
                return true;
            else if ((xs + 1 == xf) && (ys == yf))
                return true;
            else if ((xs - 1 == xf) && (ys + 1 == yf))
                return true;
            else if ((xs == xf) && (ys + 1 == yf))
                return true;
            else if ((xs + 1 == xf) && (ys + 1 == yf))
                return true;
            else
                return false;
        }

        public static bool elefant(int xs, int ys, int xf, int yf)
        {
            return Math.Abs(xs - xf) == Math.Abs(ys - yf);
        }

        public static bool rook(int xs, int ys, int xf, int yf)
        {            
            return ((xs != xf) && (ys == yf)) || ((xs == xf) && (ys != yf));
        }

        public static bool horse(int xs, int ys, int xf, int yf)
        {
            if ((xs - 2 == xf) && (ys - 1 == yf))
                return true;
            else if ((xs -1 == xf) && (ys - 2 == yf))
                return true;
            else if ((xs + 1 == xf) && (ys - 2 == yf))
                return true;
            else if ((xs + 2 == xf) && (ys - 1 == yf))
                return true;
            else if ((xs - 2 == xf) && (ys + 1 == yf))
                return true;
            else if ((xs - 1 == xf) && (ys + 2 == yf))
                return true;
            else if ((xs + 1 == xf) && (ys + 2 == yf))
                return true;
            else if ((xs + 2 == xf) && (ys + 1 == yf))
                return true;
            else
                return false;
        }
    }
}
