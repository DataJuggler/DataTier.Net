

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ReferencesSet
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    [Serializable]
    public partial class ReferencesSet
    {
        
        #region Private Variables
        private bool fetchAllForProjectId;
        private ObservableCollection<ProjectReference> references;
        private bool loading;
        #endregion
        
        #region Constructors
            
            #region Constructor
            /// <summary>
            /// Create a new instance of a 'ReferencesSet' object.
            /// </summary>
            public ReferencesSet()
            {
                // perform initializations for this object
                Init();
            }
            #endregion
            
            #region Constructor
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
        
        #region Events
            
            #region References_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            /// <summary>
            /// event is fired when References _ Collection Changed
            /// </summary>
            private void References_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                // only breakpoint here if loading
                if (!this.Loading)
                {
                    // breakpoint only
                    DebugHelper.WriteDebugError("References_CollectionChanged", "ReferencesSet.business", null);
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
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
                newReferencesSet.References = new ObservableCollection<ProjectReference>();

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
            
            #region CreateObjectLibraryDefaultReferences()
            /// <summary>
            /// Create Object Library Default References
            /// </summary>
            public void CreateObjectLibraryDefaultReferences()
            {
                // this should never be null. Trying to solve why this is being set to null

                // recreate the references
                this.References = new ObservableCollection<ProjectReference>();

                // Rewire up the event
                this.References.CollectionChanged += References_CollectionChanged;

                // Turn this on
                this.Loading = true;

                // Create Object References
                this.References.Add(new ProjectReference("System"));
                this.References.Add(new ProjectReference("ObjectLibrary.Enumerations"));

                // turn Loading off
                this.Loading = false;
            }
            #endregion
            
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
            
            #region Init()
            /// <summary>
            /// Perform initializations for this object.
            /// </summary>
            private void Init()
            {
                // create the References collection
                this.References = new ObservableCollection<ProjectReference>();

                // Wire up the event listener
                this.References.CollectionChanged += References_CollectionChanged;
            }
            #endregion
            
            #region SetReferences()
            /// <summary>
            /// Set References
            /// </summary>
            public void SetReferences(ObservableCollection<ProjectReference> references)
            {
                // Set the references
                this.References = references;

                // if the value for HasReferences is true
                if (HasReferences)
                {
                    // rewire up the event
                    this.References.CollectionChanged += this.References_CollectionChanged;
                }
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
            
            #region FetchAllForProjectId
            /// <summary>
            /// This property gets or sets the value for 'FetchAllForProjectId'.
            /// </summary>
            public bool FetchAllForProjectId
            {
                get { return fetchAllForProjectId; }
                set { fetchAllForProjectId = value; }
            }
            #endregion
            
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
            
            #region Loading
            /// <summary>
            /// This property gets or sets the value for 'Loading'.
            /// </summary>
            public bool Loading
            {
                get { return loading; }
                set { loading = value; }
            }
            #endregion
            
            #region References
            /// <summary>
            /// This is a collection of References for this ReferencesSet.
            /// </summary>
            public ObservableCollection<ProjectReference> References
            {
                get { return references; }
                private set
                {
                    // set the value
                    references = value;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
