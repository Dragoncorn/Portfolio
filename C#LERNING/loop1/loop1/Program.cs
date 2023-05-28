//Дано целое неотрицательное число N.Найти число, 
//составленное теми же десятичными цифрами, что и N, 
//но в обратном порядке.Запрещено использовать массивы.

//Loops2.Дано N(1 ≤ N ≤ 27). Найти количество трехзначных натуральных чисел, сумма цифр которых равна N.Операции деления(/, %) не использовать.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loop1
{
    class Program
    {
        static void Main()
        {
            //LOOPS1
            /*
            var stringN = Console.ReadLine();
            var intN = int.Parse(stringN);
            int newN=0;
            for(int i =0; i < stringN.Length; i++)
            {
                newN = newN * 10 + intN % 10;
                intN = intN / 10;
                Console.WriteLine(newN);
            }
            */

            //LOOPS2
            /*
            var N = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if ( i+j+k == N )
                        {
                            counter++;
                            Console.WriteLine(counter);
                            Console.WriteLine(i*100+j*10+k);
                        } 
                    }
                }
            }

            */

            //Loops3.Если все числа натурального ряда записать подряд каждую цифру в своей позиции, 
            //    то необходимо ответить на вопрос: какая цифра стоит в заданной позиции N.
            /*
            var N = int.Parse(Console.ReadLine());
            string x="";
            for (int i = 1; i <= N; i++)
            {
                x = x + i;
            }

            Console.WriteLine(x);
            Console.WriteLine(x[N-1]);
            */

            //Loops4. В массиве чисел найдите самый длинный подмассив из одинаковых чисел.



            Console.ReadKey();
            




        }
    }
}
