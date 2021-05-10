using System;
using System.IO;

namespace Authorization
{
    class App
    {
        DB arr;

        public App(string path)
        {
            if (File.Exists(path))
            {
                DB arr = new DB(GetUsersFromFile(path));
                this.arr = arr;
            } else
            {
                Console.WriteLine($"Файл {path} не найден. Приложение будет закрыто. \n" +
                    $"Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        
        public void AppStart()
        {
            AuthorizationStart(arr);
        }


        private Accaunt[] GetUsersFromFile(string path) //Заполняем массив из файла
        {
            string login = "";
            string pass = "";

            string[] fromFile = File.ReadAllLines(path);

            Accaunt[] accaunts = new Accaunt[fromFile.GetLength(0)];

            for (int i = 0; i < fromFile.Length; i++)
            {
                string[] temp = fromFile[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)

                    if (j == 0) 
                    {
                        login = temp[j];
                    } else
                    {
                        pass = temp[j];
                    }
                accaunts[i] = new Accaunt(login, pass);
            }
            return accaunts;
        }

        private void AuthorizationStart(DB users)
        {
            string question, login, password = "";
            int tryToEnter = 0;
            bool flag = false;

            do
            {
                question = tryToEnter == 0 ? "Введите логин и пароль для входа" : "Неверный логин и пароль, повторите ввод.";
                Console.WriteLine(question);
                login = Console.ReadLine();

                while (true) //Шоб как в линухе, ввод пароле не виден)))
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    password += key.KeyChar;
                }

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Login.Equals(login) && users[i].Password.Equals(password))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
                tryToEnter++;
            } while (tryToEnter < 3);

            Console.WriteLine(flag ? $"Добро пожаловать в систему {login}" : $"Попытки ввода закончились, система заблокирована");
        }
    }
}
