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
        BaseTimer pTimer;
        MainWindowViewModel mwvm;
        public MainWindow()
        {
            pTimer = new PTimer("00:10:00");
            mwvm = new MainWindowViewModel(pTimer);
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
            if(st.timer)
            {
                tbTimer.Text = st.time;
                //pTimer = PTimer(tbTimer.Text.ToString());
            }
            
        }
    }
}