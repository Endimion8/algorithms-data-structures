using System;
using System.Globalization;

/*
 Найдите такое число x, что x^2+sqrt(x)=C, с точностью не менее 6 знаков после точки.

    Входные данные
    В единственной строке содержится вещественное число 1≤C≤10^10.

    Выходные данные
    Выведите одно число — искомый x.
    
    
    входные данные
    2.0000000000
    выходные данные
    1.00000000000000000000
    
    входные данные
    18.0000000000
    выходные данные
    4.00000000000000000000
*/


namespace RealNumbersBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberDecimalDigits = 20;
            var c = double.Parse(Console.ReadLine(), nfi);

            var result = BinarySearch(c);
            Console.WriteLine(result.ToString("0.00000000000000000000", nfi));
        }

        private static double BinarySearch(double c)
        {
            var eps = 0.00000000000000000000000001;
            var maxIterationsCount = Convert.ToInt64(Math.Log2(c / eps));
            
            double left = 0;
            double right = 100000;
            double middle = 0;

            for (int i = 0; i < maxIterationsCount; i++)
            {
                middle = (left + right) / 2;

                if (Math.Abs(Function(middle) - c) < eps)
                {
                    return middle;
                }

                if (Function(middle) >= c)
                {
                    right = middle;
                }
                else
                {
                    left = middle;
                }
            }
            

            return right;
        }

        private static double Function(double x)
        {
            return x * x + Math.Sqrt(x);
        }
    }
}