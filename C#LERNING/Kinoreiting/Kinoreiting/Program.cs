using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoreiting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Рейтинг X , Понизить не более Y , Оценили N:");
            double[] data = new double[3];
            data = ConvertInput(Console.ReadLine());
            double x = data[0], y = data[1];
            int n = (int) (data[2]);
            //x = 9.5; y = 2; n = 12;
            double count = 0;
            //double y1 = Math.Round(y); /// 2.04 -> 2.00 
            //double y1 = Math.Round(y);
            double xx = y*10 % 10;
            double r = r = (x * n + count) / (n + count);

            /*
             if ((y >= x) || (y==1))
                 Console.WriteLine("Impossible");
             else
             {
                 y = y + 0.04444444;
                 count = n * (y - x) / (1 - y);

                 if (xx <5)
                     count = Math.Truncate(count);
                 else
                     count = Math.Truncate(count)+1;

                 //count = (int)count;
                 count = Math.Truncate(count) + 1;

                 r = (x * n + count) / (n + count);
                 r = Math.Round(r, 1, MidpointRounding.AwayFromZero);
                 //if (count>0)
                 //double score  = x

                 Console.WriteLine(count);
             }
            */
                while (y < r)
                {
                    count++;
                    r = (x * n + count) / (n + count);
                    r = Math.Round(r, 1, MidpointRounding.AwayFromZero);
                }
                Console.WriteLine(count);
            }
            //Console.ReadKey();
        

        public static double[] ConvertInput(string userInput)
        {
            string[] inputData = userInput.Split(' ');
            double[] outputData = new double[inputData.Length];
            int k = 0;
            foreach (string i in inputData)
            {
                outputData[k] = double.Parse(i);
                k++;
            }
            return outputData;
        }

    }
}
