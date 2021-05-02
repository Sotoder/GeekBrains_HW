using System;
using MyMethods;

namespace Recursion
{
    //Скворцов А.В.
    class Program
    {
        public string resultStr="";
        public int resultSum = 0;
        static void Main(string[] args)
        {
            Program program = new();
            program.InputNumbers();
        }

        private void InputNumbers()
        {
            UsefulThings ut = new();
            bool flag = false;
            Console.Write("Введите число а:");
            int a = ut.CheckAndSetParamInt(Console.ReadLine());
            Console.Write("Введите число b:");
            int b = ut.CheckAndSetParamInt(Console.ReadLine());

            while (!flag)
            {
                if (a > b)
                {
                    Console.WriteLine("Число a должно быть больше числа b.\nПовторите ввод");
                    Console.Write("Введите число а:");
                    a = ut.CheckAndSetParamInt(Console.ReadLine());
                    Console.Write("Введите число b:");
                    b = ut.CheckAndSetParamInt(Console.ReadLine());
                }
                else
                {
                    flag = true;
                }
            }

            Console.WriteLine($"Последовательность чисел от {a} до {b}: {WriteSequence(a, b)}");
            Console.WriteLine($"Сумма всех чисел от {a} до {b}: {WriteSum(a, b)}");
        }

        //б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.
        private object WriteSum(int a, int b)
        {
            if (a <= b)
            {
                WriteSum(a, b - 1);
                resultSum += b;
            }
            return resultSum;
        }

        ////a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        private string WriteSequence(int a, int b)
        {
            if (a <= b)
            {
                WriteSequence(a, b-1);
                resultStr += b.ToString() + " ";
            }
            return resultStr;
        }
    }
}
