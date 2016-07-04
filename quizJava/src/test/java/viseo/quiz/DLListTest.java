package viseo.quiz;

import org.junit.Before;
import org.junit.Test;
import viseo.quiz.exception.BoundaryViolationException;
import viseo.quiz.exception.EmptyListException;

import static org.junit.Assert.*;

public class DLListTest {

    private DLList<String> dllist;

    @Before
    public void setUp() {
        this.dllist = new DLList<>("B", "C", "D", "E");
    }

    @Test
    public void DLListToString() {
        assertEquals("[B C D E]", this.dllist.toString());

        this.dllist.clear();

        assertEquals(0, this.dllist.size());

        assertEquals("[]", this.dllist.toString());
    }

    @Test
    public void DLListSize() {
        assertEquals(4, this.dllist.size());

        this.dllist.clear();

        assertEquals(0, this.dllist.size());
    }

    @Test
    public void DLListIsEmpty() {
        assertFalse(this.dllist.isEmpty());

        this.dllist.clear();

        assertTrue(this.dllist.isEmpty());
    }

    @Test
    public void DLListAddElement() {
        this.dllist.addFirst("A");
        assertEquals("[A B C D E]", this.dllist.toString());

        assertEquals(5, this.dllist.size());

        this.dllist.addLast("F");
        assertEquals("[A B C D E F]", this.dllist.toString());

        assertEquals(6, this.dllist.size());
    }

    @Test(expected = EmptyListException.class)
    public void DLListRemoveElementWithException() {
        this.dllist.clear();

        assertEquals(0, this.dllist.size());

        assertEquals("D", this.dllist.removeLast());
    }

    @Test(expected = BoundaryViolationException.class)
    public void DLListRemoveElementByIteHead() {

        int count = this.dllist.size();

        while (true) {
            this.dllist.remove(this.dllist.getHead().getNext());
            assertEquals(--count, this.dllist.size());
        }
    }

    @Test(expected = BoundaryViolationException.class)
    public void DLListRemoveElementByIteTail() {

        int count = this.dllist.size();

        while (true) {
            this.dllist.remove(this.dllist.getTail().getPrevious());
            assertEquals(--count, this.dllist.size());
        }
    }

    @Test
    public void DLListRemoveElement() {
        assertEquals("B", this.dllist.removeFirst());
        assertEquals("E", this.dllist.removeLast());

        assertEquals(2, this.dllist.size());

        assertEquals("C", this.dllist.removeFirst());
        assertEquals("D", this.dllist.removeLast());

        assertEquals(0, this.dllist.size());
    }

}
