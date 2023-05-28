using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cross_circle.Program;

namespace Cross_circle
{
    class Program
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");

            Console.WriteLine("End Program");
            Console.ReadKey();
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
        public static GameResult GetGameResult(Mark[,] field)
        {
            //int[][] wComb = new int[8][];
            //wComb[0] = new int[] { 0, 1, 2 };
            //wComb[1] = new int[] { 3, 4, 5 };
            //wComb[2] = new int[] { 6, 7, 8 };
            //wComb[3] = new int[] { 0, 3, 6 };
            //wComb[4] = new int[] { 1, 4, 7 };
            //wComb[5] = new int[] { 2, 5, 8 };
            //wComb[6] = new int[] { 6, 4, 8 };
            //wComb[7] = new int[] { 2, 4, 6 };

            /*
            string[] arrayField = new string[8];
            int k = 0;
            for(int i=0; i<3;i++)
            {
                for (int j=0;j<3;j++)
                {
                    arrayField[k] = "asd" ; // field[i,j];
                }
            }

            Console.WriteLine(wComb[7][0]);
            */
            bool[] wins = new bool[8];

            wins[0] = (field[0, 0] ==  field[0, 1]) && (field[0, 1] == field[0, 2]) && (field[0, 2]!= Mark.Empty);
            wins[1] = (field[1, 0] == field[1, 1]) && (field[1, 1] == field[1, 2]) && (field[1, 2] != Mark.Empty);            
            wins[2] = (field[2, 0] == field[2, 1]) && (field[2, 1] == field[2, 2]) && (field[2, 1] != Mark.Empty);
            
            wins[3] = (field[0, 0] == field[1, 0]) && (field[1, 0] == field[2, 0]) && (field[2, 0] != Mark.Empty);
            wins[4] = (field[0, 1] == field[1, 1]) && (field[1, 1] == field[2, 1]) && (field[2, 1] != Mark.Empty);
            wins[5] = (field[0, 2] == field[1, 2]) && (field[1, 2] == field[2, 2]) && (field[2, 2] != Mark.Empty);
            
            wins[6] = (field[0, 0] == field[1, 1]) && (field[1, 1] == field[2, 2]) && (field[0, 0] != Mark.Empty);
            wins[7] = (field[2, 0] == field[1, 1]) && (field[1, 1] == field[0, 2]) && (field[0, 2] != Mark.Empty);

            //var w9 = w3 || w2 || w3 || w4 || w5 || w6 || w7 || w8;
            //Console.Wr4teLine(w1 + " " + w2 + " " + w3 + " " + w4 + " " + w5 + " " + w6 + " " + w7 + " " + w8);
            //Console.Wr5teLine(1);
            int count = 0;
            int k = 0;
            Mark x = 0;

           foreach (var w in wins) 
           { 
                Console.Write(w + " "); 
                if (w==true)
                {
                    count++;
                }                
           }
            if (count == 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (wins[i] == true)
                    {
                        k = i;
                    }
                }

                switch (k)
                {
                    case 0:
                        x = field[0, 0];
                        break;
                    case 1:
                        x = field[1, 0];
                        break;
                    case 2:
                        x = field[2, 0];
                        break;
                    case 3:
                        x = field[0, 0];
                        break;
                    case 4:
                        x = field[0, 1];
                        break;
                    case 5:
                        x = field[0, 2];
                        break;
                    case 6:
                        x = field[0, 0];
                        break;
                    case 7:
                        x = field[2, 0];
                        break;    
                }

            }
            //Console.WriteLine(x);

            if ((count == 2)||(count == 0))
                return GameResult.Draw;
            else if(x==Mark.Cross)
               return GameResult.CrossWin;
            else 
                return GameResult.CircleWin;
        }

    }
}
