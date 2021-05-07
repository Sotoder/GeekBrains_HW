using Structures.ComplexNumbers;
using System;

namespace ComplexNumbers
{
    class Calc
    {
        ConsoleView view;
        enum TypeNumbers
        {
            complex = 1,
            fractional = 2
        }

        public Calc(ConsoleView view)
        {
            this.view = view;
        }
        public void Sum (int i)
        {
            TypeNumbers tn = (TypeNumbers)i;

            switch (tn)
            {
                case TypeNumbers.complex:
                    view.PrintLine($"Первое комплексное число");
                    Complex x1 = view.GetDataComplex();
                    view.PrintLine($"Второе комплексное число");
                    Complex x2 = view.GetDataComplex();

                    view.PrintLine(x1.Plus(x2).ToString());
                    break;
                case TypeNumbers.fractional:
                    view.PrintLine($"Первое дробное число");
                    Fractional a = view.GetDataFractional();
                    view.PrintLine($"Второе дробное число");
                    Fractional b = view.GetDataFractional();

                    view.PrintLine(a.Plus(b).ToString());
                    break;
            }
        }

        public void Sub(int i)
        {
            TypeNumbers tn = (TypeNumbers)i;

            switch (tn)
            {
                case TypeNumbers.complex:
                    view.PrintLine($"Первое комплексное число");
                    Complex x1 = view.GetDataComplex();
                    view.Print($"Второе комплексное число");
                    Complex x2 = view.GetDataComplex();

                    view.PrintLine(x1.Minus(x2).ToString());
                    break;
                case TypeNumbers.fractional:
                    view.PrintLine($"Первое дробное число");
                    Fractional a = view.GetDataFractional();
                    view.PrintLine($"Второе дробное число");
                    Fractional b = view.GetDataFractional();

                    view.PrintLine(a.Minus(b).ToString());
                    break;
            }


        }

        public void MultC()
        {
            view.PrintLine($"Первое комплексное число");
            Complex x1 = view.GetDataComplex();
            view.PrintLine($"Второе комплексное число");
            Complex x2 = view.GetDataComplex();

            view.Print(x1.Multiply(x2).ToString());
        }
        public void MultZ()
        {
            view.PrintLine($"Первое комплексное число");
            Complex x1 = view.GetDataComplex();
            int i = view.GetDataInteger();

            view.PrintLine(x1.Multiply(i).ToString());
        }

        public void Mult()
        {
            view.PrintLine($"Первое дробное число");
            Fractional a = view.GetDataFractional();
            view.PrintLine($"Второе дробное число");
            Fractional b = view.GetDataFractional();

            view.PrintLine(a.Multiply(b).ToString());
        }

        public void Div()
        {
            view.PrintLine($"Первое дробное число");
            Fractional a = view.GetDataFractional();
            view.PrintLine($"Второе дробное число");
            Fractional b = view.GetDataFractional();

            view.PrintLine(a.Division(b).ToString());
        }
    }
}
