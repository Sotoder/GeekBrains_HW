

namespace ArrayFromDll.Views
{
    class UI
    {
        View view;
        App app;
        
        public UI(App app, View view)
        {
            this.view = view;
            this.app = app;
        }
        
        public void StartUI()
        {

            view.Print("Загружаем данные в массив из файла или создадим вручную?\n" +
                "Нажмите 1 для создания массива из файла.\n" +
                "Нажмите 2 для ручных установок.");

            int creationType = app.ChoseCreateType();

            if (creationType == 1)
            {
                view.Clear();
                view.Print("Массив будет создан и заполнен данными из файла Array.txt.\n" +
                    "Нажмите любую клавишу для продолжения");
                view.Pause();
                view.Clear();
                app.ArrayFromFile(@"Array.txt");
            } else
            {
                view.Clear();
                view.Print("Укажите количество эллементов в массиве: ");
                app.ManualArray();
                view.Clear();

                view.PrintLn("Переходим к заполнению массива\n");
                app.FillArray();
                view.Clear();
            }

            view.Print("Данные массива: ");
            app.GetMainArray();

            view.PrintLn("\nНайдем пары которые будут делиться без остатка на заданное число");
            app.FoundTwise();

            app.GetTwiseArray();            
        }
    }
}
