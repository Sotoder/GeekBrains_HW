using System;

namespace ComplexNumbers
{
    class Menu
    {
        public void Start()
        {
            Calc calc = new Calc(new ConsoleView());
            
            while (true)
            {
                Console.WriteLine("Здравствуйте! Выберите действие:\n" +
                    "Для суммы комплексных чисел введите 1.\n" +
                    "Для вычитания комплексных чисел введите 2.\n" +
                    "Для умножения комплексного числа на целое нажмите 3.\n" +
                    "Для умножения комплексных чисел нажмите 4.\n" +
                    "Для выхода нажмите Escape");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        calc.Sum();
                        if (Exit()) return;
                        break;
                    case ConsoleKey.D2:
                        calc.Sub();
                        if (Exit()) return;
                        break;
                    case ConsoleKey.D3:
                        calc.MultZ();
                        if (Exit()) return;
                        break;
                    case ConsoleKey.D4:
                        calc.MultC();
                        if (Exit()) return;
                        break;
                    case ConsoleKey.Escape: return;
                }
                Console.Clear();
            }
        }

        private bool Exit()
        {
            Console.WriteLine("Для выхода нажмите Escape. Для продолжения нажмите любую другую клавишу");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return true;
            }
            else return false;
        }
    }
}
