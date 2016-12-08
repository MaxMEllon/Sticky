using Sticky.Util;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Sticky.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand DecreaseFontSize { get; private set; }
        public ICommand IncreaseFontSize { get; private set; }
        public ICommand OpenSubSticky { get; private set; }
        public ICommand CloseSubSticky { get; private set; }
        public ICommand OpenColorPalette { get; private set; }

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

        public MainViewModel(MainWindow view)
        {
            this.view = view;
            stickyList.Add(view);

            DecreaseFontSize = new RelayCommand((id) => this.handleDecreaseFontSize((int)id));
            IncreaseFontSize = new RelayCommand((id) => this.handleIncreaseFontSize((int)id));
            OpenSubSticky = new RelayCommand((_) => this.handleOpenSubSticky());

            CloseSubSticky = new RelayCommand((id) =>
            {
                if (stickyList.Count == 1) this.view.Close();
                else stickyList[(int)id].Close();
            });

            OpenColorPalette = new RelayCommand((id) =>
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    MainWindow target = stickyList[(int)id];
                    Color color = Color.FromArgb(colorDialog.Color.A,
                                                 colorDialog.Color.R,
                                                 colorDialog.Color.G,
                                                 colorDialog.Color.B);
                    target.StickyTextContent.Foreground = new SolidColorBrush(color);
                }
            });
        }
    }
}
