using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите длину стороны огорода и длину верёвки в метрах через пробел:");
            double[] inputData = ConvertInput(Console.ReadLine());
            double lengthSquare = inputData[0];
            double lengthRope = inputData[1];
            double squareGarden = 0;
            if (lengthRope <= lengthSquare / 2)
                squareGarden = Math.PI * lengthRope * lengthRope;
            if (lengthRope >= lengthSquare / 2 / Math.Cos(Math.PI / 4))
                squareGarden = lengthSquare * lengthSquare;
            if ((lengthRope > lengthSquare / 2) && (lengthRope < lengthSquare / 2 / Math.Cos(Math.PI / 4)))
            {
                double alfa = 0;
                double squareSegmentRing = 0.0;
                alfa = 2 * Math.Acos((lengthSquare / 2) / lengthRope);
                squareSegmentRing = lengthRope * lengthRope*(alfa - Math.Sin(alfa))/2;
                squareGarden = Math.PI * lengthRope * lengthRope - 4 * squareSegmentRing;
            }
            squareGarden = Math.Round(squareGarden, 3);
            //Console.WriteLine("Козел съест траву в площади:");
            Console.WriteLine(squareGarden);
            //Console.ReadKey();
        }
        
        public static double[] ConvertInput(string userInput)
        {
            string[] inputData = userInput.Split(' ');
            double[] outputData = new double[2];
            outputData[0] = double.Parse(inputData[0]);
            outputData[1] = double.Parse(inputData[1]);
            return outputData;
        }
    }
}
