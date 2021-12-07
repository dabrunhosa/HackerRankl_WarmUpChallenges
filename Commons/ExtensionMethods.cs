using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons
{
    public static class ExtensionMethods
    {
        public static Tuple<int,int> NextTwo(this IEnumerable<int> list, int currentPosition)
        {
            if (list == null)
                throw new ArgumentNullException("TheList should not be null");
            else
            {
                var teste = list.Where(value => (value >= currentPosition + 1 && value <= currentPosition + 2));
                return new Tuple<int,int>(teste.FirstOrDefault(),teste.LastOrDefault());
            }
        }

        public static T CastTo<T>(T typeHolder, Object x)
        {
            // typeHolder above is just for compiler magic
            // to infer the type to cast x to
            return (T)x;
        }

        public static IEnumerable<IEnumerable<TSource>> JoinBy<TSource, TOrderKey, TKey>(
           this IEnumerable<TSource> source,
           Func<TSource, TOrderKey> orderBy,
           Func<TSource, TKey> keySelector,
           Func<TKey, TKey, bool> join)
        {
            var results = new List<List<TSource>>();
            var orderedSource = new List<TSource>(source).OrderBy(orderBy).ToArray();

            if (orderedSource.Length > 0)
            {
                var group = new List<TSource> { orderedSource[0] };
                results.Add(group);
                if (orderedSource.Length > 1)
                {
                    for (int i = 1; i < orderedSource.Length; i++)
                    {
                        var lag = orderedSource[i - 1];
                        var current = orderedSource[i];
                        if (join(keySelector(lag), keySelector(current)))
                        {
                            group.Add(current);
                        }
                        else
                        {
                            group = new List<TSource> { current };
                            results.Add(group);
                        }
                    }
                }
            }

            return results;
        }
    }
}
