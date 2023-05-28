using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1oleni
{
    class Program
    {
        static void Main() 
        {
            int[] a = new int[3];
            a = ConvertInput(Console.ReadLine());
            if ((a[0] % a[1]) == 0)
                Console.WriteLine(a[0] / a[1] * a[2] + " " + a[0] / a[1] * a[2]);
            else
            {
                int one = 0;
                double two = 0;
                one = a[0] / a[1] * a[2];
                two = (a[0] / a[1]+1)* a[2];
                Console.WriteLine(one + " " + Math.Round(two,6));
            }
                
        }

        public static int[] ConvertInput(string userInput)
        {
            string[] inputData = userInput.Split(' ');
            int[] outputData = new int[inputData.Length];
            int k = 0;
            foreach (string i in inputData)
            {
                outputData[k] = int.Parse(i);
                k++;
            }
            return outputData;
        }
    }
}
