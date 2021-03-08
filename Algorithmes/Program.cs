using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithmes
{
    class Program
    {
        public static int? BinarySearch(int[] sortedArray, int item)
        {
            var begin = 0;
            var end = sortedArray.Length - 1;

            do
            {
                var mid = (begin + end) / 2;
                var guess = sortedArray[mid];
                if(guess == item)
                {
                    return item;
                } else if(guess < item)
                {
                    begin = mid + 1;
                } else if(guess > item)
                {
                    end = mid - 1;
                }
            } while (begin <= end);

            return null;
        }

        public static int SmallestSearch(int[] array)
        {
            int arraySize = array.Length - 1;
            int smallest = array[0];
            
            for ( int x = 0; x <= arraySize; x++)
            {
                if(array[x] < smallest)
                {
                    smallest = array[x];
                }
            }

            return smallest;
        }

        public static int[] InsertionSort(List<int> list)
        {
            var listSize = list.Count - 1;

           for(int x = 1; x <= listSize; x++)
            {
                var key = list[x];
                var y = x - 1;
                while( y > 0 && list[y] > key)
                {
                    list[y + 1] = list[y];
                    y = y - 1;
                }
                list[y + 1] = key;
            }

            return list.ToArray();
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] array = { 5, 12, 43, 7, 22, 69 };

            // Binary Search
            var result = BinarySearch(sortedArray, 10);
            if(result != null)
            {
                Console.WriteLine(result);
            } else
            {
                Console.WriteLine("Int wasn't found");
            }

            // Smallest
            Console.WriteLine(SmallestSearch(array));

            // Insertion Sort
            var insertionSortResult = InsertionSort(array.ToList());
            foreach(var number in insertionSortResult)
            {
                Console.WriteLine(number);
            }

            QuickSort(array, 0, array.Length - 1);
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
        }
    }
}
