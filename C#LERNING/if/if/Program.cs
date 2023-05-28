/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
class HelloWorld
{

    public static void Main()
    {
        Console.WriteLine(MiddleOf(5, 0, 100)); // => 5
        Console.WriteLine(MiddleOf(12, 12, 11)); // => 12
        Console.WriteLine(MiddleOf(1, 1, 1)); // => 1
        Console.WriteLine(MiddleOf(2, 3, 2));
        Console.WriteLine(MiddleOf(8, 8, 8));
        Console.WriteLine(MiddleOf(5, 0, 1));
        Console.WriteLine(MiddleOf(16, 56, 7));

        //FinalTesting(); // Тестирование решения на секретных тестах
    }
    public static int MiddleOf(int a, int b, int c)
    {
        if ((a == b) && (b == c) && (a == c)) return a;
        if ((a == b) || (a == c)) return a;
        else if ((b == c) || (a == c)) return c;
        else if ((c == a) || (b == a)) return b;

        // выясним среднее ли число 
        if ((a > b) && (a < c)) return a;
        else if ((b > a) && (b < c)) return b;
        else return c;


    }


}
