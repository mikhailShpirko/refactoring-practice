using System;
using System.Collections.Generic;

namespace SuperDrive.Libs.BubleSort
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> BubleSort<T>(this T[] collection, IComparer<T> comparer)
        {
            var keepIterating = true;
            while (keepIterating)
            {
                keepIterating = false;
                for (int i = 0; i < collection.Length - 1; i++)
                {
                    T x = collection[i];
                    T y = collection[i + 1];
                    if (comparer.Compare(x, y) > 0)
                    {
                        collection[i] = y;
                        collection[i + 1] = x;
                        keepIterating = true;
                    }
                }
            }
            return collection;
        }
    }
}
