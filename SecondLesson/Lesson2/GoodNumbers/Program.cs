using System;

namespace GoodNumbers
{
    //Скворцов А.В.
    //*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
    //«Хорошим» называется число, которое делится на сумму своих цифр.
    //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
    class Program
    {
        static void Main(string[] args)
        {
            int min = 1, max = 1000000000;
            CountGoodNumbers(min, max);
        }

        private static void CountGoodNumbers(int min, int max)
        {

            int count = 0, numForCheck, numForMod;

            DateTime start = DateTime.Now;
            for (int i = min; i <= max; i++)
            {
                numForCheck = i;
                numForMod = 0;
                while (numForCheck != 0)
                {
                    numForMod += numForCheck % 10;
                    numForCheck /= 10;
                }
                if (i % numForMod == 0) count++;
            }
            DateTime end = DateTime.Now;
            string minutesStr = (end - start).Minutes < 10 ? $"0{(end - start).Minutes} мин. " : $"{(end - start).Minutes} мин. ";
            string secondsStr = (end - start).Seconds < 10 ? $"0{(end - start).Seconds} сек." : $"{(end - start).Seconds} сек.";
            Console.WriteLine($"Количество хороших чисел: {count}");
            Console.WriteLine("Время выполнения: " + minutesStr + secondsStr);
        }
    }
}
