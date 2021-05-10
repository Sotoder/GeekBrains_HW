using MyLib;
using System.Collections.Generic;


namespace ArrayFromDll.Models
{
    class Model
    {
        public Dictionary<int, int> CountEntry(MyArray arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Count; i++)
            {
                if (dict.TryGetValue(arr[i], out int value))
                    dict[i] += 1;
                else
                    dict.Add(arr[i], 1);
            }
            return dict;
        }
    }
}
