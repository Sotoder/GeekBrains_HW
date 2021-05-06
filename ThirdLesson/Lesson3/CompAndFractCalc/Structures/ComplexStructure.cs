using System;

namespace Structures.ComplexNumbers
{
    struct Complex
    {
        public int re;
        public int im;

        public Complex(int re, int im)
        {
            this.re = re;
            this.im = im;
        }
        public Complex Plus(Complex y) => new Complex(this.re + y.re, this.im + y.im);

        public Complex Minus(Complex y) => new Complex(this.re - y.re, this.im - y.im);

        public Complex Multiply(int i) => new Complex(this.re * i, this.im * i);

        public Complex Multiply(Complex y) //оставил в обычном виде, для большей понятности
        {
            Complex result = new Complex();
            result.re = (this.re * y.re) - (this.im*y.im);
            result.im = (this.im * y.re) + (this.re*y.im);
            return result;
        }
        public override string ToString() => re switch
        {
            0 when im == 0 => $"\nРезультат операции: 0",
            0 => $"\nРезультат операции: {im}i",
            > 0 or < 0 when im == 0 => $"\nРезультат операции: {re}",
            > 0 or < 0 => $"\nРезультат операции: {re} + {im}i"
        };
    }
}
