using System;

namespace IMT_Homework_L2
{
    class Program
    {
        // Скворцов А.В.
        //2.	Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
        static void Main(string[] args)
        {
            string name;
            double weight, height, bmi;

            Console.WriteLine("Здравствуйте! Как к вам обращаться?");
            name = Console.ReadLine();

            Console.Write(name + ", укажите ваш вес в килограммах:");
            string tmpString = Console.ReadLine();
            weight = SetParam(tmpString);

            Console.Write(name + ", укажите ваш рост в метрах:");
            tmpString = Console.ReadLine();
            height = SetParam(tmpString);

            bmi = CalcBMI(weight, height);


            Console.WriteLine("Ваш ИМТ равен: {0:f2}", bmi);

            IndexComparsion(bmi, weight, height);

            Console.ReadLine();

        }

        private static void IndexComparsion(double bmi, double weight, double height)
        {
            if (bmi < 18.5)
            {
                Console.WriteLine("Вы еще тут? Ветром не сдуло? Вас бы накормить. Вам надо нажраТ минимум {0:f2} кг", CalcFat(weight, height, false));
            }
            else if (bmi >= 18.5 && bmi <= 24.9)
            {
                Console.WriteLine("Ваш ИМТ в норме! Лови пятюню");
            }
            else if (bmi > 24.9 && bmi <= 29.9)
            {
                Console.WriteLine("Вы чет пухленький, может физкультурки? Вам надо скинуть минимум {0:f2} кг", CalcFat(weight, height, true));
            }
            else if (bmi > 29.9 && bmi <= 35.4)
            {
                Console.WriteLine("Вы сильно пухленький, может диеты с физкультуркой? Вам надо скинуть минимум {0:f2} кг", CalcFat(weight, height, true));
            }
            else
            {
                Console.WriteLine("Да вы прям жирненький, попробуйте не жраТ! Вам надо скинуть минимум {0:f2} кг", CalcFat(weight, height, true));
            }
        }

        private static float CalcBMI(double weight, double height)
        {
            return (float)Math.Round(weight / (height * height), 2);
        }

        private static object CalcFat(Double weight, Double height, Boolean fat)
        {
            if (fat)
            {
                double normalMaxWight = 24.9 * Math.Pow(height, 2);
                return weight - normalMaxWight;
            } else
            {
                double normalMinWight = 18.5 * Math.Pow(height, 2);
                return Math.Abs(weight - normalMinWight);
            }

        }

        private static double SetParam(string strFromConsole)
        {
            double param = 0;

            while (param == 0)
            {
                if (NumbersEntered(strFromConsole))
                {
                    param = double.Parse(strFromConsole);
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
            double checkedDouble;

            if (double.TryParse(checkedStr, out checkedDouble))
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
