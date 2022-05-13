using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_project
{
    class distance
    {
        static int[] ideal = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        public static int manhatten(int N, Node n)
        {

            int numbers = N * N;
            Dictionary<int, int[]> places = new Dictionary<int, int[]>();
            for (int i = 0; i < numbers; i++)
            {
                places.Add(i, null);
            }
            int xi = 0;
            for (int i = 0; i < numbers; i++)
            {
                places[n.arr[i]] = new int[2] { (i / 3), xi };
                xi++;
                if (xi == 3)
                {
                    xi = 0;
                }
            }
            xi = 0;

            // set zero-coordinate

            int[] zero_coordinates = new int[2];
            zero_coordinates = places[0];
            n.x_zero = zero_coordinates[0];
            n.y_zero = zero_coordinates[1];


            int index_manhatten = 1;
            int manhatten = 0;


            for (int i = 0; i < numbers; i++)
            {
                if (ideal[i] == 0) { continue; }
                int[] cordinates = places[index_manhatten];
                int x = cordinates[0];
                int y = cordinates[1];

                index_manhatten++;
                manhatten += Math.Abs(x - i / 3) + Math.Abs(y - xi);
                xi++;
                if (xi == 3)
                {
                    xi = 0;
                }
            }

            return manhatten;
        }



        public static int hamming(int N, Node n)
        {
            int numbers = N * N;
            Dictionary<int, int[]> places = new Dictionary<int, int[]>();
            for (int i = 0; i < numbers; i++)
            {
                places.Add(i, null);
            }
            int xi = 0;
            for (int i = 0; i < numbers; i++)
            {
                places[n.arr[i]] = new int[2] { (i / 3), xi };
                xi++;
                if (xi == 3)
                {
                    xi = 0;
                }
            }
            xi = 0;

            // set zero-coordinate

            int[] zero_coordinates = new int[2];
            zero_coordinates = places[0];
            n.x_zero = zero_coordinates[0];
            n.y_zero = zero_coordinates[1];


            int hamming = 0;
            int index_hamming = 1;


            for (int i = 0; i < numbers; i++)
            {
                if (ideal[i] == 0) { continue; }
                int[] cord = places[index_hamming];
                if (!(cord[0] == i / 3 && cord[1] == xi))
                {
                    hamming++;
                }
                index_hamming++;
                xi++;
                if (xi == 3)
                {
                    xi = 0;
                }

            }
            return hamming;
        }
    }
}
