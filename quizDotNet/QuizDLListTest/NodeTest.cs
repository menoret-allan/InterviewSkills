using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizDLList;

namespace QuizDLListTest
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void ToStringWhenIntIsNull()
        {
            var sut = new DoubleLinkedListNode<int>();
            Assert.AreEqual("0", sut.ToString());
        }

        [TestMethod]
        public void ToStringWhenStringIsNull()
        {
            var sut = new DoubleLinkedListNode<string>();
            Assert.AreEqual("Empty node", sut.ToString());
        }

        [TestMethod]
        public void ToStringNull()
        {
            var sut = new DoubleLinkedListNode<string>("Testing node", null, null);
            Assert.AreEqual("Testing node", sut.ToString());
        }
    }
}
