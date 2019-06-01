
#region using statements

using System;
using DataTierClient.Controls;
using ObjectLibrary.BusinessObjects;
using DataTierClient.Enumerations;

#endregion

namespace DataTierClient.Controls.Interfaces
{

    #region interface ISaveCancelControl
    /// <summary>
    /// These are the methods that all controls that host the 
    /// SaveCancel control must implement.
    /// </summary>
    public interface ISaveCancelControl
    {   
        /// <summary>
        /// This event is used to indicate from the SaveCancelControl has
        /// executed a Save
        /// </summary>
        void OnSave();

        /// <summary>
        /// This event is used to indicate from the SaveCancelControl has
        /// executed a Cancel
        /// </summary>
        void OnCancel();
    }
    #endregion
    
}
