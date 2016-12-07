using Sticky.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (_WindowId != value)
                {
                    _WindowId = value;
                    RaisePropertyChanged("WindowId");
                }
            }
        }

        private MainWindow view;
        private static Collection<MainWindow> stickyList = new Collection<MainWindow>();
        public MainViewModel(MainWindow view)
        {
            this.view = view;
            stickyList.Add(view);

            DecreaseFontSize = new RelayCommand((id) =>
            {
                if (view.StickyTextContent.FontSize > 8)
                {
                    MainWindow target = stickyList[(int)id];
                    target.StickyTextContent.FontSize -= 2;
                }
            });

            IncreaseFontSize = new RelayCommand((id) =>
            {
                if (view.StickyTextContent.FontSize < 100)
                {
                    MainWindow target = stickyList[(int)id];
                    target.StickyTextContent.FontSize += 2;
                }
            });

            OpenSubSticky = new RelayCommand((_) =>
            {
                MainWindow window = new MainWindow(stickyList.Count);
                stickyList.Add(window);
                window.Show();
            });

            CloseSubSticky = new RelayCommand((id) =>
            {
                if (stickyList.Count == 1)
                {
                    this.view.Close();
                }
                else
                {
                    // 付箋の削除
                    MainWindow target = stickyList[(int)id];
                    target.Close();
                    stickyList.RemoveAt((int)id);
                }
            });

            OpenColorPalette = new RelayCommand((id) =>
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    MainWindow target = stickyList[(int)id];
                    System.Windows.Media.Color color =
                        System.Windows.Media.Color.FromArgb(colorDialog.Color.A,
                                                            colorDialog.Color.R,
                                                            colorDialog.Color.G,
                                                            colorDialog.Color.B);
                    target.StickyTextContent.Foreground = new SolidColorBrush(color);
                }
            });
        }
    }

}
