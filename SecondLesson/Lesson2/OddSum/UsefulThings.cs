using System;

namespace MyMethods
{

	public class UsefulThings
	{
        public int CheckAndSetParamInt(string strFromConsole)
        {
            int param = 0;
            bool flag = false;

            while (!flag)
            {
                if (Int32.TryParse(strFromConsole, out int checkedInt))
                {
                    param = checkedInt;
                    flag = true;
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые числа, число должно быть не меньше - 2 147 483 647 и не больше 2 147 483 647. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }

            return param;
        }

        public long CheckAndSetParamLong(string strFromConsole)
        {
            long param = 0;
            bool flag = false;

            while (!flag)
            {
                if (long.TryParse(strFromConsole, out long checkedLong))
                {
                    param = checkedLong;
                    flag = true;
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые числа, десятичные числа будут округлены. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }
    }
}
