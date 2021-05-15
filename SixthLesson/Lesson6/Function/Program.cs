using System;
// Описываем делегат. В делегате описывается сигнатура методов, на
// которые он сможет ссылаться в дальнейшем (хранить в себе)

namespace Function
{
    
    class Program
    {
        static void Main()
        {
            Paint test = new Paint();
            test.PaintStart();
        }
    }
}


