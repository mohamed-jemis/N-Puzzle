using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npuzzle
{
    internal class MinHeap
    {
        private List<int> arr = new List<int>();
        private int size = 0;

        public MinHeap()
        {
            
        }

        public MinHeap(List<int> arr)
        {
            this.arr = arr;
            size = arr.Count();
            for (int i = size / 2; i >= 0; i--)
            {
                heapify_down(i);
            }
        }
        
        public int get_size()
        {
            return size;
        }

        private int get_parent(int curr_node)
        {
            return curr_node / 2;
        }
        private int get_left_child(int curr_node)
        {
            int child = curr_node * 2 + 1;
            if (child < size)
                return child;
            else
                return -1;
        }
        private int get_right_child(int curr_node)
        {
            int child = curr_node * 2 + 2;
            if (child < size)
                return child;
            else
                return -1;
        }
        
        public void heapify_down(int curr_node)
        {
            int left_indx = get_left_child(curr_node);
            int right_indx = get_right_child(curr_node);
            int min = curr_node;

            if (left_indx != -1 && arr[left_indx] < arr[curr_node])
            {
                min = left_indx;
            }
            if (right_indx != -1 && arr[right_indx] < arr[min])
            {
                min = right_indx;
            }

            if (min != curr_node)
            {
                int temp = arr[curr_node];
                arr[curr_node] = arr[min];
                arr[min] = temp;
                heapify_down(min);
            }
        }
        public void heapify_up(int curr_node)
        {
            if (curr_node != 0)
            {
                int parent = get_parent(curr_node);
                if (arr[parent] > arr[curr_node])
                {
                    int temp = arr[curr_node];
                    arr[curr_node] = arr[parent];
                    arr[parent] = temp;
                }
                heapify_up(parent);
            }
           
        }
        public void add(int element)
        {
            arr.Add(element);
            size++;
            heapify_up(size-1);
        }
        public int pull()
        {
            int temp = arr[0];
            arr[0] = arr[size-1];
            size--;
            heapify_down(0);
            return temp; 
        }

    }
}
