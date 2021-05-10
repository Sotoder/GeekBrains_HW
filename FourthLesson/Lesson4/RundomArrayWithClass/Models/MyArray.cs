using System;
using System.IO;

namespace ArrayFromDll.Models
{
    class MyArray
    {
        int[] arr;
        public MyArray(int i)
        {
            arr = new int[i];
        }

        public MyArray(int[] arrFromFile)
        {
            arr = arrFromFile;
        }

        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int Count { get { return arr.Length; } }

        public void Add (int item)
        {
            int lenth = arr.Length;
            Array.Resize(ref arr, lenth + 1);
            arr[lenth] = item;
        }
    }
}

