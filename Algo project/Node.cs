using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npuzzle
{
    class Node
    {
        public int N;
        public int[] arr;
        public int h_score = 0; //depth
        public int g_score; //manhatteen or hamming
        public int f_score; //g_score+h_score
        public Node parent;
        public int x_zero;
        public int y_zero;

        public bool right()
        {

            if (x_zero == 0) { return false; }
            return true;
        }
        public bool left()
        {
            if (x_zero == (N - 1)) { return false; }
            return true;
        }
        public bool down()
        {
            if (y_zero == 0) { return false; }
            return true;
        }
        public bool up()
        {
            if (y_zero == (N - 1)) { return false; }
            return true;
        }
        public static void create_children(Node n,List<int[]> closed,MinHeap active,int[] ideal)
        {
            if (n.up() == true)
            {
                Node new_node = new Node();
                int[] temp = new int[n.N*n.N];
                n.arr.CopyTo(temp,0);
                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero + 1) * n.N) + n.x_zero];
                temp[((n.y_zero + 1) * n.N) + n.x_zero] = 0;
                new_node.parent = n;
                new_node.arr = temp;
                //new_node.x_zero =n.x_zero ;
                //new_node.y_zero = n.y_zero +1 ;
                //new_node.h_score = n.h_score + 1;
                //new_node.N = n.N;
                //new_node.g_score = distance.manhatten(new_node.N, new_node);
                //new_node.f_score = new_node.g_score + new_node.h_score;
                set_info(new_node,ideal);
                if(!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }

            }
            if (n.down() == true)
            {
                Node new_node = new Node();
                int[] temp = new int[n.N * n.N];
                n.arr.CopyTo(temp, 0);
                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero - 1) * n.N) + n.x_zero];
                temp[((n.y_zero - 1) * n.N) + n.x_zero] = 0;
                new_node.parent = n;
                new_node.arr = temp;
                // new_node.x_zero = n.x_zero ;
                //new_node.y_zero = n.y_zero-1;
                //new_node.h_score = n.h_score + 1;
                //new_node.N = n.N;
                //new_node.g_score = distance.manhatten(new_node.N, new_node);
               // new_node.f_score = new_node.g_score + new_node.h_score;
                set_info(new_node,ideal);
                if (!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }
            }
            if (n.right() == true)
            {
                Node new_node = new Node();
                int[] temp = new int[n.N * n.N];
                n.arr.CopyTo(temp, 0);
                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero) * n.N) + (n.x_zero - 1)];
                temp[((n.y_zero) * n.N) + (n.x_zero - 1)] = 0;
                new_node.parent = n;
                new_node.arr = temp;
                // new_node.x_zero = n.x_zero - 1;
                //new_node.y_zero = n.y_zero;
                //new_node.h_score = n.h_score + 1;
                //new_node.N = n.N;
                //new_node.g_score = distance.manhatten(new_node.N, new_node);
               // new_node.f_score = new_node.g_score + new_node.h_score;
                set_info(new_node,ideal);
                if (!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }
            }
            if (n.left() == true)
            {
                Node new_node = new Node();
                int[] temp = new int[n.N * n.N];
                n.arr.CopyTo(temp, 0);
                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero) * n.N) + (n.x_zero + 1)];
                temp[((n.y_zero) * n.N) + (n.x_zero + 1)] = 0;
                new_node.parent = n;
                new_node.arr = temp;
                // new_node.x_zero = n.x_zero + 1;
                //new_node.y_zero = n.y_zero;
                //new_node.h_score = n.h_score + 1;
                //new_node.N = n.N;
                //new_node.g_score = distance.manhatten(new_node.N, new_node);
                //new_node.f_score = new_node.g_score + new_node.h_score;
                set_info(new_node,ideal);
                if (!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }
            }

        }
        public bool duplicate_in_closed(List<int[]> closed)
        {
            for(int i=0;i<closed.Count();i++)
            {
              if (arr.SequenceEqual(closed[i]))
                {
                    return true;
                }
            }
            return false;
        }
        
        public static void set_info(Node n,int[] ideal)
        {
            n.h_score = n.h_score + 1;
            n.N = n.parent.N;
            n.g_score = distance.manhatten(n.N, n,ideal);
            n.f_score = n.g_score + n.h_score;
        }
        
      
        // x_zero and y_zero supposed to be set while calculating manhatten distance and hamming distance.

    }
}
