﻿using System;
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

        public Node()
        {
        }

        public Node(int n, int[] arr, Node parent, int[]ideal)
        {
            N = n;
            this.arr = arr;
            this.g_score = distance.manhatten(n, this, ideal);
            this.parent = parent;
            if (parent != null)
            {
                this.h_score = parent.h_score + 1;
                this.f_score = this.g_score + this.h_score;
            }
        }

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
                int[] temp = new int[n.N*n.N];
                n.arr.CopyTo(temp,0);

                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero + 1) * n.N) + n.x_zero];
                temp[((n.y_zero + 1) * n.N) + n.x_zero] = 0;

                Node new_node = new Node(n.N, temp, n, ideal);

                if(!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }

            }
            if (n.down() == true)
            {
                int[] temp = new int[n.N * n.N];
                n.arr.CopyTo(temp, 0);

                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero - 1) * n.N) + n.x_zero];
                temp[((n.y_zero - 1) * n.N) + n.x_zero] = 0;

                Node new_node = new Node(n.N, temp, n, ideal);

                if (!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }
            }
            if (n.right() == true)
            {
                int[] temp = new int[n.N * n.N];
                n.arr.CopyTo(temp, 0);

                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero) * n.N) + (n.x_zero - 1)];
                temp[((n.y_zero) * n.N) + (n.x_zero - 1)] = 0;
      
                Node new_node = new Node(n.N, temp, n, ideal);
                
                if (!new_node.duplicate_in_closed(closed))
                {
                    active.add(new_node);
                }
            }
            if (n.left() == true)
            {
                int[] temp = new int[n.N * n.N];
                n.arr.CopyTo(temp, 0);

                temp[(n.y_zero * n.N) + n.x_zero] = temp[((n.y_zero) * n.N) + (n.x_zero + 1)];
                temp[((n.y_zero) * n.N) + (n.x_zero + 1)] = 0;

                Node new_node = new Node(n.N, temp, n, ideal);
                
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
        
        // x_zero and y_zero supposed to be set while calculating manhatten distance and hamming distance.

    }
}
