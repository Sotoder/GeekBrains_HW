using System;

namespace IMT_homework
{
    class Program
    {
        // Скворцов А.В.
        //2.	Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
        static void Main(string[] args)
        {
            string name;
            float weight, height, bmi;

            Console.WriteLine("Здравствуйте! Как к вам обращаться?");
            name = Console.ReadLine();

            Console.Write(name + ", укажите ваш вес в килограммах:");
            string tmpString = Console.ReadLine();
            weight = SetParam(tmpString);

            Console.Write(name + ", укажите ваш рост в метрах:");
            tmpString = Console.ReadLine();
            height = SetParam(tmpString);

            bmi = (float)Math.Round(weight / (height * height), 2);

            Console.WriteLine($"Ваш ИМТ равен: {bmi}");

            if (bmi < 18)
            {
                Console.WriteLine($"Вы еще тут? Ветром не сдуло? Вас бы накормить");
            }
            else if (bmi >= 18 && bmi < 25) 
            {
                Console.WriteLine($"Ваш ИМТ в норме! Лови пятюню");
            }
            else if (bmi >= 25 && bmi <= 30)
            {
                Console.WriteLine($"Вы чет пухленький, может физкультурки?");
            } else
            {
                Console.WriteLine($"Да вы прям жирненький, попробуйте не жраТ!");
            }

            Console.ReadLine();

        }

        private static float SetParam(string strFromConsole)
        {
            float param = 0;
            
            while (param == 0)
            {
                if (NumbersEntered(strFromConsole))
                {
                    param = float.Parse(strFromConsole);
                }
                else
                {
                    Console.Write("Пожалуйста, вводите значения веса/роста с помощью цифр. Повторите ввод:");
                    strFromConsole = Console.ReadLine();
                }
            }
            return param;
        }

        private static bool NumbersEntered(string checkedStr)
        {
            float checkedFloat;

            if (float.TryParse(checkedStr, out checkedFloat))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}
