using System;

namespace FunctionMin
{
    public delegate double Function(double x);

    //а) Использовать массив(или список) делегатов, в котором хранятся различные функции.
    class DelegateArray
    {
        Function[] delegates;

        public DelegateArray()
        {
            Function[] delegates = new Function[]
            {
                new Function(x => x * x - 50 * x + 10),
                new Function(x => Math.Pow(x,2) - 15),
                new Function(x => Math.Pow(x,3) - (Math.Pow(x,2) * 2))
            };
            this.delegates = delegates;
        }

        public Function this[int index]
        {
            get { return delegates[index]; }
            set { delegates[index] = value; }
        }

    }

}
