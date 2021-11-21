using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericImplementList
{
    public class _List<T> : IEnumerable
    {
        private int _capacity = 0;
        private const int _defaultCapacity = 4;
        private T[] _items;
        private T[] _temp;
        private int _size;

        public int Count { get => _size; }


        public T this[int i]
        {
            get
            {
                if (i >= _size)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return _items[i];
                }

            }
            set
            {
                if (i >= _size)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    _items[i] = value;
                    //_size++;
                }
            }
        }
        public _List(int capacity)
        {
            _capacity = capacity;
            _items = new T[capacity];
        }
        public _List()
        {

        }
        public void Add(T value)
        {
            EnsureCapacity();
            _items[_size++] = value;
        }
        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (item.Equals(_items[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"Count = {Count}";
        }
        private void EnsureCapacity()
        {
            if (_capacity == 0)
            {
                _capacity = _defaultCapacity;
                _items = new T[_capacity];
            }
            if (_size >= _capacity)
            {
                _capacity *= 2;
                _temp = new T[_items.Length];
                for (int i = 0; i < _temp.Length; i++)
                {
                    _temp[i] = _items[i];
                }
                _items = new T[_capacity];
                for (int i = 0; i < _temp.Length; i++)
                {
                    _items[i] = _temp[i];
                }
                _temp = null;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new _ListEnumerator(_items, _size);
        }



        public class _ListEnumerator : IEnumerator
        {
            private T[] _items;
            private int _size;
            private int count = 0;
            public _ListEnumerator(T[] items, int size)
            {
                _items = items;
                _size = size;
            }
            public object Current { get => _items[count++]; }
            public bool MoveNext()
            {

                return count < _size;
            }
            public void Reset()
            {
                _size = -1;
            }
        }
    }
}
