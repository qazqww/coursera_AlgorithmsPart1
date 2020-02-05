using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace coursera_algorithms02
{
    class ListIterator<Item> : IEnumerator<Item>
    {        
        object IEnumerator.Current => throw new NotImplementedException();

        Node<Item> current;

        public Item Current { get; }

        public bool MoveNext()
        {
            if (Current != null)
            {
                Item item = current.item;
                current = current.next;
                return true;
            }
            return false;
        }
        public void Reset()
        {

        }
        public void Dispose()
        {

        }
    }
}