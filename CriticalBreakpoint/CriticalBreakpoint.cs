using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CriticalBreakpolong
{
    class CriticalBreakpolong
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> lines = new List<string>();
            long absoluteCriticalRatio = 0;

            while (input != "Break it.")
            {
                long[] coordinates = input.Split().Select(long.Parse).ToArray();
                long x1 = coordinates[0];
                long y1 = coordinates[1];
                long x2 = coordinates[2];
                long y2 = coordinates[3];

                string line = $"Line: [{string.Join(", ", coordinates)}]";
                lines.Add(line);

                long criticalRatio = Math.Abs((x2 + y2) - (x1 + y1));

                if (criticalRatio != 0)
                {
                    if (absoluteCriticalRatio == 0 && criticalRatio != 0)
                    {
                        absoluteCriticalRatio = criticalRatio;
                    }

                    if (criticalRatio != 0 && criticalRatio != absoluteCriticalRatio)
                    {
                        Console.WriteLine("Critical breakpoint does not exist.");
                        return;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            BigInteger criticalBreakpoint = BigInteger.Pow(absoluteCriticalRatio, lines.Count) % lines.Count;

            Console.WriteLine($"Critical Breakpoint: {criticalBreakpoint}");
        }
    }
}
