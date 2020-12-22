using System;
using System.Collections.Generic;

namespace TruckTour.Util
{
    public static class LinkedListNodeExtensions
    {
        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }
    }
}
