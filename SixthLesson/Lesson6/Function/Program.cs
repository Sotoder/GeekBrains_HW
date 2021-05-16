using System;
// Описываем делегат. В делегате описывается сигнатура методов, на
// которые он сможет ссылаться в дальнейшем (хранить в себе)

namespace Function
{
    public delegate double Fun(double x);
    class Program
    {
        static void Main()
        {
            Paint paint = new Paint();
            paint.PaintStart();
        }
    }
}


