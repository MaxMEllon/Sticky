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
using Sticky.ViewModel;

namespace Sticky
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public int WindowId = 0;
        private MainViewModel selfVM;

        public MainWindow()
        {
            InitializeComponent();
            selfVM = new MainViewModel(this);
            selfVM.WindowId = this.WindowId;
            this.DataContext = selfVM;
            this.MouseLeftButtonDown += (sender, e) => this.DragMove();
        }

        public MainWindow(int id) : this()
        {
            this.WindowId = selfVM.WindowId = id;
        }

    }
}
