using System;
using System.Collections.Generic;

namespace Common.Common
{
    public static class Extensions
    {
        public static void Replace<T>(this IList<T> list, T itemToRemove, T itemToAdd)
        {
            list.Remove(itemToRemove);
            list.Add(itemToAdd);
        }

        public static void RemoveAll<T>(this IList<T> list, Predicate<T> match)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (match(list[i]))
                {
                    list.RemoveAt(i);
                }
            }
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> toAdd)
        {
            foreach (var item in toAdd)
            {
                list.Add(item);
            }
        }

        public static void AddSorted<T>(this IList<T> list, T item, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            var i = 0;
            while (i < list.Count && comparer.Compare(list[i], item) < 0)
            {
                i++;
            }

            list.Insert(i, item);
        }
    }
}