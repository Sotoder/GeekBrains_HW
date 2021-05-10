using ArrayFromDll.Models;
using ArrayFromDll.Views;
using System.IO;
using System;

namespace ArrayFromDll
{
    class App
    {
        View view;
        Model model;
        MyArray arr;

        public App()
        {
            this.view = new View();
            this.model = new Model();

        }

        public void AppStart(App app)
        {
            UI ui = new UI(app, app.view);
            ui.StartUI();
        }
        public void ManualArray()
        {
            MyArray arr = new MyArray(view.SpecifyLenth());
            this.arr = arr;
        }


        public int ChoseCreateType()
        {
            int creationType = view.LetsChoseCreationType();
            return creationType;
        }

        public void ArrayFromFile(string path)
        {
            if (File.Exists(path)) //в)**Добавьте обработку ситуации отсутствия файла на диске.
            {
                MyArray arr = new MyArray(GetArrFromFile(path));
                this.arr = arr;
            } else
            {
                view.FileNotExist(path);
                Environment.Exit(0);
            }
        }

        static private int[] GetArrFromFile(string path) // б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
        {
            return Array.ConvertAll(File.ReadAllLines(path), Int32.Parse);
        }

        public void FillArray()
        {
            int min = 0, max = 0;
            int randomType = view.LetsChoiseFillType(ref min, ref max);

            switch (randomType)
            {
                case 1:
                    model.FillRandom(arr, max);
                    break;
                case 2:
                    model.FillRandom(arr, min, max);
                    break;
            }   
        }

        public void GetMainArray()
        {
            view.ShowArray(arr);
        }

        public void GetTwiseArray()
        {
            view.ShowTwises(model.GetTwises());
        }

        public void FoundTwise()
        {
            int div = view.GetDivider();

            Model.TwiseCount(arr, div);
        }
    }
}
