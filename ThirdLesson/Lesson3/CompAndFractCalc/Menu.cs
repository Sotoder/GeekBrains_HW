using System;

namespace ComplexNumbers
{
    class Menu
    {
        Calc calc = new Calc(new ConsoleView());
        public void Start() //главное меню
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте! С какими числами работаем:\n" +
                    "Для комплексных нажмите 1.\n" +
                    "Для дробных нажмите 2.\n" +
                    "Для выхода нажмите Escape");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        ComplexMenu();
                        if (ExitMenu()) return;
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        FractionalMenu();
                        if (ExitMenu()) return;
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;
                }
            }
        }

        private void ComplexMenu() // меню комплексных чисел
        {
            Console.WriteLine("Выберите действие:\n" +
                "Для суммы комплексных чисел нажмите 1.\n" +
                "Для вычитания комплексных чисел нажмите 2.\n" +
                "Для умножения комплексного числа на целое нажмите 3.\n" +
                "Для умножения комплексных чисел нажмите 4.\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    calc.Sum(1);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    calc.Sub(1);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    calc.MultZ();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    calc.MultC();
                    break;
            }
        }

        private void FractionalMenu() //меню дробных чисел
        {
            Console.WriteLine("Выберите действие:\n" +
                "Для суммы дробных чисел нажмите 1.\n" +
                "Для вычитания дробных чисел нажмите 2.\n" +
                "Для умножения дробных чисел нажмите 3.\n" +
                "Для деления дробных чисел нажмите 4.\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    calc.Sum(2);                  
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    calc.Sub(2);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    calc.Mult();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    calc.Div();
                    break;
            }
        }

        private bool ExitMenu()
        {
            Console.WriteLine("\n--------------------------------------------------------\n" +
                "Для выхода нажмите Escape. Для возврата в главное меню нажмите любую другую клавишу");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return true;
            }
            else return false;
        }
    }
}
