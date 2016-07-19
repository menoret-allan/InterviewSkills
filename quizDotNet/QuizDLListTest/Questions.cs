using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuizDLListTest
{
    [TestClass]
    public class Questions
    {
        // You should answer to these questions with basic answers.
        // It's to complete the coding test if you failed it or you want bonuses

        [TestMethod]
        public void DifferenceBetweenListAndArray()
        {
            var question = "What is the difference between a linked list and an array?";
            var answer = "";

            // Remove: answer affectation
            answer = "A linked list is made of node which are not following each other in memory." +
                     "An array is made of row which are following each other in the memory.";

            Assert.AreNotEqual(answer, "");
        }

        [TestMethod]
        public void UsesListAndArray()
        {
            var question = "In which case would you, use a linked list either than an array?";
            var answer = "";

            // Remove: answer affectation
            answer = "I would uses linked list if I have deletion and insertion operations" +
                     "I would use an array if I don't have insertion or deletion.";

            Assert.AreNotEqual(answer, "");
        }

        [TestMethod]
        public void GiveUsSomeListType()
        {
            var question = "What is a difference between a double linked list, a stack and a queue?";
            var answer = "";

            // Remove: answer affectation
            answer = "Double linked list: you can insert or pop where ever you want in the list" +
                     "Stack: FIFO" +
                     "Queue: LIFO";

            Assert.AreNotEqual(answer, "");
        }
    }

}
