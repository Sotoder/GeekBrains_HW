using MyLib;
using System;
using System.Collections.Generic;

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

        public void Pause()
        {
            Print("Нажмите любую клавишу для продолжения");
            Console.ReadKey(true);
        }

        public void SpecifyParams(ref int startNum, ref int step, ref int lenth)
        {
            Print("Задайте длинну массива: ");
            lenth = CheckAndSetParam(Console.ReadLine());
            Print("Укажите значение первого элемента массива: ");
            startNum = CheckAndSetParam(Console.ReadLine());
            Print("Задайте шаг прогрессии: ");
            step = CheckAndSetParam(Console.ReadLine());

        }

        public int GetOperationsNum(out int multiplier)
        {
            PrintLn("\nНажмите 1 - Сумма всех элементов массива\n" +
                "Нажмите 2 - Обратные значения элементов массива\n" +
                "Нажмите 3 - Умножение всех элементов массива\n" +
                "Для выхода нажмите Escape\n");
            ConsoleKey choise = Console.ReadKey(true).Key;
            bool flag = false;
            int result = 0;
            multiplier = 0;

            while (!flag)
            {
                if (choise != ConsoleKey.D1 && choise != ConsoleKey.D2 && choise != ConsoleKey.D3 && choise != ConsoleKey.Escape)
                {
                    PrintLn("Необходимо нажать 1, 2, 3 или Escape. Повторите ввод\n");
                    choise = Console.ReadKey(true).Key;
                }
                else
                {
                    switch (choise)
                    {
                        case ConsoleKey.D1:
                            result = 1;
                            break;
                        case ConsoleKey.D2:
                            result = 2;
                            break;
                        case ConsoleKey.D3:
                            result = 3;
                            Print($"Укажите множитель: ");
                            multiplier = CheckAndSetParam(Console.ReadLine());
                            break;
                        case ConsoleKey.Escape:
                            result = 4;
                            break;
                    }
                    flag = true;
                }
            }
            return result;
        }

        internal void ShowMax(int max)
        {
            PrintLn($"{max}");
        }

        internal void ShowMaxCount(int maxCount)
        {
            PrintLn($"{maxCount}");
        }

        public void ShowEntrys(Dictionary<int, int> dictionary)
        {
            foreach (KeyValuePair<int, int> element in dictionary)
                PrintLn($"Элемент: {element.Key}, вхождений: {element.Value}");
        }

        public void ShowMult(MyArray arr)
        {
            PrintLn($"Мультиплицированный массив: ");
            ShowArray(arr);
        }

        public void ShowInverse(int[] invertArr)
        {
            PrintLn($"Инвертированный массив: ");
            ShowArray(invertArr);
        }

        public void ShowSum(int i)
        {
            PrintLn($"Сумма всех элементов массива: {i}");
        }

        public void ShowArray(MyArray arr)
        {
            string msg;
            for (int i = 0; i < arr.Count; i++)
            {
                msg = i % 5 == 0 ? $"\n{arr[i]}" : $"{arr[i]}";
                Print(msg.PadRight(7) + "|");
            }
        }

        public void ShowArray(int[] arr)
        {
            string msg;
            for (int i = 0; i < arr.Length; i++)
            {
                msg = i % 5 == 0 ? $"\n{arr[i]}" : $"{arr[i]}";
                Print(msg.PadRight(7) + "|");
            }
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
