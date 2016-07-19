namespace QuizDLList
{
    public class DoubleLinkedListNode<T>
    {
        public T Element { get; }
        public DoubleLinkedListNode<T> Previous { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }

        public DoubleLinkedListNode() { }

        public DoubleLinkedListNode(T element, DoubleLinkedListNode<T> previous, DoubleLinkedListNode<T> next)
        {
            Element = element;
            Previous = previous;
            Next = next;
        }

        /// REMOVE: the comment and the '?' between "Element" and ".ToString()"
        public override string ToString()
        {
            return Element?.ToString() ?? "Empty node";
        }
    }
}