

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataJuggler.Win.Controls;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region interface ITabHostControlParent
    /// <summary>
    /// This interface is used to subscribe to the TabChange event in the TabHostontrol
    /// </summary>
    public interface ITabHostControlParent
    {

        #region Methods

            #region TabSelected(TabButton selectedTab);
            /// <summary>
            /// This event is used to subscribe to event as the ParentHost selects controls.
            /// </summary>
            /// <param name="selectedTab"></param>
            void TabSelected(TabButton selectedButton);
            #endregion

        #endregion

        #region Properties

            #region SelectedTab
            /// <summary>
            /// This property get or sets the value for the SelectedTab
            /// </summary>
            TabButton SelectedTab
            {
                get;
                set;
            }
            #endregion

        #endregion

    }
    #endregion

}
