using System;

namespace QuizCSharp.viseo.quiz
{
    class DNode<E>
    {
        public E Element { get; set; }

        public DNode<E> Previous { get; set; }
        public DNode<E> Next { get; set; }

        public DNode(E element, DNode<E> previous, DNode<E> next)
        {
            this.Element = element;

            this.Previous = previous;
            this.Next = next;
        }

        public DNode()
        {
        }

        public override String ToString()
        {
            return null == Element ? null : Element.ToString();
        }

    }
}