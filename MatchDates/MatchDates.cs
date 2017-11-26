using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchDates
{
    class MatchDates
    {
        static void Main(string[] args)
        {
            string regexPattern = @"\b(?<day>\d{2})([-\/.])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            //Changing backreference index from 2 to 1, as in C# a named group is not counted as a backreference

            string datesInput = Console.ReadLine();

            var matchedDates = Regex.Matches(datesInput, regexPattern);

            foreach (Match date in matchedDates)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;               

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
