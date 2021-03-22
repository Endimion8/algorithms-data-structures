using System;
using System.Linq;

/*
 Реализуйте алгоритм бинарного поиска.

    Входные данные
    В первой строке содержатся числа n и k (1≤n,k≤10^5).

    Во второй строке задаются n элементов первого массива, отсортированного по возрастанию, а в третьей строке — k элементов второго массива.
    Элементы массивов — целые числа, не превосходящие по модулю 10^9.

    Выходные данные
    Для каждого из k чисел второго массива выведите в отдельную строку «YES», если это число встречается в первом массиве, и «NO» в противном случае.
    
    
    входные данные
    10 5
    1 2 3 4 5 6 7 8 9 10
    -2 0 4 9 12
    выходные данные
    NO
    NO
    YES
    YES
    NO
    */

namespace BinarySearch
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
                Console.WriteLine(BinarySearch(array, searchValue) != -1 ? "YES" : "NO");
            }
        }

        private static long BinarySearch(long[] array, long searchValue)
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

            return right != array.Length && array[right] == searchValue ? right : -1;
        }
    }
}