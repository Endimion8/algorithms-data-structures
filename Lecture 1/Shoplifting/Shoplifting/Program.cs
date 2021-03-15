using System;
using System.Linq;

namespace Shoplifting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayLength = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = GetMinStolenKeyboardsCount(array);
            Console.WriteLine(result);
        }

        private static int GetMinStolenKeyboardsCount(int[] array)
        {
            var minIndex = 0;
            var maxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
                else if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return array[maxIndex] - array[minIndex] + 1 - array.Length;
        }
    }
}