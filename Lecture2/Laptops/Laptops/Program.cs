using System;
using System.Collections.Generic;
using System.Linq;

/*
Как-то раз Дима и Леша поспорили о цене и качестве ноутбуков. Дима считает, что чем дороже ноутбук, тем он лучше. 
Леша говорит, что это не так. Леша считает, что существуют два таких ноутбука, что цена первого меньше, чем цена второго, но первый качественнее второго.

Ваша задача — проверить гипотезу Леши. Заданы характеристики n ноутбуков. Выясните, существуют ли два таких ноутбука, что цена первого строго меньше, чем цена второго, но первый строго качественнее второго.

Входные данные
Первая строка содержит целое число n (1≤n≤10^5) — количество ноутбуков.

Каждая из следующих n строк содержит два целых числа ai и bi (1≤ai,bi≤n): ai — цена i-го ноутбука, bi — число, обозначающее качество i-го ноутбука (чем больше это число, тем качественнее ноутбук).

Все ai различны. Все bi различны.

Выходные данные
Если Леша прав, то выведите строку «Happy Alex», иначе выведите «Poor Alex» (кавычки выводить не нужно).

входные данные
2
1 2
2 1
выходные данные
Happy Alex
 */


namespace Laptops
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionaryCapacity = int.Parse(Console.ReadLine());
            var costsAndQualities = new List<KeyValuePair<int, int>>(dictionaryCapacity);
            int[] temp;
            for (int i = 0; i < dictionaryCapacity; i++)
            {
                temp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                costsAndQualities.Add(new KeyValuePair<int, int>(temp[0], temp[1]));
            }

            costsAndQualities.Sort((x, y) => x.Key.CompareTo(y.Key));

            for (int i = 0; i < dictionaryCapacity - 1; i++)
            {
                if (costsAndQualities[i].Value <= costsAndQualities[i + 1].Value) continue;
                Console.WriteLine("Happy Alex");
                return;
            }
            
            Console.WriteLine("Poor Alex");
        }
    }
}