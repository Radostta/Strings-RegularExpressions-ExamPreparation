using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string regexPattern = @"(^|(?<=\s))[\+][359]+(["" ""-])[2]\1[\d]{3}\1[\d]{4}\b";

            string input = Console.ReadLine();

            var matchedNumbers = Regex.Matches(input, regexPattern);

            var validPhoneNumbers = matchedNumbers.Cast<Match>().Select(a => a.Value.Trim()).ToArray();            

            //List<string> validPhoneNumbers = new List<string>();

            //foreach (Match number in matchedNumbers)
            //{
            //    string validNumber = number.ToString();
            //    validPhoneNumbers.Add(validNumber);
            //}

            Console.WriteLine(string.Join(", ", validPhoneNumbers));
        }
    }
}
