


#region using statements

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTierClient.Forms;

#endregion


namespace DataTierClient
{

    #region class Program
    static class Program
    {
        
        #region Main()
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch (Exception error)
			{
                string err = error.ToString();

				// End This Program
				Application.Exit();
			}
        }
        #endregion
        
    }
    #endregion
    
}