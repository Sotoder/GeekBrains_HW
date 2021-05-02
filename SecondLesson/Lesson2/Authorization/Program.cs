using System;

namespace Authorization
{
    //4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
    //На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
    //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
    //С помощью цикла do while ограничить ввод пароля тремя попытками.
    class Program
    {
        static void Main(string[] args)
        {
            AuthorizationStart();
        }

        private static void AuthorizationStart()
        {
            string rightLogin = "root", login;
            string rightPass = "GeekBrains", password = "";
            string question;
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

                if (rightLogin.Equals(login) && rightPass.Equals(password))
                {
                    flag = true;
                    break;
                }
                tryToEnter++;
            } while (tryToEnter < 3);

            Console.WriteLine(flag ? $"Добро пожаловать в систему" : $"Попытки ввода закончились, система заблокирована");
        }
    }
}
