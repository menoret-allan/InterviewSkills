using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizCSharp.viseo.quiz;

namespace quizCSharp
{
    class MainClass
    {
        public static void Main()
        {
            DLList<string> dlList = new DLList<string>("A", "B", "C");
            Console.WriteLine("dList contains : ${0}", dlList);
        }
    }
}
