/*
If element is found return the index else return the index where it should've been found.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    class BinarySearchWithTwist
    {
        public static int Find(int key, int[] a)
        {
            if (a.Length == 0) return 0;

            int low = 0;
            int high = a.Length - 1;
            int mid = 0;

            while (low <= high)
            {
                mid = low + (high - low) / 2;
                // if (mid > high) break;
                if (a[mid] == key) return mid;
                else if (a[mid] > key) high = mid - 1;
                else low = mid + 1;
            }

            return low;
        }
    }    
}