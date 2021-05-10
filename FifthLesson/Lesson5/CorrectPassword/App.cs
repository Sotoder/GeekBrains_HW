using System;
using System.IO;

namespace CorrectPassword
{
    public class App
    {
        Parser parser;
        PromtWindow pw;
        public void StartApp(App app)
        {
            Parser parser = new Parser();
            this.parser = parser;
            PromtWindow pw = new PromtWindow(app);
            this.pw = pw;
            pw.OpenPrompt();
        }

        public void CheckPassword(string password, int checkType)
        {
            int check;
            switch (checkType)
            {
                case 1:
                    check = parser.ParsAndCheckPassword(password);
                    pw.ShowResult(check, checkType);
                    break;
                case 2:
                    check = parser.RegularCheckPassword(password);
                    pw.ShowResult(check, checkType);
                    break;
            }

        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}