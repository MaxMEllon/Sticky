using System.Windows;
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
            selfVM.WindowId = WindowId;
            DataContext = selfVM;
            MouseLeftButtonDown += (sender, e) => this.DragMove();
        }

        public MainWindow(int id) : this()
        {
            WindowId = selfVM.WindowId = id;
        }
    }
}
