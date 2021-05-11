using System;

namespace Anagramma
{
    internal class PromtWindow
    {
        public App app;

        public PromtWindow(App app)
        {
            this.app = app;
        }

        public void OpenWindow()
        {
            Console.Write("Здравствуйте!\n" +
                "Введите слово, которое будет использоваться для поиска анаграммы\n" +
                "Слово должно состоять не более чем из 8 букв, содержать не больше 3-х повторяющихся букв. Все пробелы и прочие символы будут удалены\n"+
                ">>>>>>");
            string word = Console.ReadLine();
            bool flag = false;
            
            while(!flag)
            {
                if(CheckAndSendWord(word)) flag = true;
                else
                {
                    Console.Write("Слово должно состоять не более чем из 8 букв, содержать не больше 3-х повторяющихся букв\n" +
                        "Повторите ввод: ");
                    word = Console.ReadLine();
                }
            }
            
            app.CatchWord(word);
        }

        public void ShowParsingRow(string word)
        {
            Console.Write($"Итоговая строка для проверки {word}. Пробелы и символы не являющиеся буквами или цифрами были удалены");
        }

        private bool CheckAndSendWord(string word)
        {
            app.ClearWord(ref word);
            if (word.Length > 8) return false;
            else return app.СheckNumberOfRepetitions(word) is true ? true : false;
        }
    }
}