

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace ConnectionBuilder
{

    #region class Program
    /// <summary>
    /// This is the main entry point for this application
    /// </summary>
    static class Program
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region Main
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ConnectionStringBuilderForm());
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
