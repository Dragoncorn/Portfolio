using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoot
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine( ShouldFire( true, "boss", 60));
            Console.ReadKey();
        }

        static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            return (enemyInFront && (enemyName == "boss") && (robotHealth >= 50));

        }
        static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
        {
            bool shouldFire = true;
            if (enemyInFront == true)
            {
                if (enemyName == "boss")
                {
                    if (robotHealth < 50) shouldFire = false;
                    if (robotHealth > 100) shouldFire = true;
                }
            }
            else
            {
                return false;
            }
            return shouldFire;
        }
    }
}
