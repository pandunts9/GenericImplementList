using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericImplementList
{
    class Program
    {
        static void Main(string[] args)
        {
            _List<int> _list = new _List<int>();
            _list.Add(14);
            _list.Add(18);
            _list.Add(74);
            _list.Add(17);
            _list.Add(177);
            _list[4] = 588;
            Console.WriteLine(_list[4]);
            foreach (var item in _list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(_list.Contains(17));
            _list.Clear();
        }
    }

}
