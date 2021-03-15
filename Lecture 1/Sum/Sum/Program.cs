using System;
using System.Linq;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray() ?? Array.Empty<int>();
            var sum = Sum(numbers[0], numbers[1]);
            
            Console.WriteLine(sum);
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}