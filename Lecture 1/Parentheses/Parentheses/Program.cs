using System;
using System.Collections.Generic;
using System.Linq;

namespace Parentheses
{
    class Program
    {
        private static readonly Dictionary<char, char> Chars = new Dictionary<char, char>
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
        };
        
        static void Main(string[] args)
        {
            try
            {
                var stack = new Stack<char>();
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("yes");
                    return;
                }

                foreach (var @char in input)
                {
                    if (Chars.Keys.Contains(@char))
                    {
                        stack.Push(@char);
                    }
                    else if(Chars.Values.Contains(@char))
                    {
                        var last = stack.Back();
                        if (Chars[last] != @char)
                        {
                            throw new InvalidOperationException(@char.ToString());
                        }
                        stack.Pop();
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }

                if (stack.Size() != 0)
                {
                    throw new InvalidOperationException();
                }
                
                Console.WriteLine("yes");
            }
            catch (Exception e)
            {
                Console.WriteLine("no");
            }
        }
    }
    
    
    class Stack<T>
    {
        private List<T> _list { get; set; }

        public Stack()
        {
            _list = new List<T>();
        }

        public int Size()
        {
            return _list.Count;
        }

        public void Push(T n)
        {
            _list.Add(n);
        }

        public T Pop()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("error");
            }

            var result = _list.Last();
            _list.RemoveAt(_list.Count -1);
            return result;
        }

        public T Back()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("error");
            }

            return _list.Last();
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}