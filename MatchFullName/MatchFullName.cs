using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string regexPattern = @"\b[A-Z][a-z]+["" ""][A-Z][a-z]+\b";

            var matchedNames = Regex.Matches(names, regexPattern);

            List<string> result = new List<string>();
            foreach (Match name in matchedNames)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }
    }
}
