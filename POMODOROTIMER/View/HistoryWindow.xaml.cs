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
using POMODOROTIMER.Model;
using POMODOROTIMER.ViewModel;

namespace POMODOROTIMER.View
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        MainWindowViewModel mwvm;
        public HistoryWindow()
        {
            mwvm = new MainWindowViewModel();
            DataContext = mwvm;
            InitializeComponent();

        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
