using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursera_algorithms02
{
    class Node<Item>
    {
        public Item item;
        public Node<Item> next;
    }

    class Stack<Item>
    {
        Node<Item> first = null;

        public void Push(Item item)
        {
            Node<Item> newNode = new Node<Item> { item = item };
            if (!IsEmpty())
                newNode.next = first;
            first = newNode;
        }

        public Item Pop()
        {
            if (IsEmpty())
                return default;

            Item item = first.item;
            first = first.next;
            return item;
        }

        public bool IsEmpty()
        {
            if (first == null)
                return true;
            return false;
        }
    }

    class Queue<Item>
    {
        Node<Item> first = null;
        Node<Item> last = null;

        public void Enqueue(Item item)
        {
            Node<Item> newNode = new Node<Item>() { item = item, next = null };
            
            if(IsEmpty())
                first = newNode;
            else
                last.next = newNode;

            last = newNode;
        }

        public Item Dequeue()
        {
            if (IsEmpty())
            {
                last = null;
                return default;
            }

            Item item = first.item;
            first = first.next;
            return item;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
    }

    class StacksAndQueues
    {
        static void Main(string[] args)
        {
            //Stack stack = new Stack();
            //stack.Pop();
            //stack.Push("1");
            //stack.Pop();
            //stack.Push("2");
            //stack.Push("3");
            //stack.Push("4");
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();
            //stack.Pop();

            Queue<String> queue = new Queue<string>();
            queue.Enqueue("1");
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Enqueue("4");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}