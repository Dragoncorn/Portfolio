using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brus
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Брус a:");
                var a = int.Parse(Console.ReadLine());
                Console.WriteLine("Брус b:");
                var b = int.Parse(Console.ReadLine());
                Console.WriteLine("Брус c:");
                var c = int.Parse(Console.ReadLine());
                Console.WriteLine("Отверстие d:");
                var d = int.Parse(Console.ReadLine());
                Console.WriteLine("Отверстие e:");
                var e = int.Parse(Console.ReadLine());
                if (IsRight(a,b,c,d,e))
                    Console.WriteLine("Брус пройдет");
                else
                    Console.WriteLine("Брус НЕ пройдет");
            }
        }

        public static bool IsRight(int a, int b, int c, int d, int e)
        {
            return ((d >= a) && ( e >= b)) ||
                    ((d >= c) && ( e >= a )) ||
                    ((d >= b) && ( e >= c )) ||
                    ((d >= a) && ( e >= c )) ||
                    ((d >= c) && ( e >= b )) ||
                    ((d >= b) && ( e >= a ));
        }
    }
}
