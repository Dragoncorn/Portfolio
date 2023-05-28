using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_array
{
    class Program
    {
        /*
        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] subarr = { 5, 6, 7 };
            int kkk= FindSubarrayStartIndex(arr, subarr);
            Console.WriteLine(kkk);
            Console.ReadKey();

        }

        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }

        public static bool ContainsAtIndex(int[] array, int[] subArray, int i)
        {
            bool x = true;
            //for (int j = 0; j < array.Length - subArray.Length + 1; j++)
            //{
                x = true;
                for (int k = 0; k < subArray.Length; k++)
                {
                    x = x && (subArray[k] == array[i + k]);
                }
                //if (x == true) break;
            //}
            return x;
        }*/

        enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }

        public static void Main()
        {
            Console.WriteLine(GetSuit(Suits.Wands));
            Console.WriteLine(GetSuit(Suits.Coins));
            Console.WriteLine(GetSuit(Suits.Cups));
            Console.WriteLine(GetSuit(Suits.Swords));
        }
        private static string GetSuit(Suits suit)
        {
            /*if (suit == Suits.Wands) return "жезлов";
            else if (suit == Suits.Coins) return "монет";
            else if (suit == Suits.Cups) return "кубков";
            else return "мечей";*/

            //return emum. .(var array = new[] { "жезлов", "монет", "кубков","мечей" });
            
           var array = new[] { "жезлов", "монет", "кубков","мечей" } [1];
           var a = new[] { "жезлов", "монет", "кубков", "мечей" } [1];

            return array[(int)suit];
            //suit = array[(int)(suit)];

        }
    }
}
