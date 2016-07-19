using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizDLList;
using QuizDLList.Exception;

namespace QuizDLListTest
{
    [TestClass]
    public class DoubleLinkedListTest
    {
        private DoubleLinkedList<string> _dllist;

        [TestInitialize]
        public void SetUp()
        {
            _dllist = new DoubleLinkedList<string>("B", "C", "D", "E");
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(4, _dllist.Count);
        }

        [TestMethod]
        public void ToStringOverride()
        {
            Assert.AreEqual("[B C D E]", _dllist.ToString());
        }

        [TestMethod]
        public void IsEmpty()
        {
            Assert.IsFalse(_dllist.IsEmpty);
            _dllist.Clear();
            Assert.IsTrue(_dllist.IsEmpty);
        }

        [TestMethod]
        public void AddLastElement()
        {
            _dllist.AddLast("F");
            Assert.AreEqual("[B C D E F]", _dllist.ToString());
        }

        [TestMethod]
        public void AddFirstElement()
        {
            _dllist.AddFirst("A");
            Assert.AreEqual("[A B C D E]", _dllist.ToString());
        }

        [TestMethod]
        public void AddFirstElementFront()
        {
            var newList = new DoubleLinkedList<int>();
            newList.AddFirst(42);
            newList.AddFirst(69);
            Assert.AreEqual("[69 42]", newList.ToString());
        }

        [TestMethod]
        public void Clear()
        {
            _dllist.Clear();
            Assert.AreEqual(true, _dllist.IsEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void RemoveElementWithException()
        {
            var emptyList = new DoubleLinkedList<float>();
            emptyList.PopLast();
        }

        [TestMethod]
        public void PopFirst()
        {
            Assert.AreEqual("B", _dllist.PopFirst());
            Assert.AreEqual("[C D E]", _dllist.ToString());
        }

        [TestMethod]
        public void PopLast()
        {
            Assert.AreEqual("E", _dllist.PopLast());
            Assert.AreEqual("[B C D]", _dllist.ToString());
        }

        [TestMethod]
        public void PopAllElements()
        {
            Assert.AreEqual("B", _dllist.PopFirst());
            Assert.AreEqual("E", _dllist.PopLast());

            Assert.AreEqual("[C D]", _dllist.ToString());

            Assert.AreEqual("C", _dllist.PopFirst());
            Assert.AreEqual("D", _dllist.PopLast());

            Assert.AreEqual("[]", _dllist.ToString());
        }

        [TestMethod]
        [Timeout(200)]
        public void PopFirstAllElements()
        {
            while (!_dllist.IsEmpty)
                _dllist.PopFirst();

            Assert.AreEqual("[]", _dllist.ToString());
        }

        [TestMethod]
        [Timeout(200)]
        public void PopLastAllElements()
        {
            while (!_dllist.IsEmpty)
                _dllist.PopLast();

            Assert.AreEqual("[]", _dllist.ToString());
        }
    }
}
