

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region ISaveCancelHost
    /// <summary>
    /// This two methods must be implemented in the parent.
    /// </summary>
    public interface ISaveCancelHost
    {

        #region OnCancel();
        /// <summary>
        /// The event to call when Cancel is clicked.
        /// </summary>
        void OnCancel();
        #endregion

        #region OnSave(bool close);
        /// <summary>
        /// The event to call when Save is clicked.
        /// </summary>
        bool OnSave(bool close);
        #endregion

    } 
    #endregion
    
}
