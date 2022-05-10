using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npuzzle
{
    public class heuristics
    {
        int manhatten_distance()
        {
            int[,] ideal = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] test = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            IDictionary<int, int[]> places = new Dictionary<int, int[]>();
            for (int i = 0; i < 9; i++)
            {
                places.Add(i, null);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    places[test[i, j]] = new int[] { i, j };
                }
            }
            int index = 1;
            int manhatten = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ideal[i, j] == 0) { continue; }
                    int[] cordinates = places[index];
                    int x = cordinates[0];
                    int y = cordinates[1];
                    index++;
                    manhatten += Math.Abs(x - i) + Math.Abs(y - j);
                }
            }
            return manhatten;
        }
    }
}
