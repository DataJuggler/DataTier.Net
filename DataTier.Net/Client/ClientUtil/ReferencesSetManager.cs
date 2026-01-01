
#region using statements

using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using DataJuggler.Core.UltimateHelper;
using DataTierClient.Forms;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

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
             
            #region EnsureReferences()
            /// <summary>
            /// returns a list of References
            /// </summary>
            public static List<ProjectReference> EnsureReferences(Project project)
            {
                // initial value
                List<ProjectReference> references = null;

                // If the project object exists
                if (NullHelper.Exists(project))
                {
                    // if true
                    if (project.AddIGridValueInterface)
                    {
                        // If the value for the property SelectedProject.HasObjectReferencesSet is true
                        if (project.HasObjectReferencesSet)
                        {
                            // find the reference
                            ProjectReference reference = project.ObjectReferencesSet.References.FirstOrDefault(x => x.ReferenceName == "DataJuggler.NET.Data.Interfaces");

                            // If the reference object does not exist
                            if (NullHelper.IsNull(reference))
                            {
                                reference = new ProjectReference();
                                reference.ReferencesSetId = project.ObjectReferencesSetId;
                                reference.ReferenceName = "DataJuggler.NET.Data.Interfaces";

                                // Create a new instance of a 'Gateway' object.
                                Gateway gateway = new Gateway(ConnectionConstants.Name);
                                
                                // Saving on the user's behalf, so they don't have to do anything.
                                bool saved = gateway.SaveProjectReference(ref reference);

                                // Add this reference
                                project.ObjectReferencesSet.References.Add(reference);
                            }

                            // set the return value
                            references = project.ObjectReferencesSet.References;
                        }
                    }
                }

                // return value
                return references;
            }
            #endregion
            
        #endregion
        
    }
    #endregion
    
}
