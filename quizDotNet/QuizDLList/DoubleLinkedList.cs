using System.Collections.Generic;
using QuizDLList.Exception;
using QuizDLList.Extensions;

namespace QuizDLList
{
    /// <summary>
    /// Double Linked List which is a collection that act like a stack and a queue
    /// <para />You can push and pop on the front or the end (no insertion or pop in the middle)
    /// <para />Note that in the implementation the Head and the Tail are empty node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T> Head { get; set; }
        private DoubleLinkedListNode<T> Tail { get; set; }

        public DoubleLinkedList(params T[] es)
        {
            Head = new DoubleLinkedListNode<T>();
            Tail = new DoubleLinkedListNode<T>();
            LinkHeadTail();
            es.ForEach(AddLast);
        }

        public bool IsEmpty
        {
            get  { return Head.Next == Tail; }
        }

        public int Count
        {
            get
            {
                var size = 0;
                var node = Head.Next;
                while (node != Tail)
                {
                    size++;
                    node = node.Next;
                }
                return size;
            }
        }

        /// REMOVE: remove all the implementation of the method
        public void AddFirst(T element)
        {
            var nextNode = Head.Next;
            var newNode = new DoubleLinkedListNode<T>(element, Head, nextNode);

            Head.Next = newNode;
            nextNode.Previous = newNode;
        }

        public void AddLast(T element)
        {
            var prevNode = Tail.Previous;
            var newNode = new DoubleLinkedListNode<T>(element, prevNode, Tail);

            Tail.Previous = newNode;
            prevNode.Next = newNode;
        }

        public T PopFirst()
        {
            PopCheckEmptyList();
            return Pop(Head.Next);
        }

        public T PopLast()
        {
            PopCheckEmptyList();
            return Pop(Tail.Previous);
        }

        public void Clear()
        {
            LinkHeadTail();
        }

        public override string ToString()
        {
            var elements = new List<string>();
            var node = Head.Next;
            while (node != Tail)
            {
                elements.Add(node.Element.ToString());
                node = node.Next;
            }
            return "[" + string.Join(" ", elements) + "]";
        }

        private void LinkHeadTail()
        {
            Head.Next = Tail;
            Tail.Previous = Head;
        }

        /// REMOVE: the 2 first line of the methode
        private static T Pop(DoubleLinkedListNode<T> node)
        {
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            return node.Element;
        }

        private void PopCheckEmptyList()
        {
            if (IsEmpty)
                throw new EmptyListException("Double Linked list is empty, cannot remove element");
        }
    }
}
