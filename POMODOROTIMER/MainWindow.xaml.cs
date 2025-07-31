using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using POMODOROTIMER.Model;
using POMODOROTIMER.View;
using POMODOROTIMER.ViewModel;

namespace POMODOROTIMER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mwvm;
        public MainWindow()
        {
            mwvm = new MainWindowViewModel();
            DataContext = mwvm;
            InitializeComponent();
        }
        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSetter_Click(object sender, RoutedEventArgs e)
        {
            SetWindow st = new SetWindow();
            st.ShowDialog();
            mwvm.test(st.time, st.timer);
            mwvm.SwitchTimer();
        }
    }
}