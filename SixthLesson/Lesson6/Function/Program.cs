using System;


namespace Function
{
    //Скворцов А.В.
    //1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
    //Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

    public delegate double Fun(double x);
    class Program
    {
        static void Main()
        {
            Paint paint = new Paint();
            paint.PaintStart();
        }
    }
}


