using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npuzzle
{
    public class solvability
    { 
        public static int inversion_count(List<int> arr, int[] temp, int left, int right)
        {

            int inversion_counter = 0;

            if (right > left)
            {
                int mid = (right + left) / 2;
                inversion_counter += inversion_count(arr, temp, left, mid);
                inversion_counter += inversion_count(arr, temp, mid + 1, right);
                inversion_counter += merge(arr, temp, left, mid + 1, right);
            }
            return inversion_counter;
        }

        public static int merge(List<int> arr, int[] temp, int left, int mid, int right)
        {
            int left_index = left, right_index = mid, k = left;
            int inversion_counter = 0;

            while ((left_index < mid) && (right_index <= right))
            {
                if (arr[left_index] <= arr[right_index])
                {
                    temp[k] = arr[left_index];
                    k++;
                    left_index++;
                }
                else
                {
                    temp[k] = arr[right_index];
                    k++;
                    right_index++;
                    inversion_counter += (mid - left_index);
                }
            }
            while (left_index <= mid - 1)
            {
                temp[k] = arr[left_index];
                k++;
                left_index++;
            }
            while (right_index <= right)
            {
                temp[k] = arr[right_index];
                k++;
                right_index++;
            }
            for (left_index = left; left_index <= right; left_index++)
            {
                arr[left_index] = temp[left_index];
            }

            return inversion_counter;

        }
        public static bool IS_solvable(List<int> arr, int[] temp, int left, int right, int n, int blank_row)
        {
            int invCnt = inversion_count(arr, temp, left, right);

            if (n % 2 != 0)
            {
                if (invCnt % 2 == 0 && invCnt != 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (invCnt % 2 == blank_row % 2 || invCnt == 0)
                    return false;
                else
                    return true;
            }
        }

     /*   public static bool IS_solvable_Set(List<int> arr,int n)
        {
            SortedSet<int> my_set=new SortedSet<int>();
            for(int i=0;i<n;i++)
            {
                Binary_search(my_set, arr[i]);
                my_set.Add(arr[i]);
                
            }


            return true;
        }
        public int Binary_search(SortedSet<int> s,int n)
        {
            int left=0, right=n, mid;
            while(left<=right)
            {
                mid = (left + right) / 2;
                if(mid<n)
                {

                }
            }
            return 1;
        }
            */
    }
}