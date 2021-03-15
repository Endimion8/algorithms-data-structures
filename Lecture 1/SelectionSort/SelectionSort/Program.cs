using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayLength = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = SelectionSort(array);
            Console.WriteLine(string.Join(' ', result));
        }

        public static int[] SelectionSort(int[] array)
        {
            int current;
            int minIndex;
            
            for (int i = 0; i < array.Length; i++)
            {
                minIndex = i;
                
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                current = array[i];
                array[i] = array[minIndex];
                array[minIndex] = current;
            }

            return array;
        }
    }
}