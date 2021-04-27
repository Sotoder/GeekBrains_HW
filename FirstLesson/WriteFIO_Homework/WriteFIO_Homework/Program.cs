using System;

namespace WriteFIO_Homework
{   
    // Скворцов А.В.
    //1.	Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
    //а) используя склеивание;
    //б) используя форматированный вывод;
	//в) используя вывод со знаком $.

    class Program
    {
        static void Main(string[] args)
        {
            string name, sName, mName;
            
            Console.WriteLine("Здравствуйте! Заполните анкету. Вводите только кириллицу, все остальные символы будут уничтожены (обильно-злобно гогочит)");
            Console.Write("Укажите ваше имя:");
            string tmpStr = Console.ReadLine();
            name = ClearWrongSymbols(tmpStr);
            Console.Write("Укажите ваше отчество:");
            mName = Console.ReadLine();
            Console.Write("Укажите вашу фамилию:");
            sName = Console.ReadLine();

            //а)
            Console.WriteLine(name + " " + mName + " " + sName);
            //б)
            Console.WriteLine("{0} {1} {2}",name, mName, sName);
            //в)
            Console.WriteLine($"{name} {mName} {sName}");
        }

        private static string ClearWrongSymbols(string strFromConsole) // Здесь по правильной логике должна быть функция CheckOnWrongSymbols с возвратом true или false,
                                                                       // а пониже еще одна на получение верной строки с циклом,
                                                                       // но во мне проснулся тиран и захотелось удалять и влавствовать! 
        {
            string resultStr = "";
            foreach (char c in strFromConsole)
            {
                Console.WriteLine((Convert.ToInt32(c).ToString()));
                if ((Convert.ToInt32(c) >= 1040 && Convert.ToInt32(c) <= 1103) || (Convert.ToInt32(c) == 1025))
                {
                    resultStr += c.ToString();
                }                  
            }
            return resultStr;
        }
    }
}
