using System;
using System.Linq;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayLength = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            CountingSort(array, 10000);
            Console.WriteLine(string.Join(' ', array));
        }

        private static void CountingSort(int[] array, int maxLengthModule)
        {
            var counters = new int[maxLengthModule * 2 + 1];

            for (int i = 0; i < array.Length; i++)
            {
                counters[maxLengthModule + array[i]]++;
            }

            var index = 0;
            for (int j = 0; j < counters.Length; j++)
            {
                for (int k = 0; k < counters[j]; k++)
                {
                    array[index] = j - maxLengthModule;
                    index++;
                }
            }
        }
    }
}