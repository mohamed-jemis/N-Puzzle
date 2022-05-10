using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo_project
{

    class Program
    {
       private static int inversion_count(int[]arr,int left,int right)
        {          
            int inversion_counter = 0;            
            if(right>left)
            {
                int mid = (right + left) / 2;
                inversion_counter += inversion_count(arr, left, mid);
                inversion_counter += inversion_count(arr, mid + 1, right);
                inversion_counter += merge(arr, left, mid+1, right);
            }
            return inversion_counter;
        }
        private static int merge(int[]arr,int left,int mid,int right)
        {
            int l_index = left, r_index = mid, k = 0;
            int inversion_counter = 0;
            int[] temp=new int [(right-left+1)];
            while(l_index<mid && r_index<=right)
            {
                if (arr[l_index] <= arr[r_index])
                {
                    temp[k] = arr[l_index];
                    k++;
                    l_index++;

                }
                else
                {
                    temp[k] = arr[r_index];
                    inversion_counter += mid - l_index;
                    k++;
                    r_index++;
                }   
            }
                while(l_index<mid)
                {
                    temp[k] = arr[l_index];
                    k++;
                    l_index++;
                }
                while(r_index<=right)
                {
                    temp[k] = arr[r_index];
                    k++;
                    r_index++;
                }

            //for (l_index = left, k = 0; l_index <= right; l_index++, k++)
            for(l_index=left;l_index<right-left+1;l_index++)
            {
                //Console.WriteLine(temp[k]);
                arr[l_index] = temp[l_index];
            }

                return inversion_counter; 
         
        }
        public static void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 6, 4, 7,5, 8 ,0};
            Console.Write("Number of inversions are "
                          +inversion_count(arr,0,arr.Length-1));
        }

    }

}


