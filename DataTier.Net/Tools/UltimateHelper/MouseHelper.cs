

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class MouseHelper
    /// <summary>
    /// This class is used to click a mouse
    /// </summary>
    public class MouseHelper
    {
        
        #region Constants For Interop
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        #endregion

        #region Methods

            #region MouseClick(Point point)
            /// <summary>
            /// This method is used to click the mouse use the current cursor position
            /// </summary>
            public static void MouseClick(Point point)
            {
                // Call the override to this method
                MouseClick(point.X, point.Y);
            }
            #endregion
            
            #region MouseClick(int x, int y)
            /// <summary>
            /// This method simulate a mouse click
            /// </summary>
            public static void MouseClick(int x, int y)
            {  
                // simulate the mouse click
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            }
            #endregion

        #endregion

    }
    #endregion

}
