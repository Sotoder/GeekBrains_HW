using System;

namespace ShowFIO
{
    class Program
    {
  
        static void Main()
        {
            int x, y;
            string name, sName, city;
            ConsoleComands cc = new ConsoleComands(); //Подключение другого класса, для получения доступа к его методам

            Console.Write("Введите ваше имя:");
            name = Console.ReadLine();
            Console.Write("Введите вашe фамилию:");
            sName = Console.ReadLine();
            Console.Write("Введите город в котором вы проживаете:");
            city = "г. " + Console.ReadLine();

            

            //а) Вывести ФИО и название города
            Console.Clear();
            cc.ChangeColor(ConsoleColor.Red);
            Console.WriteLine($"{name} {sName}\n{city}");
            cc.Pause();
            cc.ResetColor();

            //б) Вывести ФИО и название города по центру
            Console.Clear();
            cc.ChangeColor(ConsoleColor.Green);
            string[] messege = new string[2] { (name + " " + sName), city};
            y = (Console.WindowHeight / 2) - 1 - (messege.Length / 2);

            for (int i = 0; i <= messege.Length-1; i++)
            {
                x = (Console.WindowWidth / 2) - (messege[i].Length / 2);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(messege[i]);
                y = Console.CursorTop;
            }
            
            x = 0;
            y = Console.WindowHeight;
            Console.SetCursorPosition(x, y);
            cc.Pause();
            cc.ResetColor();

            //в) Вывести ФИО и название города по центру используя методы
            CenterPrint(messege);

        }


        private static void TensileAlignment(string[] messegeForPrint, int width, int height) // Отцентровка при изменении размеров окна, убрал блок try, заменив его на каскад if...else для переделки отцентровки
                                                                                              // при сильном сжатии окна, теперь работает лучше, не вызывает экспаншен по оси Y.
                                                                                              // Есть еще один экспаншен на Console.Clear() и установку координат - если прям в ноль окно. 
                                                                                              // Я так понимаю полностью уменьшенное окно консоли нельзя очистить и ему нельзя задать какие-либо координаты.
                                                                                              // Я обернул все это в try - не знаю сколь это правильно, но по хорошему если задать координату нельзя
                                                                                              // лучше её не задавать совсем.
                                                                                              // Ну и вопрос: По хорошему, в крупных проектах, лучше использовать try для обхода ошибок или
                                                                                              // вот так, каскадом if-ов, это тоже допустимо?
        {
            int x, y;  
            while (true) 
            {
                try
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

                            if (x < 0)
                            {
                                if (y < 0)
                                {
                                    if (i == 0) { Console.SetCursorPosition(0, 0); }
                                    else { Console.SetCursorPosition(0, Console.CursorTop); }
                                }
                                else { Console.SetCursorPosition(0, y); }
                            }
                            else { Console.SetCursorPosition(x, y); }
                            Console.WriteLine(messegeForPrint[i]);
                            y = Console.CursorTop;
                        }

                    }
                }
                catch { }
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
