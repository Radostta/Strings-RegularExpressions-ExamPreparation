using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spyfer
{
    class Spyfer
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < coordinates.Count; i++)
            {
                int currentNumber = coordinates[i];

                if (i != 0 && i != coordinates.Count - 1)
                {
                    int sumOfNeighbours = coordinates[i - 1] + coordinates[i + 1];

                    if (currentNumber == sumOfNeighbours)
                    {
                        coordinates.RemoveAt(i + 1);
                        coordinates.RemoveAt(i - 1);
                        i = 0;
                    }
                }
                else if (i == 0 && currentNumber == coordinates[i + 1])
                {
                    coordinates.RemoveAt(i + 1);
                    i = 0;
                }
                else if (i == coordinates.Count - 1 && currentNumber == coordinates[i - 1])
                {
                    coordinates.RemoveAt(i - 1);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", coordinates));
        }
    }
}
