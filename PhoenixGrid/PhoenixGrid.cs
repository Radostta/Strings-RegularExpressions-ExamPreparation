using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoenixGrid
{
    class PhoenixGrid
    {
        static void Main(string[] args)
        {
            var pattern = new Regex(@"^([^\s_]{3})(\.[^\s_]{3})*$");

            string input = Console.ReadLine();

            while (input != "ReadMe")
            {
                if (pattern.IsMatch(input))
                {
                    if (IsPalindrome(input))
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                else
                {
                    Console.WriteLine("NO");

                }

                input = Console.ReadLine();
            }            
        }

        static bool IsPalindrome(string phrase)
        {         
            for (int i = 0; i < phrase.Length / 2; i++)
            {
                if (phrase[i] != phrase[phrase.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
