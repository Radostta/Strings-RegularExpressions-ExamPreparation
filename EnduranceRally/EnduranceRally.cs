using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    class EnduranceRally
    {
        static void Main(string[] args)
        {
            List<string> participantsNames = Console.ReadLine().Split().ToList();
            double[] trackLayoutZones = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int[] checkpointIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < participantsNames.Count; i++)
            {
                string participantName = participantsNames[i];
                int firstLetter = (int)(participantName.First());
                double startingFuel = (double)firstLetter;

                for (int z = 0; z < trackLayoutZones.Length; z++)
                {
                    double zoneFuel = trackLayoutZones[z];

                    if (checkpointIndexes.Contains(z))
                    {
                        startingFuel += zoneFuel;
                    }
                    else
                    {
                        startingFuel -= zoneFuel;
                    }

                    if (startingFuel <= 0)
                    {
                        Console.WriteLine($"{participantName} - reached {z}");
                        break;
                    }
                }

                if (startingFuel > 0)
                {
                    Console.WriteLine($"{participantName} - fuel left {startingFuel:f2}");
                }
            }
        }
    }
}
