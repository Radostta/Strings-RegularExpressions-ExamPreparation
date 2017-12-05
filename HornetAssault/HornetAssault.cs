using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HornetAssault
{
    class HornetAssault
    {
        static void Main(string[] args)
        {
            var bees = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();
            var hornets = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();
            BigInteger hornetPower = 0;

            //hornetPower = hornets.Sum();

            for (int h = 0; h < hornets.Count; h++)
            {
                hornetPower += hornets[h];
            }

            for (int i = 0; i < bees.Count; i++)
            {
                if (bees[i] < hornetPower)
                {
                    bees[i] -= hornetPower;
                }
                else
                {
                    bees[i] -= hornetPower;

                    if (hornets.Any())
                    {
                        hornetPower -= hornets[0];
                        hornets.RemoveAt(0);
                    }
                }                
            }

            if (bees.Any(x => x > 0))
            {
                Console.WriteLine(string.Join(" ", bees.Where(x => x > 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
