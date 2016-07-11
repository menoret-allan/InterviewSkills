using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizDLList;
using QuizDLList.Exception;

namespace QuizDLListTest
{

    [TestClass]
    public class DdListUnitTest
    {
        private DlList<string> _dllist;

        [TestInitialize()]
        public void SetUp()
        {
            this._dllist = new DlList<string>("B", "C", "D", "E");
        }

        [TestMethod]
        public void DlListToString()
        {
            Assert.AreEqual("[B C D E]", this._dllist.ToString());

            this._dllist.Clear();

            Assert.AreEqual(0, this._dllist.Size);

            Assert.AreEqual("[]", this._dllist.ToString());
        }

        [TestMethod]
        public void DlListSize()
        {
            Assert.AreEqual(4, this._dllist.Size);

            this._dllist.Clear();

            Assert.AreEqual(0, this._dllist.Size);
        }

        [TestMethod]
        public void DlListIsEmpty()
        {
            Assert.IsFalse(this._dllist.IsEmpty());

            this._dllist.Clear();

            Assert.IsTrue(this._dllist.IsEmpty());
        }

        [TestMethod]
        public void DlListAddElement()
        {
            this._dllist.AddFirst("A");
            Assert.AreEqual("[A B C D E]", this._dllist.ToString());

            Assert.AreEqual(5, this._dllist.Size);

            this._dllist.AddLast("F");
            Assert.AreEqual("[A B C D E F]", this._dllist.ToString());

            Assert.AreEqual(6, this._dllist.Size);
        }

    
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void DlListRemoveElementWithException()
        {
            this._dllist.Clear();

            Assert.AreEqual(0, this._dllist.Size);

            Assert.AreEqual("D", this._dllist.RemoveLast());
        }

        [TestMethod]
        public void DlListRemoveElement()
        {
            Assert.AreEqual("B", this._dllist.RemoveFirst());
            Assert.AreEqual("E", this._dllist.RemoveLast());

            Assert.AreEqual(2, this._dllist.Size);

            Assert.AreEqual("C", this._dllist.RemoveFirst());
            Assert.AreEqual("D", this._dllist.RemoveLast());

            Assert.AreEqual(0, this._dllist.Size);
        }
    }

}
