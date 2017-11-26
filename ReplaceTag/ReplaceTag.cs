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
            Regex pattern = new Regex(@"(?:<|\/)?(?<targetStr>a)");                                 

            string input = Console.ReadLine();            

            while (input != "End")
            {
                foreach (Match m in pattern.Matches(input))
                {
                    
                }

               

                Console.WriteLine(input);

                input = Console.ReadLine();
            }            
        }
    }
}
