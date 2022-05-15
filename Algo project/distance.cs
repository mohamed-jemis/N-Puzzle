using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npuzzle
{
    class distance
    {
        public static bool choice;

        

        public static int manhatten(int N, Node n )
        {
            int[] cordinates = new int[2];
            int manhatten = 0;
            int haming = 0;
            int numbers = N * N;
            for (int i = 0; i < numbers; i++) //N*N
            {
                int x;

                if (n.arr[i] != 0)
                {
                    x = n.arr[i] - 1;
                }
                else
                {
                    x = N - 1;    //N-1;
                    // set x_zero and y_zero
                    n.x_zero = i % N;
                    n.y_zero = i / N;
                }
                cordinates[0] = x % N;
                cordinates[1] = x / N;
                int real_x = i % N;
                int real_y = i / N;
                if (!(cordinates[0] == real_x && cordinates[1] == real_y))
                {
                    if (n.arr[i] != 0)
                    {
                        haming++;
                        manhatten += Math.Abs(real_x - cordinates[0]) + Math.Abs(real_y - cordinates[1]);
                    }
                }
            }
            if (choice == false)
            {
                return manhatten;
            }
            else
                return haming;
        }
    }
}