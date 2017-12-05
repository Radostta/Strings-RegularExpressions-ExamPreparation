using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wormhole
{
    class Wormhole
    {
        static void Main(string[] args)
        {
            var wormholes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int steps = 0;

            for (int i = 0; i < wormholes.Length; i++)
            {
                if (wormholes[i] == 0)
                {
                    steps++;
                    continue;
                }
                
                int index = wormholes[i];                
                wormholes[i] = 0;
                i = index - 1;
            }

            Console.WriteLine(steps); ;
        }
    }
}
