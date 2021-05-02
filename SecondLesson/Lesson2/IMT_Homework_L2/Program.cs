using System;

namespace IMT_Homework_L2
{
    // Скворцов А.В.
    //5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            double weight, height, bmi;

            Console.WriteLine("Здравствуйте! Как к вам обращаться?");
            name = Console.ReadLine();

            Console.Write(name + ", укажите ваш вес в килограммах:");
            string tmpString = Console.ReadLine();
            weight = CheckAndSetParam(tmpString, "W");
            Console.Write(name + ", укажите ваш рост в метрах:");
            tmpString = Console.ReadLine();
            height = CheckAndSetParam(tmpString, "H");

            bmi = CalcBMI(weight, height);
            Console.WriteLine("Ваш ИМТ равен: {0:f2}", bmi);

            // б) Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
            IndexComparsion(bmi, weight, height); // Сравниваем ИМТ с нормой и даем советы
            Console.ReadLine();

        }

        private static void IndexComparsion(double bmi, double weight, double height) 
        {
            string comparsionResult = bmi switch
            {
                < 18.5 => $"Вы еще тут? Ветром не сдуло? Вас бы накормить. Вам надо нажраТ минимум {CalcFat(weight, height, false)} кг",
                >= 18.5 and <= 24.9 => $"Ваш ИМТ в норме! Лови пятюню",
                > 24.9 and <= 29.9 => $"Вы чет пухленький, может физкультурки? Вам надо скинуть минимум {CalcFat(weight, height, true)} кг",
                > 29.9 and <= 35.4 => $"Вы сильно пухленький, может диеты с физкультуркой? Вам надо скинуть минимум {CalcFat(weight, height, true)} кг",
                _ => $"Да вы прям жирненький, попробуйте совсем не жраТ! Вам надо скинуть минимум {CalcFat(weight, height, true)} кг"
            };
             Console.WriteLine(comparsionResult);
        }

        private static double CalcBMI(double weight, double height) // Расчет ИМТ
        {
            return Math.Round(weight / (height * height), 2);
        }

        private static object CalcFat(double weight, double height, bool fat) //Расчет избытка или недостатка веса относительно нормы
        {

            double normalMaxWight = 24.9 * Math.Pow(height, 2);
            double normalMinWight = 18.5 * Math.Pow(height, 2);
            return Math.Abs(Math.Round(weight - (fat ? normalMaxWight : normalMinWight), 2));
        }

        private static double CheckAndSetParam(string strFromConsole, string paramName)
        {
            double param = 0;

            while (param == 0)
            {
                if (double.TryParse(strFromConsole, out double checkedDouble))
                {
                    param = checkedDouble;
                }
                else
                {
                    string checkParamName = paramName switch
                    {
                        "W" => "Пожалуйста, вводите значения веса цифрами. Повторите ввод:",
                        "H" => "Пожалуйста, вводите значения роста цифрами. Повторите ввод:",
                    };
                    Console.Write(checkParamName);
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }
    }
}
