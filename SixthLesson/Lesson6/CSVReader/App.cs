using System;
using System.Collections.Generic;
using System.IO;

namespace CSVReader
{
    delegate int Comparsion(Student s1, Student s2);
    class App
    {
        UI ui;

        public App()
        {
            UI ui = new UI();
            this.ui = ui;
        }
        public void Start()
        {
            
            int bakalavr = 0;
            int magistr = 0;
            int hightCourse = 0;
            SortedDictionary<int, int> youth = new SortedDictionary<int, int>();
            List<Student> list = new List<Student>();

            StreamStart(ref list, ref bakalavr, ref magistr, ref hightCourse, ref youth);

            ui.PrintStudInfo(bakalavr, magistr, list, hightCourse, youth, CourseAndAgeComprasion);
        }

        public void StreamStart(ref List<Student> list, ref int bakalavr, ref int magistr, ref int hightCourse, ref SortedDictionary<int, int> newbee)
        {
            using StreamReader sr = new StreamReader("students_6.csv");
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');

                        list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), s[7], s[8]));

                        if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                        if (int.Parse(s[6]) >= 5) hightCourse++; // а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
                        if (int.Parse(s[5]) >= 18 && int.Parse(s[5]) <= 20) // б) Подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
                        {
                            newbee.TryGetValue(int.Parse(s[6]), out int value);
                            newbee[int.Parse(s[6])] = value == 0 ? 1 : value + 1;
                        }
                    }
                    catch (Exception e)
                    {
                        if (ui.ErrorCatch(e) == ConsoleKey.Escape) return;
                    }
                }
            }
        }


        public int CourseAndAgeComprasion(Student st1, Student st2) // г) *отсортировать список по курсу и возрасту студента;
        {
            if (st1.course == st2.course)
            {
                return st1.age >= st2.age ? 1 : -1;
            }
            else
            {
                return st1.course >= st2.course ? 1 : -1;
            }
        }

        public int CourseComprasion(Student st1, Student st2) => st1.course >= st2.course ? 1 : -1; // в) отсортировать список по возрасту студента;

        public int NameComprasion(Student st1, Student st2) => String.Compare(st1.firstName, st2.firstName);    

    }
}