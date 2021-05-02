using System;
using MyMethods;

namespace CountNumbers
{
    class Program

    //Скворцов А.В.
    //2. Написать метод подсчета количества цифр числа.
    {
        enum Results
        {
            sumForEach = 1,
            sumWhile = 2,
            sumAsString = 3

        };
        private static void Main(string[] args)
        {
            UsefulThings ut = new UsefulThings();
            Console.Write("Введите число(не больше 2 147 483 647):");
            CountNumbers(ut.CheckAndSetParamInt(Console.ReadLine()));
        }

        private static void CountNumbers(int num)
        {
            int sum;
            string ending, start;
            for (int i = 1; i <= Enum.GetNames(typeof(Results)).Length; i++)
            {
                sum = GetNumbersInNumber(num, (Results)i);
                
                if (sum >= 5)
                {
                    ending = "-и цифр";
                } else
                {
                    var mod = sum%10;
                    ending = mod switch
                    {
                        1 => "-ой цифры",
                        >=2 and <= 4 => "-х цифр",
                    };
                }

                start = i switch
                {
                    1 => "Подсчет ForEach. ",
                    2 => "Подсчет While. ",
                    3 => "Подсчет Lenth. "
                };
                   
                Console.WriteLine(start + $"Число состоит из {sum}" + ending);
            }
            Console.ReadLine();
        }

        private static int GetNumbersInNumber(int num, Results result)
        {
            int count = 0;
            switch (result)
            {
                case Results.sumForEach: // Работает за счет округления
                    count = (num != 0) ? 0 : 1;
                    while (num != 0)
                    {
                        count++;
                        num = num / 10;
                    }
                    break;
                case Results.sumWhile: // По сути то же что и String.Lenth, только циклом, как раз в рамках нашего урока
                    foreach (char a in num.ToString())
                    {
                        count++;
                    }
                    break;
                case Results.sumAsString: // В рамках второго урока не то что бы подходит, но почему бы и нет?)) Вроде считается самым медленным.
                    count = num.ToString().Length;
                    break;
            }          
            return count;
        }
    }
}
