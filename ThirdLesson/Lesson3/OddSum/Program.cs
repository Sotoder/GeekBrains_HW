using System;
using MyMethods;

namespace OddSum
{
    //Скворцов А.В.
    //С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел.
    //Использовать tryParse для проверки ввода.
    class Program
    {
        
        public static void Main(string[] args)
        {

            Program program = new();
            program.StartTyping();
        }

        private void StartTyping()
        {
            UsefulThings ut = new UsefulThings();
            int sum = 0, i;
            ut.PrintLn("Последовательно вводите целые числа. При вводе 0, программа расчитает сумму нечетных чисел и завершит выполнение.");
            do
            {
                i = ut.CheckAndSetParam(Console.ReadLine());

                if (i > 0)
                {
                    if (i%2 != 0)
                    {
                        sum += i;
                    }
                }

            } while (i != 0);

            ut.PrintLn($"Сумма введенных нечетных чисел: {sum}");
        }
    }
}
