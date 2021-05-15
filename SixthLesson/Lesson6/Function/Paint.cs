using System;

namespace Function
{
    class Paint
    {
        public void PaintStart()
        {
            Console.WriteLine("Таблица функции x^2:");
            Table(x => Math.Pow(x, 2), 2, 4);
            Console.WriteLine("Таблица функции a*x^2:");
            Table((x, a) => a * Math.Pow(x,2), 2, 2, 4);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, 2, 4);
            Console.WriteLine("Таблица функции a*Sin(x):");
            Table((x, a) => a * Math.Sin(x), 2, 2, 4);
        }


        public void Table(DelegatesList.Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public void Table(Func<double,double,double> F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
    }
}
