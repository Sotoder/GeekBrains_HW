using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число(желательно побольше)");
            string num = SetParam(Console.ReadLine());
            int sum = CountNumbersInNumber(num);
            Console.WriteLine($"Число состоит из {sum} чисел");
            Console.ReadLine();
        }

        private static int CountNumbersInNumber(string num)
        {
            int sum = 0;
            foreach (char a in num)
            {
                sum++;
            }
            return sum;
        }

        private static string SetParam(string strFromConsole)
        {
            int param = 0;

            while (param == 0)
            {
                if (Int32.TryParse(strFromConsole, out int checkedInt))
                {
                    param = checkedInt;
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые числа (десятичные будут округлены до целого). Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param.ToString();
        }
    }
}
