
namespace ComplexNumbers
{
    class Calc
    {
        ConsoleView view;

        public Calc(ConsoleView view)
        {
            this.view = view;
        }
        public void Sum ()
        {
            view.Print($"Первое комплексное число");
            Complex x1 = view.GetDataComplex();
            view.Print($"Второе комплексное число");
            Complex x2 = view.GetDataComplex();

            view.Print(x1.Plus(x2).Print());
        }

        public void Sub()
        {
            view.Print($"Первое комплексное число");
            Complex x1 = view.GetDataComplex();
            view.Print($"Второе комплексное число");
            Complex x2 = view.GetDataComplex();

            view.Print(x1.Minus(x2).Print());
        }

        public void MultC()
        {
            view.Print($"Первое комплексное число");
            Complex x1 = view.GetDataComplex();
            view.Print($"Второе комплексное число");
            Complex x2 = view.GetDataComplex();

            view.Print(x1.Multiply(x2).Print());
        }
        public void MultZ()
        {
            view.Print($"Первое комплексное число");
            Complex x1 = view.GetDataComplex();
            int i = view.GetDataInteger();

            view.Print(x1.Multiply(i).Print());
        }
    }
}
