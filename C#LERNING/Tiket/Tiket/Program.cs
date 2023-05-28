using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiket
{
    class Program
    {
        static void Main()
        {
        //while (true)
        //    {
                int number1 = 0, number2 =0;
                string a = Console.ReadLine();
                number1 = ConvertInput(a)+1;
                number2 = ConvertInput(a)-1;
                int[] arrayNumber1 = GetArrayNumber(number1);
                int[] arrayNumber2 = GetArrayNumber(number2);
                if ((IsLuckyTiket(arrayNumber1)) || (IsLuckyTiket(arrayNumber2)))
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }
       // }

        public static int ConvertInput(string userInput)
        {
            int outputData = int.Parse(userInput);
            return outputData;
        }

        public static int[] GetArrayNumber(int number)
        {
            int[] arrayNumber = new int[6];
            for(int i=5;i>=0; i--)
            {
                arrayNumber[i] = number % 10;
                number = number / 10;
            }
            return arrayNumber;
        }
        public static bool IsLuckyTiket(int[] a)
        {
            return ((a[0]+a[1]+a[2])==(a[3]+a[4]+a[5]));
        }
    }
}
