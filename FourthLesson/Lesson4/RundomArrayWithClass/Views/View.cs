using ArrayFromDll.Models;
using System;

namespace ArrayFromDll.Views
{
    class View
    {

        public void PrintLn(string str)
        {
            Console.WriteLine(str);
        }

        public void Print(string str)
        {
            Console.Write(str);
        }

        public void Clear()
        {
            Console.Clear();
        }

        internal void Pause()
        {
            Console.ReadKey();
        }

        public int SpecifyLenth()
        {
            return CheckAndSetParam(Console.ReadLine());
        }

        
        
        public int LetsChoiseFillType(ref int min, ref int max)
        {
            PrintLn("Давайте заполним массив случайными числами");
            PrintLn("--------------------------------------\nЕсли вы хотите заполнить случайными числами от 0 до х, нажмите 1.\n" +
                "Если вы хотите задать точный интервал, нажмите 2");
            ConsoleKey choise = Console.ReadKey(true).Key;
            bool flag = false;
            int result = 0;
            
            while (!flag)
            {
                if (choise != ConsoleKey.D1 && choise != ConsoleKey.D2)
                {
                    PrintLn("Необходимо нажать 1 или 2. Повторите ввод");
                    choise = Console.ReadKey(true).Key;
                } else
                {
                    if (choise == ConsoleKey.D1)
                    {
                        Print("Задайте число для установки интервала от 0 до х: ");
                        max = CheckAndSetParam(Console.ReadLine());
                        result = 1;
                    } else
                    {
                        PrintLn("Задайте минимальное и максимальне число для установки интервала");
                        min = CheckAndSetParam(Console.ReadLine());
                        max = CheckAndSetParam(Console.ReadLine());
                        result = 2;

                        bool minGreaterMax = false;
                        while (!minGreaterMax)
                        {
                            if (min > max)
                            {
                                PrintLn("Минимальное значение больше максимального. Повторите ввод");
                                min = CheckAndSetParam(Console.ReadLine());
                                max = CheckAndSetParam(Console.ReadLine());
                            }
                            else
                            {
                                minGreaterMax = true;
                            }
                        }
                    }
                    flag = true;
                }
            }
            return result;
        }

        internal void FileNotExist(string path)
        {
            PrintLn($"Файл {path} не найден.\nВыполнение программы будет завершено.");
            PrintLn("Нажмите любую клавишу для продолжения.");
            Console.ReadKey(true);
        }

        public int LetsChoseCreationType()
        {
            ConsoleKey choise = Console.ReadKey(true).Key;
            int result = 0;
            bool flag = false;
            while (!flag)
            {
                if (choise != ConsoleKey.D1 && choise != ConsoleKey.D2)
                {
                    PrintLn("Необходимо нажать 1 или 2. Повторите ввод");
                    choise = Console.ReadKey(true).Key;
                }
                else
                {
                    result = choise == ConsoleKey.D1 ? 1 : 2;
                    flag = true;
                }
            }

            return result;
        }

        public void ShowArray(MyArray arr)
        {
            string msg;
            for (int i = 0; i < arr.Count; i ++)
            {
                msg = i % 3 == 0 ? $"\n{arr[i]}" : $"{arr[i]}";
                Print(msg.PadRight(7)+"|");
            }
        }

        public void ShowTwises(MyArray arr)
        {
            int twiseCount = arr.Count/2;
            Console.WriteLine($"Количество пар: {twiseCount}");
            Console.WriteLine("--------------------------------------\nПары:");
            for (int i = 0; i < arr.Count; i += 2)
            {
                Console.WriteLine($"{arr[i].ToString().PadLeft(7)} : {arr[i + 1].ToString().PadRight(7)}");
            }
        }

        public int GetDivider()
        {
            Print("--------------------------------------\nЗадайте делитель: ");
            return CheckAndSetParam(Console.ReadLine());
        }

        public int CheckAndSetParam(string strFromConsole)
        {
            int param = 0;
            bool flag = false;

            while (!flag)
            {
                if (int.TryParse(strFromConsole, out int checkedLong))
                {
                    param = checkedLong;
                    flag = true;
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые числа, десятичные числа будут округлены. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }
    }
}
