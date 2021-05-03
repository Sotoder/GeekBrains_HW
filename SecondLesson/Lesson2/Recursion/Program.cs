using System;
using MyMethods;

namespace Recursion
{
    //Скворцов А.В.
    class Program
    {
        public string resultStr;
        public int resultSum;
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

            // на всякий случай обнуляем глобальные переменные
            resultStr = "";
            resultSum = 0;
            CalcSumCollectSeq(a, b);

            Console.WriteLine($"Последовательность чисел от {a} до {b}: {resultStr}");
            Console.WriteLine($"Сумма всех чисел от {a} до {b}: {resultSum}");
        }

        private void CalcSumCollectSeq(int a, int b)
        {

            // запускаем рекурсию
            if (a <= b)
            {
                CalcSumCollectSeq(a, b - 1);
                resultSum += b;
                resultStr += (b == a ? "" : ", ") + b.ToString();
            }
        }
    }
}
