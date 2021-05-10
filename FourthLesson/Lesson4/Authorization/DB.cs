using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    class DB
    {
        Accaunt[] arr;

        public DB(Accaunt[] arrFromFile)
        {
            arr = arrFromFile;
        }

        public Accaunt this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int Count { get { return arr.Length; } }
    }
}
