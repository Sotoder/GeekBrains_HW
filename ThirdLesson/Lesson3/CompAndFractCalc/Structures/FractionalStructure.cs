using System;

namespace Structures.ComplexNumbers
{
    struct Fractional
    {
        public int num;
        public int den;
        public double dec;

        public Fractional(int num, int den) 
        {
            this.num = (num < 0 && den < 0) ? num * -1 : (num > 0 && den < 0) ? num * -1: num; // В случае если знаминатель и числитель отрицательные, делаем числитель положительным,
                                                                                               // в случае если знаминатель отрицательный а числитель положительный, делаем числитель отрицательным.
            this.den = Math.Abs(den); //знаминатель всегда берем по модулю, так как отрицательное число или нет определяем по числителю
            this.dec = (double)num / den;
        }



        public Fractional Plus(Fractional b)
        {
            if (this.den == b.den)
            {
                return new Fractional(this.num + b.num, this.den);
            } else
            {
                int numFirst = this.num * (LCM(this.den, b.den) / this.den); //Сделал две переменных для упрощения записи в return
                int numSecond = b.num * (LCM(this.den, b.den) / b.den);

                return new Fractional(numFirst + numSecond, LCM(this.den, b.den));
            }
        }

        public int LCM(int den1, int den2) // Функция нахождения наименьшего общего кратного
        {
            return (Math.Abs(den1) * Math.Abs(den2)) / GSF(den1, den2);
        }

        public int GSF(int den1, int den2) // Функция нахождения наибольшего общего делителя
        {
            int maxDen = Math.Abs(den1) > Math.Abs(den2) ? Math.Abs(den1) : Math.Abs(den2);
            int minDen = maxDen > Math.Abs(den2) ? Math.Abs(den2) : Math.Abs(den1);

            if (maxDen%minDen == 0)
            {
                return minDen;
            } else
            {
                return GSF(minDen, maxDen % minDen);
            }
        }

        public Fractional Minus(Fractional b)
        {
            if (this.den == b.den)
            {
                return new Fractional(this.num - b.num, this.den);
            }
            else
            {
                int numFirst = this.num * (LCM(this.den, b.den) / this.den); //Сделал две переменных для упрощения записи в return
                int numSecond = b.num * (LCM(this.den, b.den) / b.den);

                return new Fractional(numFirst - numSecond, LCM(this.den, b.den));
            }
        }


        public Fractional Multiply(Fractional b)
        {
            return new Fractional(this.num * b.num, this.den * b.den);
        }

        public Fractional Division(Fractional b)
        {
            return new Fractional(this.num * b.den, this.den * b.num);   
        }

        public Fractional SimpleFraction(int num, int den) // Функция упрощения дроби
        {
            return new Fractional(num / GSF(num, den), den / GSF(num, den));
        }

        public override string ToString()
        {
            return num switch
            {
                0 => $"\nРезультат: 0",

                _ => $"\nРезультат: {num}\\{den}" +
                $"\nДесятичное представление: {dec}" +
                $"\nУпрощенное представление: {SimpleFraction(num, den).num}\\{SimpleFraction(num, den).den}",
            };

        }


    }
}
