using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
    }
}
