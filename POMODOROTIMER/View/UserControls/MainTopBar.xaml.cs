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
using POMODOROTIMER.ViewModel;

namespace POMODOROTIMER.View.UserControls
{
    /// <summary>
    /// Interaction logic for MainTopBar.xaml
    /// </summary>
    public partial class MainTopBar : UserControl
    {
        public MainTopBar()
        {
            InitializeComponent();
            DataContext = new TopBarViewModel();
        }
    }
}
