using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfAlgorithms
{
    class Bitonic
    {
        int[] array = new int[10] { 1, 3, 25, 19, 15, 11, 10, 9, 7, 5 };
        int highIndex = 0;
        int target = 0;
        int targetIndex = -1;

        public int FindTarget(int num)
        {
            target = num;
            FindBiggest(0, array.Length - 1);

            if (target == array[highIndex])
                return highIndex;

            targetIndex = FindInc(0, highIndex);
            if (targetIndex != -1)
                return targetIndex;

            targetIndex = FindDec(highIndex, array.Length - 1);
            return targetIndex;
        }

        private void FindBiggest(int first, int last)
        {
            int mid = (first + last) / 2;

            if (mid == 0)
            {
                if (array[mid] > array[mid + 1]) highIndex = array[mid];
                else highIndex = mid + 1;
                return;
            }
            else if (mid == array.Length - 1)
            {
                if (array[mid] > array[mid - 1]) highIndex = array[mid];
                else highIndex = mid - 1;
                return;
            }

            if (array[mid] > array[mid - 1] && array[mid] > array[mid + 1])
            {
                highIndex = mid;
                return;
            }
            else if (array[mid] > array[mid - 1] && array[mid] < array[mid + 1])
            {
                FindBiggest(mid + 1, last);
            }
            else if (array[mid] < array[mid - 1] && array[mid] > array[mid + 1])
            {
                FindBiggest(first, mid - 1);
            }
            else
                return;
        }

        private int FindInc(int first, int last)
        {
            int mid = (first + last) / 2;

            if (target == array[mid])
                return mid;
            else if (first == mid || last == mid)
                return -1;
            else if (target > array[mid])
            {
                if (mid == last) return -1;
                return FindInc(mid + 1, last);
            }
            else
            {
                if (mid == first) return -1;
                return FindInc(first, mid - 1);
            }
        }

        private int FindDec(int first, int last)
        {
            int mid = (first + last) / 2;

            if (target == array[mid])
                return mid;
            else if (target < array[mid])
            {
                if (mid == last) return -1;
                return FindDec(mid + 1, last);
            }
            else
            {
                if (mid == first) return -1;
                return FindDec(first, mid - 1);
            }
        }
    }
}
