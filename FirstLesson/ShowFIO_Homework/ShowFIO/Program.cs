using System;

namespace ShowFIO
{
    class Program
    {
        static void Main()
        {
            int x, y;
            string name, sName, city;

            Console.Write("Введите ваше имя:");
            name = Console.ReadLine();
            Console.Write("Введите вашe фамилию:");
            sName = Console.ReadLine();
            Console.Write("Введите город в котором вы проживаете:");
            city = "г. " + Console.ReadLine();



            //а) Вывести ФИО и название города
            Console.Clear();
            Console.WriteLine($"{name} {sName}\n{city}");
            ConsolePause();

            //б) Вывести ФИО и название города по центру
            Console.Clear();
            string[] messege = new string[2] { (name + " " + sName), city};
            y = (Console.WindowHeight / 2) - 1 - (messege.Length / 2);

            for (int i = 0; i <= messege.Length; i++)
            {
                if (i <= messege.Length - 1)
                {
                    x = (Console.WindowWidth / 2) - (messege[i].Length / 2);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(messege[i]);
                    y = Console.CursorTop;
                } else
                {
                    x = 0;
                    y = Console.WindowHeight;
                    Console.SetCursorPosition(x, y);
                    ConsolePause();
                }

            }

            //в) Вывести ФИО и название города по центру используя методы
            CenterPrint(messege);

        }

        private static void ConsolePause()
        {
            Console.Write("Для продолжения нажмите любую клавишу");
            Console.ReadLine();
        }

        private static void TensileAlignment(string[] messegeForPrint, int width, int height) // Отцентровка при изменении размеров окна, и по хорошему тут не хватает более адекватной проверки
                                                                                              // на выход курсора из ренжа координат при слишком сильном сжатии окна,
                                                                                              // эта ломается если сжимать окно не по ширине, а по высоте.
                                                                                              // Есть еще один экспаншен на Console.Clear() - если прям в ноль окно сжать по диагонали, но его я не понял нахрапом 
                                                                                              // Ну и работать это будет как я понимаю только в ОП Windows, без проверки совместимости платформы.
        {
            int x, y;  
            while (true) 
            {
                if (width != Console.WindowWidth || height != Console.WindowHeight)
                {
                    Console.Clear();
                    width = Console.WindowWidth;
                    height = Console.WindowHeight;
                    y = (height / 2) - 1 - (messegeForPrint.Length / 2);
                    for (int i = 0; i <= messegeForPrint.Length - 1; i++)
                    {
                        x = (width / 2) - (messegeForPrint[i].Length / 2);
                        try
                        {
                            Console.SetCursorPosition(x, y);
                        }
                        catch
                        {
                            Console.WindowWidth = messegeForPrint[0].Length;
                            Console.WindowHeight = 20;
                        }                       
                        Console.WriteLine(messegeForPrint[i]);
                        y = Console.CursorTop;
                    }

                }
            }

        }

        private static void CenterPrint(string[] messegeForPrint) // Метод вывода центра по тексту
        {
            int x, y;
            Console.Clear();
            y = (Console.WindowHeight / 2) - 1 - (messegeForPrint.Length / 2);

            for (int i = 0; i <= messegeForPrint.Length - 1; i++)
            {
                x = (Console.WindowWidth / 2) - (messegeForPrint[i].Length / 2);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(messegeForPrint[i]);
                y = Console.CursorTop;
            }
            TensileAlignment(messegeForPrint, Console.WindowWidth, Console.WindowWidth);
        }
    }
}
