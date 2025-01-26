
#region using statements

using System;
using DataTierClient.Controls;
using ObjectLibrary.BusinessObjects;
using DataTierClient.Enumerations;

#endregion

namespace DataTierClient.Controls.Interfaces
{

    #region interface IWizardControl
    /// <summary>
    /// These are the properties that all Wizard Controls must 
    /// implement.
    /// </summary>
    public interface IWizardControl
    {
        // Properties

        // Parent Project Wizard
        ProjectWizardControl ParentProjectWizard
        {
            get;
        }

        // The SelectedContact to edit
        Project SelectedProject
        {
            get;
        }

        // NextControl
        ActiveControlEnum NextControl
        {
            get;
            set;
        }

        // PrevControl
        ActiveControlEnum PrevControl
        {
            get;
            set;
        }
        
        // EditMode
        bool EditMode
        {
            get;
        }
        
        // Methods
        void Init();
        void DisplaySelectedProject();
        
    }
    #endregion
    
}
