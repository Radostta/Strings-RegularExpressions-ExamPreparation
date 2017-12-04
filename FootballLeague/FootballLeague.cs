using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeague //60/100
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            var originalKey = Console.ReadLine().ToCharArray();
            string key = GetKey(originalKey);

            string input = Console.ReadLine();

            Regex regex = new Regex(key + @"([A-Za-z]+)" + key + @".*" + key + @"([A-Za-z]+)" + key + @".*(\d+):(\d+)");
            
            var teamsScore = new Dictionary<string, BigInteger>();
            var teamsPoints = new Dictionary<string, long>();

            while (input != "final")
            {
                string firstScore, secondScore, firstTeam, secondTeam;
                GetTeamNames(input, regex, out firstScore, out secondScore, out firstTeam, out secondTeam);

                AddTeamsPointsToDictionary(teamsPoints, firstScore, secondScore, firstTeam, secondTeam);                
                AddTeamsScoresToDictionary(teamsScore, firstScore, secondScore, firstTeam, secondTeam);

                input = Console.ReadLine();
            }

            //Printing the results:

            Console.WriteLine("League standings:");

            long count = 1;

            foreach (var team in teamsPoints.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{count}. {team.Key} {team.Value}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in teamsScore.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
            
        }

        // ----------------METHODS-------------------- //

        private static void AddTeamsScoresToDictionary(Dictionary<string, BigInteger> teamsScore, string firstScore, string secondScore, string firstTeam, string secondTeam)
        {
            if (!teamsScore.ContainsKey(firstTeam))
            {
                teamsScore.Add(firstTeam, BigInteger.Parse(firstScore));
            }
            else
            {
                teamsScore[firstTeam] += BigInteger.Parse(firstScore);
            }

            if (!teamsScore.ContainsKey(secondTeam))
            {
                teamsScore.Add(secondTeam, BigInteger.Parse(secondScore));
            }
            else
            {
                teamsScore[secondTeam] += BigInteger.Parse(secondScore);
            }
        }

        private static void AddTeamsPointsToDictionary(Dictionary<string, long> teamsPoints, string firstScore, string secondScore, string firstTeam, string secondTeam)
        {
            var firstTeamPoints = 0;
            var secondTeamPoints = 0;

            if (long.Parse(firstScore) > long.Parse(secondScore))
            {
                firstTeamPoints += 3;
            }
            else if (long.Parse(secondScore) > long.Parse(firstScore))
            {
                secondTeamPoints += 3;
            }
            else if (long.Parse(secondScore) == long.Parse(firstScore))
            {
                firstTeamPoints += 1;
                secondTeamPoints += 1;
            }

            if (!teamsPoints.ContainsKey(firstTeam))
            {
                teamsPoints.Add(firstTeam, firstTeamPoints);
            }
            else
            {
                teamsPoints[firstTeam] += firstTeamPoints;
            }

            if (!teamsPoints.ContainsKey(secondTeam))
            {
                teamsPoints.Add(secondTeam, secondTeamPoints);
            }
            else
            {
                teamsPoints[secondTeam] += secondTeamPoints;
            }
        }

        private static void GetTeamNames(string input, Regex regex, out string firstScore, out string secondScore, out string firstTeam, out string secondTeam)
        {
            var match = regex.Match(input);
            var firstTeamGroup = match.Groups[1].ToString().ToUpper();
            var secondTeamGroup = match.Groups[2].ToString().ToUpper();
            firstScore = match.Groups[3].ToString();
            secondScore = match.Groups[4].ToString();
            var firstTeamName = firstTeamGroup.ToCharArray().Reverse().ToArray();
            var secondTeamName = secondTeamGroup.ToCharArray().Reverse().ToArray();

            firstTeam = string.Join("", firstTeamName);
            secondTeam = string.Join("", secondTeamName);
        }

        private static string GetKey(char[] originalKey)
        {
            string key = "";

            foreach (var letter in originalKey)
            {
                if (letter == '.' || letter == '?' || letter == '+' || letter == '*' || letter == '/' || letter == '[' || letter == ']' || letter == '(' || letter == ')')
                {
                    key += '\\' + letter.ToString();
                }
                else
                {
                    key += letter.ToString();
                }
            }

            return key;
        }
    }
}
