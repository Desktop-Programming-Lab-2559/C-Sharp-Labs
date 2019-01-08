using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySet
{
    public class MySet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private static readonly object _lock = new object();
        private List<T> _set = new List<T>();

        public int Count
        {
            get { return _set.Count; }
        }

        public MySet()
        {
        }
        public MySet(IEnumerable<T> range)
        {
            _set.AddRange(range);
        }

        public void Add(T item)
        {
            lock (_lock)
            {
                if (!_set.Contains(item))
                    _set.Add(item);
            }
        }

        public void Remove(T item) => _set.Remove(item);

        public bool Contains(T item) => _set.Contains(item);

        public MySet<T> Union(MySet<T> set)
        {
            MySet<T> res = new MySet<T>(_set);
            foreach (var item in set)
            {
                lock (_lock)
                {
                    if (!Contains(item))
                        res.Add(item);
                }
            }
            return res;
        }

        public MySet<T> Intersect(MySet<T> set)
        {
            MySet<T> res = new MySet<T>();
            foreach (var item in _set)
            {
                lock (_lock)
                {
                    if (set.Contains(item))
                        res.Add(item);
                }
            }
            return res;
        }

        public MySet<T> Difference(MySet<T> set)
        {
            MySet<T> res = new MySet<T>(_set);
            foreach (var item in set)
            {
                res.Remove(item);
            }
            return res;
        }

        public MySet<T> SymmetricDifference(MySet<T> set)
        {
            MySet<T> union = Union(set);
            MySet<T> intersect = Intersect(set);
            return union.Difference(intersect);
        }

        public bool IsSubset(MySet<T> set)
        {
            MySet<T> tmpSet = Intersect(set);
            if (_set.Count == tmpSet.Count)
                return true;
            return false;
        }

        public void Show() => _set.ToList().ForEach(e => Console.Write($" {e} "));

        public IEnumerator<T> GetEnumerator() => _set.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _set.GetEnumerator();

        public static MySet<T> operator +(MySet<T> s1, MySet<T> s2) => s1.Union(s2);

        public static MySet<T> operator -(MySet<T> s1, MySet<T> s2) => s1.Difference(s2);

        public static MySet<T> operator *(MySet<T> s1, MySet<T> s2) => s1.Intersect(s2);

        public static MySet<T> operator %(MySet<T> s1, MySet<T> s2) => s1.SymmetricDifference(s2);

        public static bool operator <(MySet<T> s1, MySet<T> s2) => s1.IsSubset(s2);

        public static bool operator >(MySet<T> s1, MySet<T> s2) => s2.IsSubset(s1);
    }
}
