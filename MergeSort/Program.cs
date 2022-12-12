// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main()
        {
            int[] example = { 7, 8, 19, 12, 42, 36, 4, 71 };
            bool starter = true;
            foreach (int item in example)
            {
                if (starter)
                {
                    Console.Write("The original array is {");
                    starter= false;
                }
                else
                {
                    Console.Write(", ");
                }
                Console.Write(item);
            }
            Console.WriteLine("}.");
            int[] merged = MergeSort(example);
            starter = true;
            foreach (int item in merged)
            {
                if (starter)
                {
                    Console.Write("The sorted array is {");
                    starter= false;
                }
                else
                {
                    Console.Write(", ");
                }
                Console.Write(item);
            }
            Console.WriteLine("}.");
        }
        public static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length > 1)
            {
                int center = (int)(numbers.Length / 2);
                int[] left = new int[center];
                for (int i = 0; i < center; i++)
                {
                    left[i] = numbers[i];
                }
                int[] right = new int[numbers.Length - center];
                for (int i = center; i < numbers.Length; i++)
                {
                    right[i - center] = numbers[i];
                }
                left = MergeSort(left);
                right = MergeSort(right);
                return Merge(left, right);
            }
            else
            {
                return numbers;
            }
        }
        public static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int indexLeft = 0;
            int indexRight = 0;
            int indexMerged = 0;
            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] < right[indexRight])
                {
                    merged[indexMerged++] = left[indexLeft++];
                }
                else
                {
                    merged[indexMerged++] = right[indexRight++];
                }
            }
            while (indexLeft < left.Length)
            {
                merged[indexMerged++] = left[indexLeft++];
            }
            while (indexRight < right.Length)
            {
                merged[indexMerged++] = right[indexRight++];
            }
            return merged;
        }
    }
}


