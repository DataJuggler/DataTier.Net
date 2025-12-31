
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
