using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchNumbers
{
    class MatchNumbers
    {
        static void Main(string[] args)
        {
            string regexPattern = @"(^|(?<=\s))(-)?(\d+)(\.\d+)?($|(?=\s))";
            // \b will not work in this case, as it includes -, which we need for negative numbers
            //using a positive lookbehind to match either the start of the string, or a space

            string input = Console.ReadLine();

            var matchedNumbers = Regex.Matches(input, regexPattern).Cast<Match>().Select(a => a.Value).ToArray();

            Console.WriteLine(string.Join(" ", matchedNumbers));


        }
    }
}
