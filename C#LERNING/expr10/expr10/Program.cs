using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Итого: "+CalculateSum(1000));
            Console.ReadLine();
        }
        
        public static int CalculateSum(int number)
        {
            int sum = 0;
            for (int i=1; i<=number; i++)
            {
                Console.WriteLine(i);
                if (CalculateDiv3(i) == true)
                {
                    sum = sum + i;
                    Console.WriteLine(i+"- кратно 3");
                    i++;
                }
                    
                if (CalculateDiv5(i) == true)
                {
                    sum = sum + i;
                    Console.WriteLine(i + "- кратно 5");
                }


            }
            return sum;
        }

        public static bool CalculateDiv3(int number)
        {
            if ((number % 3) == 0)
                return true;
            else
                return false;
        }
        public static bool CalculateDiv5(int number)
        {
            if ((number % 5) == 0)
                return true;
            else
                return false;

        }
    }
}
