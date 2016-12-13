using Sticky.Util;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Sticky.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _WindowId = 0;
        public int WindowId
        {
            get { return _WindowId; }
            set
            {
                if (_WindowId == value) return;
                _WindowId = value;
                RaisePropertyChanged("WindowId");
            }
        }

        private MainWindow view;
        private static Collection<MainWindow> stickyList = new Collection<MainWindow>();
        private void handleDecreaseFontSize(int id)
        {
            if (view.StickyTextContent.FontSize > 8)
            {
                MainWindow target = stickyList[(int)id];
                target.StickyTextContent.FontSize -= 2;
            }
        }

        private void handleIncreaseFontSize(int id)
        {
            if (view.StickyTextContent.FontSize < 100)
            {
                MainWindow target = stickyList[id];
                target.StickyTextContent.FontSize += 2;
            }
        }

        private void handleOpenSubSticky()
        {
            MainWindow window = new MainWindow(stickyList.Count);
            stickyList.Add(window);
            window.Show();
        }

        private void handleCloseSubSticky(int id)
        {
            if (stickyList.Count == 1) this.view.Close();
            else stickyList[id].Close();
        }

        private void handleOpenColorPalette(int id)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                MainWindow target = stickyList[id];
                Color color = Color.FromArgb(colorDialog.Color.A,
                                             colorDialog.Color.R,
                                             colorDialog.Color.G,
                                             colorDialog.Color.B);
                target.StickyTextContent.Foreground = new SolidColorBrush(color);
            }
        }

        public ICommand DecreaseFontSize { get; private set; }
        public ICommand IncreaseFontSize { get; private set; }
        public ICommand OpenSubSticky { get; private set; }
        public ICommand CloseSubSticky { get; private set; }
        public ICommand OpenColorPalette { get; private set; }

        public MainViewModel(MainWindow view)
        {
            this.view = view;
            stickyList.Add(view);
            OpenSubSticky = new RelayCommand((_) => handleOpenSubSticky());
            CloseSubSticky = new RelayCommand((id) => handleCloseSubSticky((int)id));
            OpenColorPalette = new RelayCommand((id) => handleOpenColorPalette((int)id));
            DecreaseFontSize = new RelayCommand((id) => handleDecreaseFontSize((int)id));
            IncreaseFontSize = new RelayCommand((id) => handleIncreaseFontSize((int)id));
        }
    }
}
