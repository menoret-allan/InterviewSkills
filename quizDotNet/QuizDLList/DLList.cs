﻿using System.Collections.Generic;
using System.Text;
using QuizDLList.Exception;

namespace QuizDLList
{

    public class DlList<E>
    {
        private DNode<E> Head { get; set; }
        private DNode<E> Tail { get; set; }

        public int Size { get; private set; }

        public DlList(params E[] es)
        {
            InitDdList();

            if (null == es || es.Length == 0) return;

            foreach (var e in es)
            {
                AddLast(e);
            }
        }

        private void InitDdList()
        {
            Head = new DNode<E>();
            Tail = new DNode<E>();

            Size = 0;

            Head.Next = Tail;
            Tail.Previous = Head;
        }

        private DNode<E> GetNext(DNode<E> referenceNode)
        {
            if (referenceNode == Tail)
                throw new BoundaryViolationException("Reference node cannot be equal to the tail");

            return referenceNode.Next;
        }

        private DNode<E> GetPrev(DNode<E> referenceNode)
        {
            if (referenceNode == Head)
                throw new BoundaryViolationException("Reference node cannot be equal to the head");

            return referenceNode.Previous;
        }

        private void AddBefore(DNode<E> referenceNode, E element)
        {
            var prevNode = this.GetPrev(referenceNode);
            var newNode = new DNode<E>(element, prevNode, referenceNode);

            referenceNode.Previous = newNode;
            prevNode.Next = newNode;

            Size++;
        }

        private void AddAfter(DNode<E> referenceNode, E element)
        {
            var nextNode = this.GetNext(referenceNode);
            var newNode = new DNode<E>(element, referenceNode, nextNode);

            referenceNode.Next = newNode;
            nextNode.Previous = newNode;

            Size++;
        }

        public void AddFirst(E element)
        {
            AddAfter(Head, element);
        }

        public void AddLast(E element)
        {
            AddBefore(Tail, element);
        }

        private E Remove(DNode<E> removeNode)
        {
            var prevNode = this.GetPrev(removeNode);
            var nextNode = this.GetNext(removeNode);

            removeNode.Previous = null;
            removeNode.Next = null;

            prevNode.Next = nextNode;
            nextNode.Previous = prevNode;

            Size--;

            return removeNode.Element;
        }

        public E RemoveLast()
        {
            RemoveCheckEmptyList();

            return this.Remove(this.GetPrev(Tail));
        }

        public E RemoveFirst()
        {
            RemoveCheckEmptyList();

            return this.Remove(this.GetNext(Head));
        }

        private void RemoveCheckEmptyList()
        {
            if (this.IsEmpty())
                throw new EmptyListException("Double Linked list is empty, cannot remove element");
        }

        public void Clear()
        {
            this.InitDdList();
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public override string ToString()
        {
            var str = new List<string>();

            if (null != Head)
            {
                var probe = Head.Next;

                while (probe != Tail)
                {
                    str.Add(probe.ToString());
                    probe = probe.Next;
                }
            }

            var builder = new StringBuilder();
            builder.Append("[");
            builder.Append(string.Join(" ", str));
            builder.Append("]");
            return builder.ToString();
        }
    }

}
