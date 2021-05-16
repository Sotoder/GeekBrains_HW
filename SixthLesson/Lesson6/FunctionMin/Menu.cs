using System;

namespace FunctionMin
{
    class Menu
    {
        public BinarParse bp;
        public MenuInfrastucture mi;

        public Menu()
        {
            BinarParse bp = new BinarParse();
            this.bp = bp;
            MenuInfrastucture mi = new MenuInfrastucture();
            this.mi = mi;
        }

        public void StartMenu()
        {
            mi.SetParams(out double a, out double b, out double h);

            bool isEscape = false;            
            while (!isEscape)
            {
                mi.Clear();
                mi.PrintLn("Для выбора функции, нажмите соответствующую ей кнопку:\n" +
                        "1 - y = x * x - 50 * x + 10\n" +
                        "2 - y = x^2 - 15\n" +
                        "3 - y = x^3 - 2x^2\n" +
                        "Для выхода нажмите Escape\n");
                ConsoleKey choise = Console.ReadKey(true).Key;

                switch (choise)
                {
                    case ConsoleKey.D1:
                        bp.WriteFuncResultsInFile("data.bin", bp.da[0], a, b, h);                      
                        break;

                    case ConsoleKey.D2:
                        bp.WriteFuncResultsInFile("data.bin", bp.da[1], a, b, h);
                        break;

                    case ConsoleKey.D3:
                        bp.WriteFuncResultsInFile("data.bin", bp.da[2], a, b, h);
                        break;
                    case ConsoleKey.Escape:
                        isEscape = true;
                        break;
                }

                bp.Load("data.bin", out double minValue);
                mi.PrintLn($"Минимальное значение функции: {minValue}");

                mi.PrintLn("\nДля продолжения нажмите любую кнопку, для выхода нажмите Escape");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) isEscape = true;
            }
        }
    }
}