using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GuessMe_IfYouCan_
{
    /// <summary>
    /// Логика взаимодействия для FormForAnswer.xaml
    /// </summary>
    public partial class FormForAnswer : Window, IView
    {
        Presenter presenter;
        MainWindow mw;
        public FormForAnswer(Presenter presenter, MainWindow mainWindow)
        {
            InitializeComponent();
            this.presenter = presenter;
            mw = mainWindow;
        }
        private void tbAnswer_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !(Char.IsDigit(e.Text, 0));
        private void tbAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) presenter.LetsCheckAnswer(tbAnswer.Text, this);
        }

        public void TbOff()
        {
            tbAnswer.Clear();
            this.Close();
        }

        private void fForAnswer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Presenter.step != 0) mw.TbOn();
        }
    }
}
