

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

            view.PrintLn("Здравствуйте. Давайте создадим и заполним наш массив данными");
            app.CreateArray();
            view.Clear();


            view.Print("Данные массива: ");
            app.GetMainArray();

            view.PrintLn("\n----------------------------------------------\n" +
                "Возможные операции с массивом: ");
            app.Operations();

            view.Clear();
            view.Print("Максимальный элемент итогового массива: ");
            app.GetMax();
            view.Print("Количество вхождений максимального элемента в итоговый массив: ");
            app.GetMaxCount();
            view.Pause();
            view.Clear();
            view.PrintLn("А теперь посчитаем количество вхождений каждого элемента итогового массива\n");
            app.GetEntrys();

        }
    }
}
