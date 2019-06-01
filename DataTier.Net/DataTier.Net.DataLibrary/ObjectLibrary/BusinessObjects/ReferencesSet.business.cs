

#region using statements

using System;
using System.Collections.Generic;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ReferencesSet
    [Serializable]
    public partial class ReferencesSet
    {

        #region Private Variables
        private List<ProjectReference> references;
        #endregion

        #region Constructors

            #region Default Constructor
            /// <summary>
            /// Create a new instance of a 'ReferencesSet' object.
            /// </summary>
            public ReferencesSet()
            {
                // perform initializations for this object
                Init();
            }
            #endregion

            #region Parameterized Constructor
            /// <summary>
            /// Create a new instance of a 'ReferencesSet' object.
            /// </summary>
            /// <param name="referencesSetName"></param>
            public ReferencesSet(string referencesSetName)
            {
                // set the name of this set
                this.ReferencesSetName = referencesSetName;

                // perform initializations for this object
                Init();
            } 
            #endregion

        #endregion

        #region Methods

            #region GetReferenceIndex(int referenceId)
            /// <summary>
            /// This method returns the Reference Index
            /// </summary>
            public int GetReferenceIndex(int referenceId)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the References object exists
                if (this.HasReferences)
                {
                    // Iterate the collection of ProjectReference objects
                    foreach (ProjectReference reference in References)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this is the item being sought
                        if (reference.ReferencesId == referenceId)
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion

            #region Clone()
            /// <summary>
            /// Override the shallow copy clone to do a manual clone.
            /// </summary>
            /// <returns></returns>
            public ReferencesSet Clone()
            {
                // Create New Object
                ReferencesSet newReferencesSet = new ReferencesSet();

                // Set each property
                newReferencesSet.ProjectId = this.ProjectId;
                newReferencesSet.ReferencesSetName = this.ReferencesSetName;
                
                // Recreate the references
                newReferencesSet.References = new List<ProjectReference>();

                // If the References object exists
                if (this.HasReferences)
                {
                    // Iterate the collection of ProjectReference objects
                    foreach (ProjectReference reference in References)
                    {
                        // add the ProjectReference
                        ProjectReference projectReference = new ProjectReference();

                        // Set the name
                        projectReference.ReferenceName = reference.ReferenceName;
                        projectReference.UpdateIdentity(reference.ReferencesId);
                        projectReference.ReferencesSetId = this.ReferencesSetId;
                        
                        // Add this reference
                        newReferencesSet.References.Add(projectReference);
                    }
                }

                // Return Cloned Object
                return newReferencesSet;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// Perform initializations for this object.
            /// </summary>
            private void Init()
            {
                // create the References collection
                this.References = new List<ProjectReference>();
            } 
            #endregion

            #region SetReferencesSetId(int referencesSetId)
            /// <summary>
            /// This method Set ReferencesSetId
            /// </summary>
            public void SetReferencesSetId(int referencesSetId)
            {
                // If the References object exists
                if (this.HasReferences)
                {  
                    // Iterate the collection of ProjectReference objects
                    foreach (ProjectReference reference in References)
                    {
                        // Set the value
                        reference.ReferencesSetId = referencesSetId;
                    }
                }
            }
            #endregion
            
            #region ToString()
            /// <summary>
            /// This method returns the name of the ReferencesSet when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return this.ReferencesSetName;
            } 
            #endregion

        #endregion

        #region Properties

            #region HasReferences
            /// <summary>
            /// This property returns true if this object has a 'References'.
            /// </summary>
            public bool HasReferences
            {
                get
                {
                    // initial value
                    bool hasReferences = (this.References != null);
                    
                    // return value
                    return hasReferences;
                }
            }
            #endregion
            
            #region References
            /// <summary>
            /// This is a collection of References for this ReferencesSet.
            /// </summary>
            public List<ProjectReference> References
            {
                get { return references; }
                set { references = value; }
            } 
            #endregion

        #endregion

    }
    #endregion

}
