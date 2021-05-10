using System;
using System.Linq;

namespace MyLib
{
    public class MyArray
    {
        int[] arr;
        public MyArray(int lenth, int startNum, int step)
        {
            arr = new int[lenth];
            for (int i = 0; i < lenth; i++)
            {
                arr[i] = i == 0 ? startNum : arr[i - 1] + step;
            }
        }

        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int Count { get { return arr.Length; } }

        public int Max { get { return arr.Max(); } }
        public int MaxCount
        {
            get
            {
                int result = 0;
                int[] tmpArr = arr;
                Array.Sort(tmpArr);
                int maxElement = arr.Max();
                for (int i = tmpArr.Length - 1; i >= 0; i--)
                {
                    if (tmpArr[i] == maxElement)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public void Add(int item)
        {
            int lenth = arr.Length;
            Array.Resize(ref arr, lenth + 1);
            arr[lenth] = item;
        }

        public int Sum
        {
            get
            {
                int result = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    result += arr[i];
                }

                return result;
            }
        }

        public int[] Inverse()
        {
            int[] result = new int[arr.Length];
            Array.Copy(arr, result, arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[i] * -1;
            }

            return result;
        }

        public void Multi(int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * num;
            }
        }
    }
}
