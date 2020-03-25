using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario6_Lp
{
    public static class Grouping
    {
        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            List<IGroupableClass<TKey, TSource>> result = new List<IGroupableClass<TKey, TSource>>();
            List<TKey> keys = new List<TKey>();

            foreach (TSource ts in source)
            {
                TKey key = keySelector(ts);

                if (!keys.Contains(key))
                {
                    keys.Add(key);
                    result.Add(new IGroupableClass<TKey, TSource>(key, FindGroup(key, keySelector, source)));
                }
               
            }
            return result;
        }

        public static IEnumerable<TSource> FindGroup<TKey, TSource>(TKey key,
            Func<TSource, TKey> keySelector,
            IEnumerable<TSource> source)
        {
            List<TSource> result = new List<TSource>();
            foreach (var s in source)
            {
                if (keySelector(s).Equals(key))
                    result.Add(s);
            }
            return result;
        }

        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupByLazy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            List<IGroupableClass<TKey, TSource>> result = new List<IGroupableClass<TKey, TSource>>();
            List<TKey> keys = new List<TKey>();

            foreach (TSource ts in source)
            {
                TKey key = keySelector(ts);

                if (!keys.Contains(key))
                {
                    keys.Add(key);
                    yield return new IGroupableClass<TKey, TSource>(key, FindGroup(key, keySelector, source));
                }

            }
        }

        public static IEnumerable<TSource> MyTake<TSource>(
           this IEnumerable<TSource> source, int count)
        {
            int i = 0;
            foreach (var item in source)
            {
                if (i == count)
                    yield break;
                yield return item;
                i++;
            }
        }
    }
}
