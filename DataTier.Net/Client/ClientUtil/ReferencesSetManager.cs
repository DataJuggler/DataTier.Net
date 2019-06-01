
#region using statements

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using DataTierClient.Forms;
using ObjectLibrary.BusinessObjects;

#endregion

namespace DataTierClient.ClientUtil
{

    #region ReferencesSetManager
    /// <summary>
    /// This class is designed to create or edit referencessets
    /// and the References that are contained within each set.
    /// </summary>
    public class ReferencesSetManager
    {
    
        #region Static Methods

            #region LoadReferencesSetComboBox(List<ReferencesSet> allReferences, ComboBox comboBox)
            /// <summary>
            /// This method loads the combobox with all references set choices.
            /// </summary>
            /// <param name="allReferences"></param>
            /// <param name="comboBox"></param>
            public static void LoadReferencesSetComboBox(List<ReferencesSet> allReferences, ComboBox comboBox)
            {
                // if allReferences and the combo box exist
                if((allReferences != null) && (comboBox != null))
                {
                    // Clear the combo box
                    comboBox.Items.Clear();
                    
                    // add each references set
                    foreach(ReferencesSet reference in allReferences)
                    {
                        // Add this reference
                        comboBox.Items.Add(reference);
                    }
                    
                    // refresh
                    comboBox.Refresh();
                }
            }    
            #endregion

            #region CreateNewReferencesSet(Project selectedProject)
            /// <summary>
            /// Create a new references set.
            /// </summary>
            /// <returns></returns>
            public static ReferencesSet CreateNewReferencesSet(Project selectedProject)
            {
                // initial value
                ReferencesSet refSet = new ReferencesSet();
                
                // Create references Set form 
                ReferencesSetEditorForm referencesForm = new ReferencesSetEditorForm();
                
                // Set the selected project
                referencesForm.ReferencesSetEditor.SelectedProject = selectedProject;
                
                // prepare control
                referencesForm.ReferencesSetEditor.Setup(refSet);
                
                // references set editor
                referencesForm.ShowDialog();
                
                // if the user did not cancel
                if(!referencesForm.UserCancelled)
                {
                    // set refSet
                    refSet = referencesForm.ReferencesSetEditor.SelectedReferencesSet;
                }
                else
                {
                    // set to null
                    refSet = null;
                }
                
                // return value
                return refSet;
            }
            #endregion

            #region EditReferencesSet(ProjectReferences selectedReference, Project selectedProject)
            /// <summary>
            /// Edit an existing ReferencesSet.
            /// </summary>
            /// <returns></returns>
            public static ReferencesSet EditReferencesSet(ReferencesSet selectedReferencesSet, Project selectedProject)
            {   
                // initial value
                ReferencesSet refSet = null;
            
                // Create references Set form 
                ReferencesSetEditorForm referencesForm = new ReferencesSetEditorForm();

                // Set the selected project
                referencesForm.ReferencesSetEditor.SelectedProject = selectedProject;

                // prepare control
                referencesForm.ReferencesSetEditor.Setup(selectedReferencesSet);

                // references set editor
                referencesForm.ShowDialog();

                // if the user did not cancel
                if (!referencesForm.UserCancelled)
                {
                    // set refSet
                    refSet = referencesForm.ReferencesSetEditor.SelectedReferencesSet;
                }
                else
                {
                    // set to null
                    refSet = null;
                }

                // return value
                return refSet;
            }
            #endregion
             
        #endregion
        
    }
    #endregion
    
}
