using System;

namespace ComplexNumbers
{
    class ConsoleView
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);          
        }

        public Complex GetDataComplex()
        {
            Console.Write("Введите действительную часть числа: ");
            int.TryParse(Console.ReadLine(), out int re);
            Console.Write("Введите мнимую часть числа: ");
            int.TryParse(Console.ReadLine(), out int im);
            return new Complex(re, im);
        }

        public int GetDataInteger()
        {
            Console.Write("Введите целое число: ");
            int.TryParse(Console.ReadLine(), out int i);
            return i;
        }
    }
}
