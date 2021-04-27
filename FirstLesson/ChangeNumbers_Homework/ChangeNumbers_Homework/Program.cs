using System;

namespace ChangeNumbers_Homework
{
    // Скворцов А.В.
    //4.	Написать программу обмена значениями двух переменных:
    //а) с использованием третьей переменной;
    //б) * без использования третьей переменной.

    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            
            Console.Write("Введите значение a:");
            string tmpStr = Console.ReadLine();
            a = SetNum(tmpStr);

            Console.Write("Введите значение b:");
            tmpStr = Console.ReadLine();
            b = SetNum(tmpStr);

            // а)
            var tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Кручу верчу, запутать хочу. Значение a теперь:{a}, значение b теперь:{b}");

            Console.WriteLine("\n" + "А теперь вернем все как было");

            // б)
            a = a + b; // обычный способ.
            b = a - b;
            a = a - b; 

            

            Console.WriteLine($"Еще раз кручу, распутать хочу. Значение a теперь:{a}, значение b теперь:{b}");

            Console.WriteLine("\n" + "И еще разок, по новомодному");
            
            (a, b) = (b, a); // подсмотренно в гуглах, как понял работает только в .net 5.0

            Console.WriteLine($"Значение a теперь:{a}, значение b теперь:{b}");
            Console.ReadLine();
        }

        private static int SetNum(string strFromConsole)
        {
            int num = 0;

            while (num == 0)
            {
                if (IntEntered(strFromConsole))
                {
                    num = int.Parse(strFromConsole);
                }
                else
                {
                    Console.Write("Пожалуйста, вводите целые числа. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return num;
        }

        private static bool IntEntered(string checkedStr)
        {
            int checkedInt;

            if (int.TryParse(checkedStr, out checkedInt))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}
