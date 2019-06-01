

#region using statements

using System;
using DataTierClient.Controls;
using ObjectLibrary.BusinessObjects;
using DataTierClient.Enumerations;
#endregion


namespace DataTierClient.Controls.Interfaces
{

    #region interface ITabButtonParent
    /// <summary>
    /// These are the properties that all Wizard Controls must 
    /// implement.
    /// </summary>
    public interface ITabButtonParent
    {   
        // Methods
        void OnTabButtonClicked(TabButton tabButton);
    }
    #endregion
    
}
