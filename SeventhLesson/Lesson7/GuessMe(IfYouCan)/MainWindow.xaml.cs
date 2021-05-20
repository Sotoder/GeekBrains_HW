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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuessMe_IfYouCan_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private Presenter presenter;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            TbOff();
            btnFormForAnswer.IsEnabled = false;
        }

        public void TbOff()
        {
            tbAnswer.Clear();
            tbAnswer.IsEnabled = false;
            btnFormForAnswer.IsEnabled = false;
        }
        public void TbOn()
        {
            tbAnswer.IsEnabled = true;
            btnFormForAnswer.IsEnabled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e) => presenter.LetsStart();

        public void ShowMessage(string msg) => MessageBox.Show(msg);

        private void tbAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) presenter.LetsCheckAnswer(tbAnswer.Text, this);
        }

        private void tbAnswer_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !(Char.IsDigit(e.Text, 0));

        private void btnFormForAnswer_Click(object sender, RoutedEventArgs e)
        {
            TbOff();
            FormForAnswer fa = new FormForAnswer(presenter, this);
            fa.Show();
        }
    }
}
