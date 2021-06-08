using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Anagramma
{
    internal class Parser
    {
        private App app;
        private Dictionary<char, int> occurrencesOfLetters;

        public Parser(App app)
        {
            this.app = app;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            this.occurrencesOfLetters = dict;
        }
        private string GetRegString
        {
            get
            {
                string regStrPart1 = "";
                string regStrPart2 = "";
                string result = "";
                int wordLenth = 0;

                foreach (KeyValuePair<char, int> element in occurrencesOfLetters)
                {
                    for (int i = 1; i < element.Value + 2; i++)
                    {

                        if (i == element.Value + 1)
                        {
                            regStrPart1 += ".*" + element.Key + ")";
                        }
                        else if (i == 1)
                        {
                            regStrPart1 += "(?!.*" + element.Key;
                        }
                        else
                        {
                            regStrPart1 += ".*" + element.Key;
                        }
                    }
                    regStrPart2 += element.Key;
                    wordLenth += element.Value;
                }
                regStrPart2 = "[" + regStrPart2 + "]";

                result = "^" + regStrPart1 + regStrPart2 + "{" + wordLenth + "}$";
                return result;
            }
        }

        public bool OneRunMethod(string word, string wordForCompare)
        {
            int check = word.Length;

            if (word.Length != wordForCompare.Length) return false;
            else if (word.Equals(wordForCompare)) return true;
            else
            {
                Dictionary<char, int> dict = new Dictionary<char, int>(occurrencesOfLetters);

                foreach (char a in wordForCompare)
                {
                    dict.TryGetValue(a, out int count);
                    if (count > 0)
                    {
                        dict[a] = count - 1;
                    } else
                    {
                        check -= 1;
                    }
                }
            }
            return word.Length == check ? true : false;
        }

        public bool SortMethod(string word, string wordForCompare)
        {
            if (word.Length != wordForCompare.Length) return false;
            else if (word.Equals(wordForCompare)) return true;
            else
            {
                char[] word1 = word.ToCharArray();
                char[] word2 = wordForCompare.ToCharArray();

                Array.Sort(word1);
                Array.Sort(word2);

                return String.Concat<char>(word1).Equals(String.Concat<char>(word2));
            }
        }

        public bool EliminationMethod(string word, string wordForCompare)
        {

            if (word.Length != wordForCompare.Length) return false;
            else if (word.Equals(wordForCompare)) return true;
            else
            {
                foreach (char l in word)
                {
                    for (int i = 0; i < wordForCompare.Length; i++)
                    {
                        if (l == wordForCompare[i])
                        {
                            wordForCompare = wordForCompare.Remove(i, 1);
                            break;
                        }
                    }
                }
                if (wordForCompare.Length == 0) return true;
                else return false;
            }

        }

        public bool CountRepetitions(string word)
        {
            CountEntrys(word);
            bool moreThenThree = false;
            foreach (KeyValuePair<char, int> element in occurrencesOfLetters)
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
            word = CreateReg(@"[^\wА-я]*(_+)*").Replace(word,"").ToLower();
        }

        public bool RegularMethod(string wordForCompare)
        {
            string regStr = GetRegString;
            return CreateReg(regStr).IsMatch(wordForCompare);
        }

        public void CountEntrys(string word)
        {
            foreach (char a in word)
            {
                if (occurrencesOfLetters.TryGetValue(a, out int value))
                    occurrencesOfLetters[a] += 1;
                else
                    occurrencesOfLetters.Add(a, 1);
            }
        }

        private Regex CreateReg(string regStr)
        {
            Regex myReg = new Regex(regStr);
            return myReg;
        }
    }
}