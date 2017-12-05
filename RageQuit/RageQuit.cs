using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([^0-9]+)([0-9]+)");
            string input = Console.ReadLine();

            StringBuilder message = new StringBuilder();

            MatchCollection inputParts = regex.Matches(input);

            foreach (Match part in inputParts)
            {
                string text = part.Groups[1].Value.ToUpper();
                int repeat = int.Parse(part.Groups[2].Value);                

                for (int i = 0; i < repeat; i++)
                {
                    message.Append(text);
                }
            }
            
            int uniqueSymbolsCount = message.ToString().Distinct().Count();            

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine(message);
        }
    }
}
