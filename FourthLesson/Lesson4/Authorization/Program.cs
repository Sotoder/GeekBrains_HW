using System;
using System.IO;

namespace Authorization
{
    //4.Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.

    class Program
    {
        static void Main(string[] args)
        {
            App app = new App(@"users.txt");
            app.AppStart();
            
        }
    }
}
