

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class TabImagesControl
    /// <summary>
    /// This class is used as an image resources control
    /// </summary>
    public partial class TabImagesControl : UserControl
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a TabImagesControl.
        /// </summary>
        public TabImagesControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region GetTabImage(bool selected)
            /// <summary>
            /// This method returns the Tab Image
            /// </summary>
            public Image GetTabImage(bool selected)
            {
                // initial value
                Image tabImage = null;

                // if the disabled tabButtons should be returned
                if (selected)
                {
                    // set the return value to the BlueTab
                    tabImage = this.BlueTab.BackgroundImage;
                }
                else
                {
                    // set the return value to the BlueTab
                    tabImage = this.DisabledTab.BackgroundImage;
                }

                // return value
                return tabImage;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
