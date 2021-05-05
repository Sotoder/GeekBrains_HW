using System;

public class UsefulThings
{
	public UsefulThings()
	{
        public int CheckAndSetParam(string strFromConsole)
        {
            int param = 0;

            while (param == 0)
            {
                if (int.TryParse(strFromConsole, out int checkedInt))
                {
                    param = checkedInt;
                }
                else
                {
                    Console.Write("Пожалуйста, вводите только целые числа, десятичные числа будут округлены. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }

        public long CheckAndSetParam(string strFromConsole)
        {
            long param = 0;

            while (param == 0)
            {
                if (long.TryParse(strFromConsole, out long checkedLong))
                {
                    param = checkedLong;
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
