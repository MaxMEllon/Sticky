﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky.Util.Win32
{
    using System;
    using System.ComponentModel;

    namespace MetroRadiance.Core.Win32
    {
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Flags]
        // ReSharper disable InconsistentNaming
        public enum SWP
        {
            NOSIZE = 0x1,
            NOMOVE = 0x2,
            NOZORDER = 0x4,
            NOREDRAW = 0x8,
            NOACTIVATE = 0x10,
            FRAMECHANGED = 0x20,
            SHOWWINDOW = 0x0040,
            NOOWNERZORDER = 0x200,
            NOSENDCHANGING = 0x0400,
            ASYNCWINDOWPOS = 0x4000,
        }
        // ReSharper restore InconsistentNaming
    }
}
