using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;

namespace FunctionMin
{
    class BinarParse
    {
        //public Function[] da;  - Массив делегатов, просто для тренеровки
        //public BinarParse()
        //{
        //    Function[] da = new Function[]
        //    {
        //        new Function(x => x * x - 50 * x + 10),
        //        new Function(x => Math.Pow(x,2) - 15),
        //        new Function(x => Math.Pow(x,3) - (Math.Pow(x,2) * 2))
        //    };
        //    this.da = da;
        //}

        //public List<Function> da; - коллекция делегатов, просто для тренеровки
        //public BinarParse()
        //{
        //    List<Function> da = new List<Function>
        //    {
        //        new Function(x => x * x - 50 * x + 10),
        //        new Function(x => Math.Pow(x,2) - 15),
        //        new Function(x => Math.Pow(x,3) - (Math.Pow(x,2) * 2))
        //    };
        //    this.da = da;
        //}

        public DelegateArray da;
        public BinarParse()
        {
            DelegateArray da = new DelegateArray();
            this.da = da;
        }



        public double[] Load(string fileName, out double minValue)
        {
            minValue = 0;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
           
            double[] doubles = new double[fs.Length / sizeof(double)];
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                doubles[i] = bw.ReadDouble();
            }
            bw.Close();
            fs.Close();
            minValue = doubles.Min();
            return doubles;
        }
        public void WriteFuncResultsInFile(string fileName, Function Func, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (a <= b)
            {
                
                bw.Write(Func(a));
                a += h;
            }
            bw.Close();
            fs.Close();
        }
    }
}