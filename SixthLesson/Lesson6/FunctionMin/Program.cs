using System;
using FunctionMin.View;


namespace FunctionMin
{
    //Скворцов А.В
    //2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    class Program : BinarParse
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}

