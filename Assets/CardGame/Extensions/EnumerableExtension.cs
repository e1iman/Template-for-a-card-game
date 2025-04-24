using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Extensions
{
    public static class EnumerableExtensions
    {
        static readonly Random Random = new();

        public static T GetRandomElement<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> filteredSource = source.Where(predicate).ToList();
            int index = Random.Next(filteredSource.Count);
            return filteredSource[index];
        }
    }
}
