package viseo.quiz;

public class DNode<E> {

    private E element;

    private DNode<E> previous;
    private DNode<E> next;

    /**
     * @param element
     * @param previous
     * @param next
     */
    public DNode(E element, DNode<E> previous, DNode<E> next) {
        this.element = element;

        this.previous = previous;
        this.next = next;
    }

    @Override
    public String toString() {
        return null == element ? null : element.toString();
    }

    public E getElement() {
        return element;
    }

    public DNode<E> getPrevious() {
        return previous;
    }

    public void setPrevious(DNode<E> previous) {
        this.previous = previous;
    }

    public DNode<E> getNext() {
        return next;
    }

    public void setNext(DNode<E> next) {
        this.next = next;
    }

}
