using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new StackIntWrapper();

            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var input = line.Split(' ').ToArray();
                if (input[0] == "exit")
                {
                    Console.WriteLine("bye");
                    return;
                }

                var result = stack.GetResult(input);
                Console.WriteLine(result);
            }
        }
    }

    class StackIntWrapper
    {
        private Stack<string> Stack { get; set; }

        public StackIntWrapper()
        {
            Stack = new Stack<string>();
        }
        
        public string GetResult(string[] input)
        {
            switch (input[0])
            {
                case "push":
                {
                    return Push(input[1]);
                }
                case "pop":
                {
                    return Pop();
                }
                case "back":
                {
                    return Back();
                }
                case "size":
                {
                    return Size();
                }
                case "clear":
                {
                    return Clear();
                }
                default: return "error";
            }
        }
        
        public string Size()
        {
            return Stack.Size().ToString();
        }

        public string Push(string n)
        {
            Stack.Push(n);
            return "ok";
        }

        public string Pop()
        {
            try
            {
                return Stack.Pop();
            }
            catch (Exception e)
            {
                return "error";
            }
        }

        public string Back()
        {
            try
            {
                return Stack.Back();
            }
            catch (Exception e)
            {
                return "error";
            }
        }

        public string Clear()
        {
            Stack.Clear();
            return "ok";
        }
    }

    class Stack<T>
    {
        private T[] _array { get; set; }

        public Stack()
        {
            _array = Array.Empty<T>();
        }

        public int Size()
        {
            return _array.Length;
        }

        public void Push(T n)
        {
            _array = _array.Append(n).ToArray();
        }

        public T Pop()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException("error");
            }

            var result = _array.Last();
            _array = _array.SkipLast(1).ToArray();
            return result;
        }

        public T Back()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException("error");
            }

            return _array.Last();
        }

        public void Clear()
        {
            _array = Array.Empty<T>();
        }
    }
}