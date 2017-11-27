using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexmon
{
    class Regexmon
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string didiRegex = @"([^A-Za-z-]+)";
            string bojoRegex = @"([A-Za-z]+)\-([A-Za-z]+)";

            while (true)
            {
                var didiMatch = Regex.Match(text, didiRegex);
              
                if (didiMatch.Success)
                {
                    Console.WriteLine(didiMatch.Value);
                    text = text.Substring(text.IndexOf(didiMatch.Value) + didiMatch.Value.Length);
                }
                else
                {
                    break;
                }

                var bojoMatch = Regex.Match(text, bojoRegex);

                if (bojoMatch.Success)
                {
                    Console.WriteLine(bojoMatch.Value);
                    text = text.Substring(text.IndexOf(bojoMatch.Value) + bojoMatch.Value.Length);
                }
                else
                {
                    break;
                }                
            }
        }
    }
}
