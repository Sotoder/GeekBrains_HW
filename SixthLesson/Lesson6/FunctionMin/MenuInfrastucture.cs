using System;

namespace FunctionMin
{
    public class MenuInfrastucture
    {

        public double CheckAndSetParam(string strFromConsole)
        {
            double param = 0;

            while (param == 0)
            {
                if (double.TryParse(strFromConsole, out double checkedDouble))
                {
                    param = checkedDouble;
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые или десятичные числа. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }

        internal void SetParams(out double a, out double b, out double h)
        {
            a = 0;
            b = 0;
            h = 0;

            PrintLn("Здравствуйте!\n" +
                "Задайте отрезок расчета значений функции.\n");


            bool paramCheck = false;
            while (!paramCheck)
            {
                Print("Введите значение а: ");
                a = CheckAndSetParam(Console.ReadLine());
                Print("Введите значение b: ");
                b = CheckAndSetParam(Console.ReadLine());
                Print("Задайте шаг h: ");
                h = CheckAndSetParam(Console.ReadLine());

                if (a > b) PrintLn("Начальная точка отрезка не может быть больше конечной. Повторите ввод");
                else if (h <= 0) PrintLn("Значение шага должно быть больше ноля");
                else paramCheck = true;
            }
        }

        public void Print(string str)
        {
            Console.Write(str);
        }

        public void PrintLn(string str)
        {
            Console.WriteLine(str);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}