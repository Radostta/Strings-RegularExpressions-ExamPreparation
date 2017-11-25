using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            var wordReversed = word.ToCharArray().Reverse();

            Console.WriteLine(string.Concat(wordReversed));
        }
    }
}
