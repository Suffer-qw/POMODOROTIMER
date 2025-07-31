using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POMODOROTIMER.View
{
    /// <summary>
    /// Interaction logic for SetWindow.xaml
    /// </summary>
    public partial class SetWindow : Window
    {
        string pattern = @"^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$";
        public string time {  get; set; } = "00:00:00";
        public bool timer {get; set; }
        public SetWindow()
        {
            InitializeComponent();
            btnOk.Content = "Ok";
            time = "00:00:00";

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            time = tbInput.Text.Trim();
            Close();
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (btnOk == null || T == null || tbInput == null)
                return;
           if ((bool)T.IsChecked && Regex.IsMatch(tbInput.Text.Trim(), pattern))
           {
                btnOk.IsEnabled = true;
                timer = true;
           }
            else
                btnOk.IsEnabled = false;
        }

        private void SW_Checked(object sender, RoutedEventArgs e)
        {
            btnOk.IsEnabled = true;
            timer = false;
        }

        private void T_Checked(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(tbInput.Text.Trim(), pattern))
            {
                btnOk.IsEnabled = true;
                timer = true;
            }
            else 
                btnOk.IsEnabled= false;
        }
    }
}
