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

namespace WeatherParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            calendar.SelectedDate = DateTime.Now;
            Parser parser = new Parser();
            var test = parser.Parsexml();     
            lbWeather.ItemsSource = test;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            tbDate.Text = calendar.SelectedDate.Value.ToString("dd-MM-yy");
        }

        private void tbDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (DateTime.TryParse(tbDate.Text, out DateTime dt))
                {
                    calendar.SelectedDate = dt;
                }
                else
                {
                    MessageBox.Show("Неверный формат даты!");
                }
            }
        }
    }
}
