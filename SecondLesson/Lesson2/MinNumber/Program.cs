using System;
using MyMethods;

namespace MinNumber
{
    //Скворцов А.В.
    // 1. Написать метод, возвращающий минимальное из трёх чисел.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательно 3 числа");
            MinNumber(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
        }

        private static void MinNumber(string a, string b, string c)
        {
            long first = UsefulThings.CheckAndSetParamLong(a);
            long second = UsefulThings.CheckAndSetParamLong(b);
            long third = UsefulThings.CheckAndSetParamLong(c);
            long min;

            //Сравниваем конструкцией if
            if (first >= second)
            {
                if (second >= third) min = third;
                else min = second;
            }
            else min = first;
            Console.WriteLine($"Конструкция if. Минимальное число: {min}");

            //Сравниваем через Math.Min
            min = Math.Min(first, second >= third ? second : third);
            Console.WriteLine($"Конструкция Math.Min. Минимальное число: {min}");
        }
    }
}
