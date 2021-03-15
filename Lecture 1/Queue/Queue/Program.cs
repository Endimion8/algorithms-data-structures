using System;
using System.Collections.Generic;
using System.Linq;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueueStringWrapper();

            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var input = line.Split(' ').ToArray();
                if (input[0] == "exit")
                {
                    Console.WriteLine("bye");
                    return;
                }

                var result = queue.GetResult(input);
                Console.WriteLine(result);
            }
        }
        
        class QueueStringWrapper
        {
            private Queue<string> Queue { get; set; }

            public QueueStringWrapper()
            {
                Queue = new Queue<string>();
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
                    case "front":
                    {
                        return Front();
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
                return Queue.Size().ToString();
            }

            public string Push(string n)
            {
                Queue.Push(n);
                return "ok";
            }

            public string Pop()
            {
                try
                {
                    return Queue.Pop();
                }
                catch (Exception e)
                {
                    return "error";
                }
            }

            public string Front()
            {
                try
                {
                    return Queue.Front();
                }
                catch (Exception e)
                {
                    return "error";
                }
            }

            public string Clear()
            {
                Queue.Clear();
                return "ok";
            }
        }

        class Queue<T>
        {
            private Stack<T> _right { get; set; }
            private Stack<T> _left { get; set; }

            public Queue()
            {
                _right = new Stack<T>();
                _left = new Stack<T>();
            }

            public int Size()
            {
                return _right.Size() + _left.Size();
            }
            
            public void Push(T n)
            {
                _right.Push(n);
            }
            
            public T Front()
            {
                if (_left.Size() == 0)
                {
                    MoveToLeft();
                }

                return _left.Back();
            }
            
            public T Pop()
            {
                if (_left.Size() == 0)
                {
                    MoveToLeft();
                }

                return _left.Pop();
            }

            private void MoveToLeft()
            {
                if (_left.Size() != 0)
                {
                    throw new InvalidOperationException("Can't move to left. Left is not empty!");
                }

                while (_right.Size() != 0)
                {
                    _left.Push(_right.Pop());
                }
            }
            
            public void Clear()
            {
                _right.Clear();
                _left.Clear();
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
               var result = _list.Last();
                _list.RemoveAt(_list.Count -1);
                return result;
            }

            public T Back()
            {
                return _list.Last();
            }

            public void Clear()
            {
                _list.Clear();
            }
        }
    }
}