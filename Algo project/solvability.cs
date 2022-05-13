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
            int l_index = left, r_index = mid, k = left;
            int inversion_counter = 0;
            while ((l_index < mid) && (r_index <= right))
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
                    k++;
                    r_index++;
                    inversion_counter += (mid - l_index);
                }
            }
            while (l_index <= mid - 1)
            {
                temp[k] = arr[l_index];
                k++;
                l_index++;
            }
            while (r_index <= right)
            {
                temp[k] = arr[r_index];
                k++;
                r_index++;
            }

            //for (l_index = left, k = 0; l_index <= right; l_index++, k++)
            for (l_index = left; l_index <= right; l_index++)
            {
                //Console.WriteLine(temp[k]);asdasd
                arr[l_index] = temp[l_index];
            }

            return inversion_counter;

        }

    }
}