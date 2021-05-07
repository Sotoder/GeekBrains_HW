using System;
using Structures.ComplexNumbers;

namespace ComplexNumbers
{
    class ConsoleView
    {
        
        public void Clear()
        {
            Console.Clear();
        }
        public void PrintLine(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Print(string msg)
        {
            Console.Write(msg);
        }

        public Complex GetDataComplex()
        {
            Console.Write("Введите действительную часть числа: ");
            int re = CheckAndSetParameter(Console.ReadLine(),false);
            Console.Write("Введите мнимую часть числа: ");
            int im = CheckAndSetParameter(Console.ReadLine(),false);
            return new Complex(re, im);
        }

        public int GetDataInteger()
        {
            Console.Write("Введите целое число: ");
            int i = CheckAndSetParameter(Console.ReadLine(),false);
            return i;
        }

        public Fractional GetDataFractional()
        {
            Console.Write("Введите числитель: ");
            int num = CheckAndSetParameter(Console.ReadLine(),false);
            Console.Write("Введите знаминатель: ");
            int dev = CheckAndSetParameter(Console.ReadLine(),true);
            return new Fractional(num, dev);
        }

        public int CheckAndSetParameter(string strFromConsole, bool checkZero) // Проверка ввода + проверка знаменателя на ноль
        {
            int param = 0;
            bool flag = false;

            while (!flag)
            {
                if (int.TryParse(strFromConsole, out int checkedInt))
                {
                    if (checkZero)
                    {
                        if (checkedInt == 0)
                        {
                            Console.Write("На ноль делить нельзя! Повторите ввод:");
                            strFromConsole = Console.ReadLine();
                        }
                        else
                        {
                            param = checkedInt;
                            flag = true;
                        }
                    } else
                    {
                        param = checkedInt;
                        flag = true;
                    }

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
