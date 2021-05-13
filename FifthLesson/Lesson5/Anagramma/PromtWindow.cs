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
                "Слово должно состоять не более чем из 8 букв, содержать не больше 3-х повторяющихся букв.\n" +
                "Заглавные буквы будут преобразованы в строчные. Все пробелы и прочие символы будут удалены\n"+
                ">>>>>>");
            string word = Console.ReadLine();
            bool flag = false;
            
            while(!flag)
            {
                if(CheckAndSendWord(ref word)) flag = true;
                else
                {
                    Console.Write("Слово должно состоять не более чем из 8 букв, содержать не больше 3-х повторяющихся букв\n" +
                        "Повторите ввод: ");
                    word = Console.ReadLine();
                }
            }

            ConsoleKey key = ConsoleKey.A;
            while (key != ConsoleKey.Escape)
            {
                Console.Write("Введите слово, для сравнения: ");
                app.CatchWord(word, Console.ReadLine());
                Console.WriteLine("\nДля продолжения нажмите любую клавишу. Для выхода нажмите Escape\n");
                key = Console.ReadKey(true).Key;
                Console.Clear();
            }
        }

        public void ShowResult(
            bool isAnagrammReg, TimeSpan regTime, 
            bool isAnagrammElim, TimeSpan elimTime, 
            bool isAnagrammSort, TimeSpan sortTime, 
            bool isAnagrammOneRun, TimeSpan oneRunTime)
        {
            string delimitr = "\n-------------------------";

            Console.Write("\nРегулярные выражения: " + (isAnagrammReg ? "Это анаграмма\n": "Это не анаграмма\n") + "Время на сравнение затрачено: " + regTime.TotalSeconds.ToString() + "сек" + delimitr);
            Console.Write("\nМетодом исключения: " + (isAnagrammElim ? "Это анаграмма\n" : "Это не анаграмма\n") + "Время на сравнение затрачено: " + elimTime.TotalSeconds.ToString() + "сек" + delimitr);
            Console.Write("\nМетодом сортировки: " + (isAnagrammSort ? "Это анаграмма\n" : "Это не анаграмма\n") + "Время на сравнение затрачено: " + sortTime.TotalSeconds.ToString() + "сек" + delimitr);
            Console.Write("\nЗа один пробег: " + (isAnagrammOneRun ? "Это анаграмма\n" : "Это не анаграмма\n") + "Время на сравнение затрачено: " + oneRunTime.TotalSeconds.ToString() + "сек" + delimitr);

        }

        private bool CheckAndSendWord(ref string word)
        {
            app.ClearWord(ref word);
            Console.Clear();

            if (word.Length > 8) return false;
            else
            {
                Console.Write($"Слово было очищено от прочих символов. Результат: {word}\n");
                return app.СheckNumberOfRepetitions(word) is true ? true : false;
            } 
        }
    }
}