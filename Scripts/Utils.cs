using System;
using System.Collections.Generic;

namespace bwayy.Scripts
{
    public static class ListExtensions
    {
        // https://stackoverflow.com/a/42002747
        public static List<T> GetRandomElements<T>(this IList<T> list, int quantity)
        {
            var result = new List<T>();
            if (list == null)
                return result;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < quantity; i += 1)
            {
                int idx = rnd.Next(0, list.Count);
                result.Add(list[idx]);
            }
            return result;
        }
    }
}