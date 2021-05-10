using ArrayFromDll.Models;
using ArrayFromDll.Views;
using MyLib;

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
        public void CreateArray()
        {
            int startNum = 0, step = 0, lenth = 0;
            view.SpecifyParams(ref startNum, ref step, ref lenth);
            MyArray arr = new MyArray(lenth, startNum, step);
            this.arr = arr;
        }

        public void Operations()
        {
            bool flag = false;

            while (!flag)
            {
                int opNum = view.GetOperationsNum(out int multiplier);
                switch (opNum)
                {
                    case 1:
                        view.ShowSum(arr.Sum);
                        break;
                    case 2:
                        view.ShowInverse(arr.Inverse());
                        break;
                    case 3:
                        arr.Multi(multiplier);
                        view.ShowMult(arr);
                        break;
                    case 4:
                        return;
                }
            }
        }

        public void GetMaxCount()
        {
            view.ShowMaxCount(arr.MaxCount);
        }


        public void GetMax()
        {
            view.ShowMax(arr.Max);
        }


        public void GetEntrys()
        {
            view.ShowEntrys(model.CountEntry(arr));
        }

        public void GetMainArray()
        {
            view.ShowArray(arr);
        }
    }
}
