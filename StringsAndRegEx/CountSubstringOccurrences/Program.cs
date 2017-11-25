using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string targetStr = Console.ReadLine();

            int occurrencesCount = 0;
            int positionOfTargetStr = -1;

            while (true)
            {
                positionOfTargetStr = input.IndexOf(targetStr, positionOfTargetStr + 1, StringComparison.OrdinalIgnoreCase);

                if (positionOfTargetStr == -1)
                {
                    break;
                }
                occurrencesCount++;
            }

            Console.WriteLine(occurrencesCount);
        }
    }
}
