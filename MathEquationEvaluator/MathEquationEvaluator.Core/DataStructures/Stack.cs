using System;
using MathEquationEvaluator.Core.Extensions;

namespace MathEquationEvaluator.Core.DataStructures
{
    public class Stack<T>: IPushableCollection<T>
    {
        private T[] _items;

        public T[] Items => _items;

        public Stack()
        {
            _items = new T[0];
        }

        public bool IsEmpty => Length == 0;

        public int Length => _items.Length;

        public void Push(T newItem)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.GetLastIndex()] = newItem;
        }

        public T Peek()
        {
            return _items[_items.GetLastIndex()];
        }

        public T Pop()
        {
            var topItem = Peek();
            Array.Resize(ref _items, _items.GetLastIndex());
            return topItem;
        }

        public override string ToString()
        {
            return _items.ToString();
        }
    }
}
