using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HornetComm
{
    class HornetComm
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var privateMessageRegex = @"^([0-9]+) <-> ([A-Za-z0-9]+)$";
            var broadcastRegex = @"^([^0-9]+) <-> ([A-Za-z0-9]+)$";                        

            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            while (input != "Hornet is Green")
            {                
                var privateMessageMatch = Regex.Match(input, privateMessageRegex);
                var broadcastMatch = Regex.Match(input, broadcastRegex);

                if (privateMessageMatch.Success)
                {
                    string recipientCode = privateMessageMatch.Groups[1].ToString();
                    recipientCode = string.Join("", recipientCode.ToCharArray().Reverse().ToArray());
                   
                    messages.Add(recipientCode + " -> " + privateMessageMatch.Groups[2].ToString());                    
                }

                if (broadcastMatch.Success)
                {
                    string frequency = broadcastMatch.Groups[2].ToString();
                    string frequencyResult = "";

                    for (int i = 0; i < frequency.Length; i++)
                    {
                        if (char.IsLower(frequency[i]))
                        {
                            frequencyResult += frequency[i].ToString().ToUpper();
                        }
                        else if (char.IsUpper(frequency[i]))
                        {
                            frequencyResult += frequency[i].ToString().ToLower();
                        }
                        else
                        {
                            frequencyResult += frequency[i].ToString();
                            //case: if char is a digit
                        }
                    }

                    broadcasts.Add(frequencyResult + " -> " + broadcastMatch.Groups[1].ToString());
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");

            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                broadcasts.ForEach(e => Console.WriteLine(e));
            }            

            Console.WriteLine("Messages:");

            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                messages.ForEach(e => Console.WriteLine(e));
            }
            
        }
    }
}
