
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

            #region LoadReferencesSetComboBox(Project selectedProject, ComboBox comboBox)
            /// <summary>
            /// This method loads the combobox with all references set choices.
            /// </summary>
            /// <param name="selectedProject"></param>
            /// <param name="comboBox"></param>
            public static void LoadReferencesSetComboBox(Project selectedProject, ComboBox comboBox)
            {
                // if selectedProject and the combo box exist
                if ((selectedProject != null) && (comboBox != null))
                {
                    // Clear the combo box
                    comboBox.Items.Clear();

                    // if this object has an ObjectReferencesSet
                    if (selectedProject.HasObjectReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.ObjectReferencesSet);
                    }

                    // StoredProcedureReferencesSet
                    if (selectedProject.HasStoredProcedureReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.StoredProcedureReferencesSet);
                    }

                    // ReaderReferencesSet
                    if (selectedProject.HasReaderReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.ReaderReferencesSet);
                    }

                    // ControllerReferencesSet
                    if (selectedProject.HasControllerReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.ControllerReferencesSet);
                    }

                    // DataOperationsReferencesSet
                    if (selectedProject.HasDataOperationsReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.DataOperationsReferencesSet);
                    }

                    // DataManagerReferencesSet
                    if (selectedProject.HasDataManagerReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.DataManagerReferencesSet);
                    }

                    // WriterReferencesSet
                    if (selectedProject.HasWriterReferencesSet)
                    {
                        // Add this reference
                        comboBox.Items.Add(selectedProject.WriterReferencesSet);
                    }

                    // refresh
                    comboBox.Refresh();
                }
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
