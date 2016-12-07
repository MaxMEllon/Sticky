using Sticky.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sticky.ViewModel
{
    public class MainViewModel
    {
        public ICommand Drag { get; private set; }

        private MainWindow view;
        public MainViewModel(MainWindow view)
        {
            this.view = view;
            Drag = new RelayCommand((_) =>
            {
                this.view.DragMove();
            });
        }
    }

}
