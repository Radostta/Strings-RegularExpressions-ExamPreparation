using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            //string[] bannedWords = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] bannedWords = Regex.Split(Console.ReadLine(), @"\W+");

            string inputText = Console.ReadLine();
            string banWord = "";
            string replacement = "";

            for (int i = 0; i < bannedWords.Length; i++)
            {
                banWord = bannedWords[i];
                replacement = new string('*', banWord.Length);

                inputText = inputText.Replace(banWord, replacement);   

                //If lower/upper case should be ignored:
                //inputText = Regex.Replace(inputText, banWord, replacement, RegexOptions.IgnoreCase);
            }

            Console.WriteLine(inputText);
        }
    }
}
