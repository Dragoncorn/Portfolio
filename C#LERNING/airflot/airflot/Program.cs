using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airflot
{
    class Program
    {
        static void Main()
        {

            string userInput = Console.ReadLine();
            double[] dataFly = ConvertInput(userInput);

            double hight = dataFly[0], timeUpFly = dataFly[1], maxVelocityUpFly = dataFly[2], maxVelocityPassagir = dataFly[3];
            double maxTimeClosedEar = 0;
            double minTimeClosedEar = 0;


            maxTimeClosedEar = СalculateMaxTime(hight, timeUpFly,  maxVelocityUpFly, maxVelocityPassagir);
            minTimeClosedEar = СalculateMinTime(hight, timeUpFly, maxVelocityUpFly, maxVelocityPassagir);
            maxTimeClosedEar = Math.Round(maxTimeClosedEar,6);
            minTimeClosedEar = Math.Round(minTimeClosedEar, 6);

            Console.WriteLine(minTimeClosedEar + " " + maxTimeClosedEar);

            //Console.ReadKey();
        }

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

        public static double СalculateMaxTime(double hight, double timeUpFly, double maxVelocityUpFly, double maxVelocityPassagir)
        {
            double velocityMaxPossible = hight / timeUpFly;
            if (velocityMaxPossible > maxVelocityPassagir)
                return timeUpFly;
            else
                return hight / maxVelocityPassagir;
        }
        
        public static double СalculateMinTime(double hight, double timeUpFly, double maxVelocityUpFly, double maxVelocityPassagir)
        {
            double timeFlyCareful = (hight - maxVelocityUpFly * timeUpFly) / (maxVelocityPassagir - maxVelocityUpFly);
            double minTime = timeUpFly - timeFlyCareful;
            if (minTime < 0)
                return 0;
            else
                return minTime;
        }
        
    }
}
