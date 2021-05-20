using System;
using System.Windows;


namespace Doble_r_ator
{
    // Скворцов А.В.
    //а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    //б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
    //в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int> Stack.

    public partial class MainWindow : Window, IView
    {
        public Presenter presenter;

        public String Result
        {
            get => tbCount.Text;
            set => tbCount.Text = value;
        }

        public String Comands
        {
            get => tbComands.Text;
            set => tbComands.Text = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            Comands += " 0";

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e) => presenter.LetsPlus();

        private void btnMult_Click(object sender, RoutedEventArgs e) => presenter.LetsMult();

        private void btnCancel_Click(object sender, RoutedEventArgs e) => presenter.LetsCancel();

        private void btnGame_Click(object sender, RoutedEventArgs e) => presenter.LetsPlay();

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
