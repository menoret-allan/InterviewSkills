package viseo.quiz;

import viseo.quiz.exception.BoundaryViolationException;
import viseo.quiz.exception.EmptyListException;

import java.util.StringJoiner;

import static java.util.Arrays.stream;

public class DLList<E> {

    private DNode<E> head;

    private DNode<E> tail;

    private int size;

    public DLList(E... es) {
        this.initDDList();

        if (null != es && es.length != 0) {
            stream(es).forEach(this::addLast);
        }
    }

    private void initDDList() {
        this.head = new DNode<>(null, null, null);
        this.tail = new DNode<>(null, null, null);

        this.size = 0;

        this.head.setNext(this.tail);
        this.tail.setPrevious(this.head);
    }

    private DNode<E> getNext(DNode<E> referenceNode) throws BoundaryViolationException {
        if (referenceNode == tail)
            throw new BoundaryViolationException("Reference node cannot be equal to the tail");

        return referenceNode.getNext();
    }

    private DNode<E> getPrev(DNode<E> referenceNode) throws BoundaryViolationException {
        if (referenceNode == head)
            throw new BoundaryViolationException("Reference node cannot be equal to the head");

        return referenceNode.getPrevious();
    }

    private void addBefore(DNode<E> referenceNode, E element) {
        DNode<E> prevNode = this.getPrev(referenceNode);

        DNode<E> newNode = new DNode<>(element, prevNode, referenceNode);
        referenceNode.setPrevious(newNode);
        prevNode.setNext(newNode);

        size++;
    }

    private void addAfter(DNode<E> referenceNode, E element) {
        DNode<E> nextNode = this.getNext(referenceNode);

        DNode<E> newNode = new DNode<>(element, referenceNode, nextNode);
        referenceNode.setNext(newNode);
        nextNode.setPrevious(newNode);

        size++;
    }

    public void addFirst(E element) {
        this.addAfter(head, element);
    }

    public void addLast(E element) {
        this.addBefore(tail, element);
    }

    public E remove(DNode<E> removeNode) {
        DNode<E> prevNode = this.getPrev(removeNode);
        DNode<E> nextNode = this.getNext(removeNode);

        removeNode.setPrevious(null);
        removeNode.setNext(null);

        prevNode.setNext(nextNode);
        nextNode.setPrevious(prevNode);

        size--;

        return removeNode.getElement();
    }

    public E removeLast() throws EmptyListException {
        this.removeCheckEmptyList();

        return this.remove(this.getPrev(tail));
    }

    public E removeFirst() throws EmptyListException {
        this.removeCheckEmptyList();

        return this.remove(this.getNext(head));
    }

    private void removeCheckEmptyList() throws EmptyListException {
        if (this.isEmpty())
            throw new EmptyListException("Double Linked list is empty, cannot remove element");
    }

    public void clear() {
        this.initDDList();
    }

    public boolean isEmpty() {
        return this.size == 0;
    }

    public int size() {
        return this.size;
    }

    public DNode<E> getHead() {
        return head;
    }

    public DNode<E> getTail() {
        return tail;
    }

    @Override
    public String toString() {

        StringJoiner stringJoiner = new StringJoiner(" ", "[", "]");

        if (null != head) {
            DNode<E> probe = head.getNext();

            while (probe != tail) {
                stringJoiner.add(probe.toString());
                probe = probe.getNext();
            }
        }

        return stringJoiner.toString();
    }

}
