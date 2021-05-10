using System;


namespace ArrayFromDll.Models
{
    class Model
    {
        static private MyArray twises;

        public MyArray GetTwises()
        {
            return twises;
        }

        public void FillRandom(MyArray arrayForSearch, int min, int max)
        {
            Random rnd = new Random();

            for (int i = 0; i < arrayForSearch.Count; i++)
            {
                arrayForSearch[i] = rnd.Next(min, max);

            }
        }

        public void FillRandom(MyArray arrayForSearch, int max)
        {
            Random rnd = new Random();

            for (int i = 0; i < arrayForSearch.Count; i++)
            {
                arrayForSearch[i] = rnd.Next(max);

            }
        }

        public static void TwiseCount(MyArray arrayForSearch, int divider) //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        {
            twises = new MyArray(0);

            for (int i = 0; i < arrayForSearch.Count; i++)
            {
                if (i > 0)
                {
                    if ((arrayForSearch[i] % divider == 0 && arrayForSearch[i - 1] % divider != 0) || (arrayForSearch[i - 1] % divider == 0 && arrayForSearch[i] % divider != 0))
                    {
                        twises.Add(arrayForSearch[i - 1]);
                        twises.Add(arrayForSearch[i]);
                    }

                }
            }
        }

    }
}
