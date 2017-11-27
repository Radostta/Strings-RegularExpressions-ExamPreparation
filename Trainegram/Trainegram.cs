using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainegram
{
    class Trainegram
    {
        static void Main(string[] args)
        {
            string pattern = @"^(<\[[^a-zA-Z0-9]*?\]\.)(\.\[[0-9A-Za-z]*?\]\.)*?$";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            while (input != "Traincode!")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
