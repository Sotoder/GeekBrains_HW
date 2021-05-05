using System;

namespace MyMethods
{

	public class UsefulThings
	{
        public int CheckAndSetParam(string strFromConsole)
        {
            int param = 0;
            bool flag = false;

            while (!flag)
            {
                if (int.TryParse(strFromConsole, out int checkedLong))
                {
                    param = checkedLong;
                    flag = int.TryParse(strFromConsole, out checkedLong);
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые числа, десятичные числа будут округлены. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }

        public void PrintLn (string msg)
        {
            Console.WriteLine(msg);
        }
        public void Print(string msg)
        {
            Console.Write(msg);
        }
    }
}
