using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace procens
{
    class Program
    {
        static void Main()
        {

            string userInput;
            userInput=Console.ReadLine();
                       

            Console.WriteLine(Calculate(userInput));
            Console.WriteLine("Done");
            userInput = Console.ReadLine();
        }

        public static double Calculate(string userInput)
        {
            double result = 0, coast = 0, percent = 0, period=0;

            string[] array_string = userInput.Split(' ');
            coast = double.Parse(array_string[0]);
            percent = double.Parse(array_string[1]);
            period = double.Parse(array_string[2]);
            Console.WriteLine("Вклад:"+coast);
            Console.WriteLine("%:"+percent);
            Console.WriteLine("Период:"+period);

             if (period == 1)
                  return result = coast + coast * percent/100/12 ;
               else
            // return result = coast + period * (coast * percent / 100 / 12) + coast *Math.Pow( (percent / 100 / 12) ,period);


            //return result = (coast *(1-Math.Pow(percent/100/12,period)))/(1-percent/100/12) ;
            return result = coast * Math.Pow(1 + percent / 100 / 12, period);        
}
    }


}
