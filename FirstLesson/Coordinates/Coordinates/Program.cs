using System;

namespace Coordinates
{
    class Program
    {
        //Скворцов А.В.
        //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
        //б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
        static void Main(string[] args)
        {
            double x1, x2, y1, y2;

            Console.WriteLine("Задайте координаты X и Y первой точки:");
            string tmpStr = Console.ReadLine();
            x1 = GetCoordinate(tmpStr,"x1");

            tmpStr = Console.ReadLine();
            y1 = GetCoordinate(tmpStr, "y1");

            Console.WriteLine("Задайте координаты X и Y второй точки:");
            tmpStr = Console.ReadLine();
            x2 = GetCoordinate(tmpStr, "x1");

            tmpStr = Console.ReadLine();
            y2 = GetCoordinate(tmpStr, "y1");

            //а) Вывод используя спецификатор формата .2f (с двумя знаками после запятой)
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между координатами: {0:F2}", r);
            Console.WriteLine("Нашмите любую кнопку для продолжения");
            Console.ReadLine();

            //б) Вычисление расстояния между точками в виде метода
            Console.WriteLine("Расстояние между координатами рассчитанное методом: {0:F2}", GetDistanse(x1, y1, x2, y2));


        }

        private static double GetDistanse(double x1, double y1, double x2, double y2)
        {
            double r;
            return r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); // Здесь VS предлагает мне заменить r на _, убрать объявление r
                                                                               // и привести все к виду: _ = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))
                                                                               // Можно ли так делать и считается ли это нормальным по правилам хорошего кода?
        }

        private static double GetCoordinate(string stringFromConsole, string coordinatesName)
        {
            double coordinate = 0;

            while (coordinate == 0)
            {
                try //пытаемся конвертировать строку
                {
                    coordinate = double.Parse(stringFromConsole);
                }

                catch // в случае ошибки запрашиваем повторный ввод, выдавая подходящее под координату сообщение
                {
                    switch (coordinatesName)
                    {
                        case "x1":
                            Console.Write("Ошибка ввода! Вводите только числа. Повторите ввод координаты Х первой точки:");
                            stringFromConsole = Console.ReadLine();
                            break;
                        case "y1":
                            Console.Write("Ошибка ввода! Вводите только числа. Повторите ввод координаты Y первой точки:");
                            stringFromConsole = Console.ReadLine();
                            break;
                        case "x2":
                            Console.Write("Ошибка ввода! Вводите только числа. Повторите ввод координаты Х второй точки:");
                            stringFromConsole = Console.ReadLine();
                            break;
                        case "y2":
                            Console.Write("Ошибка ввода! Вводите только числа. Повторите ввод координаты Y второй точки:");
                            stringFromConsole = Console.ReadLine();
                            break;
                    }
                }
            }

            return coordinate;
        }
    }
}
