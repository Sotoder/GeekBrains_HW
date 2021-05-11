using System;

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

        public void CatchWord(string word)
        {
            parser.ParseWord(word);
        }

        public bool СheckNumberOfRepetitions(string word)
        {
            pt.ShowParsingRow(word);
            bool check = parser.CountRepetitions(word);
            return check;
        }

        internal void ClearWord(ref string word)
        {
            parser.NonLetterAndNumDeleter(ref word);
        }
    }
}