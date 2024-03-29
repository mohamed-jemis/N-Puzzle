﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npuzzle
{
    class Node
    {
        public Node parent;
        public int[] arr;//puzzle 
        public int N;//size 
        public int g_score = 0; //depth
        public int h_score; //manhatteen or hamming
        public int f_score; //g_score+g_score
        public int x_zero;
        public int y_zero;
        public string s_rep = "";

        public Node()
        {
            //empty const.
        }

        public Node(int n, int[] arr, Node parent)
        {
            N = n;
            this.arr = arr;
            this.h_score = distance.Distance(n,this);
            this.parent = parent;


            if (parent != null)
            {
                this.g_score = parent.g_score + 1;
                this.f_score = this.h_score + this.g_score;
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

        public static void create_children(Node parent, HashSet<string> closed, MinHeap active)
        {
            if (parent.down() == true)
            {
                int[] temp = new int[parent.N * parent.N];
                parent.arr.CopyTo(temp, 0);

                temp[(parent.y_zero * parent.N) + parent.x_zero] = temp[((parent.y_zero - 1) * parent.N) + parent.x_zero];
                temp[((parent.y_zero - 1) * parent.N) + parent.x_zero] = 0;

                Node new_node = new Node(parent.N, temp, parent);
                
                string current_arr = get_string(temp);
                
                
                if (!new_node.duplicate_in_closed(closed, current_arr))
                {
                    active.add(new_node);
                }
            }
            if (parent.up() == true)
            {
                int[] temp = new int[parent.N * parent.N];
                parent.arr.CopyTo(temp, 0);

                temp[(parent.y_zero * parent.N) + parent.x_zero] = temp[((parent.y_zero + 1) * parent.N) + parent.x_zero];
                temp[((parent.y_zero + 1) * parent.N) + parent.x_zero] = 0;

                Node new_node = new Node(parent.N, temp, parent);

                string current_arr = get_string(temp);
                if (!new_node.duplicate_in_closed(closed, current_arr))
                {
                    active.add(new_node);
                }

            }
            if (parent.right() == true)
            {
                int[] temp = new int[parent.N * parent.N];
                parent.arr.CopyTo(temp, 0);

                temp[(parent.y_zero * parent.N) + parent.x_zero] = temp[((parent.y_zero) * parent.N) + (parent.x_zero - 1)];
                temp[((parent.y_zero) * parent.N) + (parent.x_zero - 1)] = 0;

                Node new_node = new Node(parent.N, temp, parent);

                string current_arr = get_string(temp);
                if (!new_node.duplicate_in_closed(closed, current_arr))
                {
                    active.add(new_node);
                }
            }
            if (parent.left() == true)
            {
                int[] temp = new int[parent.N * parent.N];
                parent.arr.CopyTo(temp, 0);

                temp[(parent.y_zero * parent.N) + parent.x_zero] = temp[((parent.y_zero) * parent.N) + (parent.x_zero + 1)];
                temp[((parent.y_zero) * parent.N) + (parent.x_zero + 1)] = 0;

                Node new_node = new Node(parent.N, temp, parent);

                string current_arr = get_string(temp);
                if (!new_node.duplicate_in_closed(closed,current_arr))
                {
                    active.add(new_node);
                }
            }

        }
        public bool duplicate_in_closed(HashSet<string> closed,string current_arr)
        {
            if (closed.Contains(current_arr))
            {
                return true;
            }

            return false;
        }
        static public string get_string(int[]arr)
        {
            return string.Join("", arr);
        }

    }
}
