using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            Regex healthRegex = new Regex(@"[^0-9\+\-\*\/\.\s\,]");
            
            Regex damageRegex = new Regex(@"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)");

            Regex damageOperatorsRegex = new Regex(@"\*?\/?");

            var participantsList = new List<string>();

            var participantsNames = Console.ReadLine().Split(new[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < participantsNames.Count; i++)
            {
                string demonName = participantsNames[i];

                //Health:
                MatchCollection healthMatches = healthRegex.Matches(demonName);

                string name = "";
                foreach (Match ch in healthMatches)
                {
                    name += ch.ToString();
                }

                long health = 0;
                for (int l = 0; l < name.Length; l++)
                {
                    health += (int)name[l];
                }

                //Damage:
                MatchCollection damageMatches = damageRegex.Matches(demonName);
                decimal damage = 0.0m;                

                foreach (Match number in damageMatches)
                {
                    if (!number.ToString().Equals(string.Empty))
                    {                        
                        damage += 0.0m;
                    }

                    damage += decimal.Parse(number.ToString());
                }
                
                MatchCollection damageOperatorsMatches = damageOperatorsRegex.Matches(demonName.ToString());
                var operators = new List<string>();

                foreach (Match op in damageOperatorsMatches)
                {
                    if (!op.ToString().Equals(string.Empty))
                    {
                        operators.Add(op.ToString());
                    }                        
                }

                if (operators.Any())
                {
                    foreach (var op in operators)
                    {
                        if (op == "*")
                        {
                            damage *= 2.0m;
                        }
                        else if (op == "/")
                        {
                            damage /= 2.0m;
                        }
                    }
                }

                string dragonInfo = $"{demonName} - {health} health, {damage:f2} damage";
                participantsList.Add(dragonInfo);
            }

            //Printing:
            foreach (var participant in participantsList.OrderBy(x => x))
            {
                Console.WriteLine(participant);
            }

        }
    }
}
