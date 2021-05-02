using System;
using MyMethods;

namespace OddSum
{
    //Скворцов А.В.
    //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
    class Program
    {
        
        public static void Main(string[] args)
        {
            
            StartTyping();
        }

        private static void StartTyping()
        {
            UsefulThings ut = new UsefulThings();
            int sum = 0, i;
            Console.WriteLine("Последовательно вводите целые числа. При вводе 0, программа расчитает сумму нечетных чисел и завершит выполнение.");
            do
            {
                i = ut.CheckAndSetParamInt(Console.ReadLine());

                if (i > 0)
                {
                    if (i%2 != 0)
                    {
                        sum += i;
                    }
                }

            } while (i != 0);

            Console.WriteLine($"Сумма введенных нечетных чисел: {sum}");
        }
    }
}
