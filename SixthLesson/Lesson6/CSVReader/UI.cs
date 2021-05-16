using System;
using System.Collections.Generic;

namespace CSVReader
{
    internal class UI
    {

        public void PrintStudInfo(int bakalavr, int magistr, List<Student> list, int hightCourse, SortedDictionary<int, int> youth, Comparison ComparisonMethod)
        {
            list.Sort(new Comparison<Student>(ComparisonMethod));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine("Студентов старших курсов:{0}", hightCourse);

            foreach (KeyValuePair<int,int> element in youth)
            {
                Console.WriteLine("Студентов от 18-20 на {0} курсе: {1}", element.Key, element.Value);
            }

            Console.WriteLine("\n---Имя---||-Курс-||--Возраст--||");
            foreach (var v in list) 
                Console.WriteLine(v.firstName.PadRight(9) + "||   " + v.course.ToString().PadRight(2) + " ||    " + v.age.ToString().PadRight(6)+" ||");
            Console.WriteLine("---------||------||-----------||\n");
        }

        public ConsoleKey ErrorCatch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Ошибка! ESC - прекратить выполнение программы");
            return Console.ReadKey(true).Key;
        }
    }
}