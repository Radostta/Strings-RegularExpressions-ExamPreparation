using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchHexaDecimalNumbers
{
    class MatchHexaDecimalNumbers
    {
        static void Main(string[] args)
        {
            string regexPattern = @"\b(?:0x)?[0-9A-F]+\b";

            string input = Console.ReadLine();

            var matchedNumbers = Regex.Matches(input, regexPattern);

            var validHexNumbers = matchedNumbers.Cast<Match>().Select(a => a.Value).ToArray();

            Console.WriteLine(string.Join(" ", validHexNumbers));

            
        }
    }
}
