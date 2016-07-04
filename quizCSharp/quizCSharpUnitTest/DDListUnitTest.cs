using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuizCSharp.viseo.quiz;
using QuizCSharp.viseo.quiz.exception;

namespace quizCSharpUnitTest
{

    [TestClass]
    public class DDListUnitTest
    {
        private DLList<string> dllist;

        [TestInitialize()]
        public void setUp()
        {
            this.dllist = new DLList<string>("B", "C", "D", "E");
        }

        [TestMethod]
        public void DLListToString()
        {
            Assert.AreEqual("[B C D E]", this.dllist.ToString());

            this.dllist.Clear();

            Assert.AreEqual(0, this.dllist.Size);

            Assert.AreEqual("[]", this.dllist.ToString());
        }

        [TestMethod]
        public void DLListSize()
        {
            Assert.AreEqual(4, this.dllist.Size);

            this.dllist.Clear();

            Assert.AreEqual(0, this.dllist.Size);
        }

        [TestMethod]
        public void DLListIsEmpty()
        {
            Assert.IsFalse(this.dllist.IsEmpty());

            this.dllist.Clear();

            Assert.IsTrue(this.dllist.IsEmpty());
        }

        [TestMethod]
        public void DLListAddElement()
        {
            this.dllist.AddFirst("A");
            Assert.AreEqual("[A B C D E]", this.dllist.ToString());

            Assert.AreEqual(5, this.dllist.Size);

            this.dllist.AddLast("F");
            Assert.AreEqual("[A B C D E F]", this.dllist.ToString());

            Assert.AreEqual(6, this.dllist.Size);
        }

    
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void DLListRemoveElementWithException()
        {
            this.dllist.Clear();

            Assert.AreEqual(0, this.dllist.Size);

            Assert.AreEqual("D", this.dllist.RemoveLast());
        }

        [TestMethod]
        public void DLListRemoveElement()
        {
            Assert.AreEqual("B", this.dllist.RemoveFirst());
            Assert.AreEqual("E", this.dllist.RemoveLast());

            Assert.AreEqual(2, this.dllist.Size);

            Assert.AreEqual("C", this.dllist.RemoveFirst());
            Assert.AreEqual("D", this.dllist.RemoveLast());

            Assert.AreEqual(0, this.dllist.Size);
        }
    }

}
