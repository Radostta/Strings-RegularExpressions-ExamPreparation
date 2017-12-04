using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague_SolutionWithSubstring
{
    class FootballLeague_SolutionWithSubstring
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string input = Console.ReadLine();

            var teams = new Dictionary<string, List<long>>(); //List contains teamsPoints at index 0 and teamsScores at index 1

            while (input != "final")
            {
                var inputParts = input.Split(' ');

                //First team:
                var firstTeamDecrypted = inputParts[0];
                int startIndex = firstTeamDecrypted.IndexOf(key);
                int lastIndex = firstTeamDecrypted.LastIndexOf(key);

                string firstTeam = firstTeamDecrypted.Substring(startIndex + key.Length, lastIndex - key.Length - startIndex);
                char[] firstTeamArr = firstTeam.ToUpper().ToCharArray().Reverse().ToArray();
                //Array.Reverse(firstTeamArr);
                firstTeam = new string(firstTeamArr);

                //Second team:
                var secondTeamDecrypted = inputParts[1];
                startIndex = secondTeamDecrypted.IndexOf(key);
                lastIndex = secondTeamDecrypted.LastIndexOf(key);

                string secondTeam = secondTeamDecrypted.Substring(startIndex + key.Length, lastIndex - key.Length - startIndex);
                char[] secondTeamArr = secondTeam.ToUpper().ToCharArray().Reverse().ToArray();
                secondTeam = new string(secondTeamArr);

                //teamsScore:
                long[] scoreResult = inputParts[2].Split(':').Select(long.Parse).ToArray();
                long firstTeamScore = scoreResult[0];
                long secondTeamScore = scoreResult[1];

                //teamsPoints:
                long firstTeamPoints = 0;
                long secondTeamPoints = 0;

                if (firstTeamScore > secondTeamScore)
                {
                    firstTeamPoints = 3;
                    secondTeamPoints = 0;
                }
                else if (firstTeamScore < secondTeamScore)
                {
                    firstTeamPoints = 0;
                    secondTeamPoints = 3;
                }
                else if (firstTeamScore == secondTeamScore)
                {
                    firstTeamPoints = 1;
                    secondTeamPoints = 1;
                }

                //Adding all information to dictionary:
                if (teams.ContainsKey(firstTeam))
                {
                    teams[firstTeam][0] += firstTeamPoints;
                    teams[firstTeam][1] += firstTeamScore;
                }
                else
                {
                    teams[firstTeam] = new List<long>();
                    teams[firstTeam].Add(firstTeamPoints);
                    teams[firstTeam].Add(firstTeamScore);
                }

                if (teams.ContainsKey(secondTeam))
                {
                    teams[secondTeam][0] += secondTeamPoints;
                    teams[secondTeam][1] += secondTeamScore;
                }
                else
                {
                    teams[secondTeam] = new List<long>();
                    teams[secondTeam].Add(secondTeamPoints);
                    teams[secondTeam].Add(secondTeamScore);
                }

                input = Console.ReadLine();
            }

            //Printing:

            Console.WriteLine("League standings:");
            int count = 1;

            foreach (var pair in teams.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{count}. {pair.Key} {pair.Value[0]}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");           

            foreach (var pair in teams.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {pair.Key} -> {pair.Value[1]}");              
            }
        }
    }
}
