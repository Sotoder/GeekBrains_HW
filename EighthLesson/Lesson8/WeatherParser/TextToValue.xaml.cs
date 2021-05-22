using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeatherParser
{
    /// <summary>
    /// Логика взаимодействия для TextToValue.xaml
    /// </summary>
    public partial class TextToValue : Window
    {
        public TextToValue()
        {
            InitializeComponent();
            calendar.SelectedDate = DateTime.Now;
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
                } else
                {
                    MessageBox.Show("Не верный формат даты!");
                }
            }
        }
    }
}
