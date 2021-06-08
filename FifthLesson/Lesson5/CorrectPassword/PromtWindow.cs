using System;

namespace CorrectPassword
{
    internal class PromtWindow
    {
        private App app;

        public PromtWindow(App app)
        {
            this.app = app;
        }

        public void OpenPrompt()
        {
            Console.WriteLine("Здравствуйте! Вас приветствует программа проверки сложности\n" +
                "пароля. Будем проверять обычно или из под выподверта?\n" +
                "Для обычной проверки нажмите 1\n" +
                "Для проверки из под выподверта нажмите 2\n" +
                "Для выхода из приложения нажмите Escape");
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.Write("Введите пароль: ");
                    app.CheckPassword(Console.ReadLine(),1);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.Write("Введите пароль: ");
                    app.CheckPassword(Console.ReadLine(),2);
                    break;
                case ConsoleKey.Escape:
                    app.Exit();
                    break;
            }
            

        }

        public void ShowResult(int check, int checkType)
        {
            switch (check)
            {
                case 0:
                    Console.Write("\nОтличный пароль!");
                    break;
                case 1:
                    Console.Write("\nПароль не может начинаться с цифры. Повторите ввод: ");
                    app.CheckPassword(Console.ReadLine(), checkType);
                    break;
                case 2:
                    Console.Write("\nПароль не может быть короче 2 - х символов и длиннее 10.Повторите ввод: ");
                    app.CheckPassword(Console.ReadLine(), checkType);
                    break;
                case 3:
                    Console.Write("\nПароль может содержать только буквы латинского алфавита и цифры. Повторите ввод: ");
                    app.CheckPassword(Console.ReadLine(), checkType);
                    break;
                case 4:
                    Console.Write("\nПустая строка. Повторите ввод: ");
                    app.CheckPassword(Console.ReadLine(), checkType);
                    break;
            };
        }
    }
}