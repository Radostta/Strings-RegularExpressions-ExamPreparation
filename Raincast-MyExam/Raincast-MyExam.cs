using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Raincast_MyExam
{
    class Raincast_MyExam
    {
        static void Main(string[] args)
        {
            string typePattern = "^Type: (Normal|Warning|Danger)$";
            string sourcePattern = "^Source: ([a-zA-Z0-9]+)$";
            string forecastPattern = "^Forecast: ([^!.,?]+)$";
            
            List<string> raincasts = new List<string>();
            
            string inputLine = string.Empty;            
            string currentLine = "type";
            
            string currentRainCast = string.Empty;

            while ((inputLine = Console.ReadLine()) != "Davai Emo")
            {            
                switch (currentLine)
                {
                    case "type":                        
                        if (Regex.IsMatch(inputLine, typePattern))
                        {                            
                            currentRainCast = $"({Regex.Match(inputLine, typePattern).Groups[1]})";
                            currentLine = "source";
                        }                   
                        break;

                    case "source":                       
                        if (Regex.IsMatch(inputLine, sourcePattern))
                        {                           
                            currentRainCast += " " + "***" + " ~ " + $"{Regex.Match(inputLine, sourcePattern).Groups[1]}";
                            currentLine = "forecast";
                        }
                        break;

                    case "forecast":                        
                        if (Regex.IsMatch(inputLine, forecastPattern))
                        {                            
                            //Replacing "***" with forecast's Value:                           
                            currentRainCast = currentRainCast.Replace("***", Regex.Match(inputLine, forecastPattern).Groups[1].Value);
                            raincasts.Add(currentRainCast);
                            currentLine = "type";
                        }
                        break;
                }
            }
     
            foreach (var raincast in raincasts)
            {
                Console.WriteLine(raincast);
            }
        }
    }
}
