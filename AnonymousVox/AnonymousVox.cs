using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnonymousVox
{
    class AnonymousVox
    {        
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] placeholders = Console.ReadLine().Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //string[] placeholders = Regex.Split(Console.ReadLine(), @"[{}]").Where(w => w != "").ToArray();
            //string[] placeholders = Regex.Split(Console.ReadLine(), @"\W+").Where(w => w.Length > 0).ToArray();

            string pattern = @"([A-Za-z]+)(.*)(\1)";
            
            MatchCollection textMatches = Regex.Matches(text, pattern);

            int count = 0;
            //counting the placeholder indexes from 0 to end
            //count++ increments the count after each cycle

            foreach (Match item in textMatches)
            {
                //constructing the replacement string:
                string newValue = item.Groups[1].Value + placeholders[count++] + item.Groups[3].Value;

                //replacing the text of each match item:
                text = text.Replace(item.Value, newValue);
            }

            Console.WriteLine(text);
           
            //for replacing the placeholder only, IndexOf can be used
        }
    }
}
