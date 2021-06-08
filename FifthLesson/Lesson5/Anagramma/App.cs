using System;
using System.Timers;

namespace Anagramma
{
    public class App
    {
        PromtWindow pt;
        Parser parser;

        internal void StartApp(App app)
        {
            PromtWindow pt = new PromtWindow(app);
            this.pt = pt;
            Parser parser = new Parser(app);
            this.parser = parser;
            pt.OpenWindow();
        }

        public void CatchWord(string word, string wordForCompare)
        {
            DateTime start; 

            start = DateTime.Now;
            bool isAnagrammReg = parser.RegularMethod(wordForCompare);
            TimeSpan regTime = DateTime.Now.Subtract(start);

            start = DateTime.Now;
            bool isAnagrammElim = parser.EliminationMethod(word, wordForCompare);
            TimeSpan elimTime = DateTime.Now.Subtract(start);

            start = DateTime.Now;
            bool isAnagrammSort = parser.SortMethod(word, wordForCompare);
            TimeSpan sortTime = DateTime.Now.Subtract(start);

            start = DateTime.Now;
            bool isAnagrammOneRun = parser.OneRunMethod(word, wordForCompare);
            TimeSpan oneRunTime = DateTime.Now.Subtract(start);

            pt.ShowResult(isAnagrammReg, regTime, isAnagrammElim, elimTime, isAnagrammSort, sortTime, isAnagrammOneRun, oneRunTime);
        }

        public bool СheckNumberOfRepetitions(string word)
        {
            bool check = parser.CountRepetitions(word);
            return check;
        }

        public void ClearWord(ref string word)
        {
            parser.NonLetterAndNumDeleter(ref word);
        }
    }
}