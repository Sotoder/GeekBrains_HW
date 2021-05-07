using System;

namespace ComplexNumbers
{
    class Menu
    {
        Calc calc;
        ConsoleView view;
        public Menu()
        {
            view = new ConsoleView();
            calc = new Calc(view);
        }
        public void Start() //главное меню
        {
            
            while (true)
            {
                view.Clear();
                view.PrintLine("Здравствуйте! С какими числами работаем:\n" +
                    "Для комплексных нажмите 1.\n" +
                    "Для дробных нажмите 2.\n" +
                    "Для выхода нажмите Escape");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        view.Clear();
                        ComplexMenu();
                        if (ExitMenu()) return;
                        break;
                    case ConsoleKey.D2:
                        view.Clear();
                        FractionalMenu();
                        if (ExitMenu()) return;
                        break;
                    case ConsoleKey.Escape:
                        view.Clear();
                        return;
                }
            }
        }

        private void ComplexMenu() // меню комплексных чисел
        {
            view.PrintLine("Выберите действие:\n" +
                "Для суммы комплексных чисел нажмите 1.\n" +
                "Для вычитания комплексных чисел нажмите 2.\n" +
                "Для умножения комплексного числа на целое нажмите 3.\n" +
                "Для умножения комплексных чисел нажмите 4.\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    view.Clear();
                    calc.Sum(1);
                    break;
                case ConsoleKey.D2:
                    view.Clear();
                    calc.Sub(1);
                    break;
                case ConsoleKey.D3:
                    view.Clear();
                    calc.MultZ();
                    break;
                case ConsoleKey.D4:
                    view.Clear();
                    calc.MultC();
                    break;
            }
        }

        private void FractionalMenu() //меню дробных чисел
        {
            view.PrintLine("Выберите действие:\n" +
                "Для суммы дробных чисел нажмите 1.\n" +
                "Для вычитания дробных чисел нажмите 2.\n" +
                "Для умножения дробных чисел нажмите 3.\n" +
                "Для деления дробных чисел нажмите 4.\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    view.Clear();
                    calc.Sum(2);                  
                    break;
                case ConsoleKey.D2:
                    view.Clear();
                    calc.Sub(2);
                    break;
                case ConsoleKey.D3:
                    view.Clear();
                    calc.Mult();
                    break;
                case ConsoleKey.D4:
                    view.Clear();
                    calc.Div();
                    break;
            }
        }

        private bool ExitMenu()
        {
            view.PrintLine("\n--------------------------------------------------------\n" +
                "Для выхода нажмите Escape. Для возврата в главное меню нажмите любую другую клавишу");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return true;
            }
            else return false;
        }
    }
}
