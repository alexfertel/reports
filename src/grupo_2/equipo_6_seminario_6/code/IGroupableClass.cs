using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario6_Lp
{
    public class IGroupableClass<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public TKey Key { get; set; }

        public IEnumerable<TSource> Sources { get; set; }

        public IGroupableClass(TKey key, IEnumerable<TSource> sources)
        {
            Key = key;
            Sources = sources;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return Sources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    public class Enumerator<TSource> : IEnumerator<TSource>
    {
        public TSource Current 
        {
            get
            {
                try
                {
                    return _sources[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current { get { return Current; } }

        public List<TSource> _sources { get; set; }
        int position = -1;

        public Enumerator(List<TSource> sources)
        {
            _sources = sources;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return (position < _sources.Count());

        }

        public void Reset()
        {
            position = -1;
        }
    }

}
