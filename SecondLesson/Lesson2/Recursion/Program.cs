using System;
using MyMethods;

namespace Recursion
{
    //Скворцов А.В.
    class Program
    {
        public string resultStr;
        public int resultSum;
        public enum OpType
        {
            sum,
            seq
        }
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

            //рекурсивным методом с глобальными переменными
            Console.WriteLine($"-------------------------------------------\nМетодом");
            Console.WriteLine($"Последовательность чисел от {a} до {b}: {resultStr}");
            Console.WriteLine($"Сумма всех чисел от {a} до {b}: {resultSum}");

            // рекурсивной функцией
            string[] recursionResult = RecursionFun(a, b);
            Console.WriteLine($"-------------------------------------------\nФункцией");
            Console.WriteLine($"Последовательность чисел от {a} до {b}: {recursionResult[0]}");
            Console.WriteLine($"Сумма всех чисел от {a} до {b}: {recursionResult[1]}");

            //рекурсивная функция со свитчем
            Console.WriteLine($"-------------------------------------------\nФункцией с переключателем");
            Console.WriteLine($"Последовательность чисел от {a} до {b}: {RecursionFun(a,b, OpType.seq)}");
            Console.WriteLine($"Сумма всех чисел от {a} до {b}: {RecursionFun(a, b, OpType.sum)}");

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

        private string[] RecursionFun(int a, int b)
        {
            string[] resultArr = new string[] {"",""};
            string seqStr = "";
            int sum = 0;
            // запускаем рекурсию
            if (a <= b)
            {
                sum += a + Convert.ToInt32(RecursionFun(a + 1, b)[1]);
                seqStr += a.ToString() + (a==b ? "" : ", ") + RecursionFun(a+1, b)[0];
            }
            resultArr[0] = seqStr;
            resultArr[1] = sum.ToString();
            return resultArr;
        }

        private string RecursionFun(int a, int b, OpType ot)
        {
            string funStr = "";

            // запускаем рекурсию
            if (a <= b)
            {
                switch (ot)
                {
                    case OpType.sum: funStr += (a + Convert.ToInt32(RecursionFun(a + 1, b)[1])).ToString();
                        break;
                    case OpType.seq: funStr += a.ToString() + (a == b ? "" : ", ") + RecursionFun(a + 1, b)[0];
                        break;
                }
            }
            return funStr;
        }
    }
}
