using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayLength = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            MergeSort(array);
            Console.WriteLine(string.Join(' ', array));
        }

        private static int[] MergeSort(int[] array)
        {
            if (array.Length < 2)
            {
                return array;
            }
            
            // divide part
            var leftElementsCount = array.Length / 2;
            var rightElementsCount = array.Length - leftElementsCount;

            var leftArray = MergeSort(array.Take(leftElementsCount).ToArray());
            var rightArray = MergeSort(array.TakeLast(rightElementsCount).ToArray());
            
            // merge part

            var leftIndex = 0;
            var rightIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (leftIndex >= leftArray.Length)
                {
                    array[i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= rightArray.Length)
                {
                    array[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    var leftIsLess = leftArray[leftIndex] < rightArray[rightIndex];
                    array[i] = leftIsLess ? leftArray[leftIndex] : rightArray[rightIndex];
                    if (leftIsLess)
                    {
                        leftIndex++;
                    }
                    else
                    {
                        rightIndex++;
                    }
                }
            }

            return array;
        }
    }
}