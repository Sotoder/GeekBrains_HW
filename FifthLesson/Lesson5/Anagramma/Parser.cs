using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Anagramma
{
    internal class Parser
    {
        private App app;
        private Dictionary<char, int> dictForAll;

        public Parser(App app)
        {
            this.app = app;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            this.dictForAll = dict;
        }

        public bool CountRepetitions(string word)
        {
            CountEntry(word);
            Dictionary<char, int> dictForChek = dictForAll;
            bool moreThenThree = false;
            foreach (KeyValuePair<char, int> element in dictForChek)
            {
                if (element.Value > 3)
                {
                    break;
                }
                else moreThenThree = true;
            }
            return moreThenThree;
        }

        public void NonLetterAndNumDeleter(ref string word)
        {
            word = CreateReg(@"[^\wА-я]*(_+)*").Replace(word,"");
        }

        public void ParseWord(string word)
        {
            string regStr = GetRegString(dictForAll, word);
        }

        private string GetRegString(Dictionary<char, int> dictForAll, string word)
        {
            string resultStr = ""; // Продложить тут. Здесь будет конструктор собирающий регулярную строку относительно имеющихся символов и количества их вхождений в слово
            return resultStr;
        }

        public void CountEntry(string word)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (char a in word)
            {
                if (dictionary.TryGetValue(a, out int value))
                    dictionary[a] += 1;
                else
                    dictionary.Add(a, 1);
            }
            dictForAll = dictionary;
        }

        private Regex CreateReg(string regStr)
        {
            Regex myReg = new Regex(regStr);
            return myReg;
        }
    }
}