using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomArray
{
    class App
    {
        public void StartApp()
        {
            int[] arr = new int[20];
            ArrayFillAndSearch(arr, out List<int> twises, out int twiseCount);
            PrintResult(arr, twises, twiseCount);
        }

        private void ArrayFillAndSearch(int[] arrayForSearch, out List<int> twises, out int twiseCount)
        {
            twises = new List<int>();
            twiseCount = 0;
            Random rnd = new Random();

            for (int i = 0; i < arrayForSearch.Length; i++)
            {
                arrayForSearch[i] = rnd.Next(-10000, 10001);

                if (i > 0)
                {
                    if ((arrayForSearch[i] % 3 == 0 && arrayForSearch[i - 1] % 3 != 0) || (arrayForSearch[i - 1] % 3 == 0 && arrayForSearch[i] % 3 != 0))
                    {
                        twiseCount++;
                        twises.Add(arrayForSearch[i]);
                        twises.Add(arrayForSearch[i - 1]);
                    }
                }
            }
            
        }

        private void PrintResult(int[] array, List<int> twises, int twiseCount)
        {
            Console.WriteLine(string.Join("; ", array));
            Console.WriteLine("--------------------------------------\n" +
                "Количество пар:");
            Console.WriteLine(twiseCount);
            Console.WriteLine("\nПары:");
            for (int i = 0; i < twises.Count; i += 2)
            {
                Console.WriteLine($"{twises[i].ToString().PadLeft(6)}:{twises[i + 1].ToString().PadLeft(6)}");
            }
        }
    }
}




