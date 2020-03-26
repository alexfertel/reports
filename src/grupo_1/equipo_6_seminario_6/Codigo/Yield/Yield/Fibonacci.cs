using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class FibonacciSimulandoYield : IEnumerable<int>
    {
        public FibonacciSimulandoYield() { }

        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FibonacciEnumerator : IEnumerator<int>
    {
        int primer_fibonacci;
        int segundo_fibonacci;
        int cursor;
        int current;

        public FibonacciEnumerator()
        {
            primer_fibonacci = 1;
            segundo_fibonacci = 0;
            cursor = primer_fibonacci + segundo_fibonacci;
        }

        public int Current
        {
            get
            {
                return current;
            }
        }

        public void Dispose()
        {
            return;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            while (true)
            {
                current = cursor;
                int aux = primer_fibonacci;
                primer_fibonacci = segundo_fibonacci;
                segundo_fibonacci = cursor;
                cursor = primer_fibonacci + segundo_fibonacci;
                return true;
            }
        }

        public void Reset()
        {
            primer_fibonacci = 1;
            segundo_fibonacci = 0;
            cursor = primer_fibonacci + segundo_fibonacci;
        }
    }
}
