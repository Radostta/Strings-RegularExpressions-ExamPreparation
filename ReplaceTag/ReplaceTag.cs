using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceTag
{
    class ReplaceTag
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var regex = @"<a.*?href.*?=(.*)>(.*?)<\/a>";

                var replacement = @"[URL href=$1]$2[/URL]";

                var text = Regex.Replace(input, regex, replacement);

                Console.WriteLine(text);

                input = Console.ReadLine();
            }
        }
    }
}
