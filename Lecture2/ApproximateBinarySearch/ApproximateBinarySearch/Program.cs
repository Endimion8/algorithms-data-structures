using System;
using System.Linq;


/*
 Реализуйте алгоритм приближенного бинарного поиска.

Входные данные
В первой строке входных данных содержатся числа n и k (1≤n,k≤10^5). 
Во второй строке задаются n чисел первого массива, отсортированного по неубыванию, а в третьей строке – k чисел второго массива. 
Каждое число в обоих массивах по модулю не превосходит 2*10^9.

Выходные данные
Для каждого из k чисел выведите в отдельную строку число из первого массива, наиболее близкое к данному. Если таких несколько, выведите меньшее из них.

    входные данные
    5 5
    1 3 5 7 9
    2 4 8 1 6
    выходные данные
    1
    3
    7
    1
    5
*/


namespace ApproximateBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var numbersToSearch = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            foreach (var searchValue in numbersToSearch)
            {
                Console.WriteLine(ApproximateBinarySearch(array, searchValue));
            }
        }

        private static long ApproximateBinarySearch(long[] array, long searchValue)
        {
            var left = -1;
            var right = array.Length;
            var middle = 0;

            while (right - left > 1)
            {
                middle = (left + right) / 2;

                if (array[middle] >= searchValue)
                {
                    right = middle;
                }
                else
                {
                    left = middle;
                }
            }

            if (right != array.Length && array[right] == searchValue)
            {
                return array[right];
            }

            if (right == array.Length)
            {
                return array[left];
            }

            if (left == -1)
            {
                return array[right];
            }

            return searchValue - array[left] <= array[right] - searchValue ? array[left] : array[right];
        }
    }
}