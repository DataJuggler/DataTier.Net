
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ProjectReferencesView
    [Serializable]
    public partial class ProjectReferencesView
    {

        #region Private Variables
        private bool loadByProjectId;
        #endregion

        #region Constructor
        public ProjectReferencesView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ProjectReferencesView Clone()
            {
                // Create New Object
                ProjectReferencesView newProjectReferencesView = (ProjectReferencesView) this.MemberwiseClone();

                // Return Cloned Object
                return newProjectReferencesView;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadByProjectId
            /// <summary>
            /// This property gets or sets the value for 'LoadByProjectId'.
            /// </summary>
            public bool LoadByProjectId
            {
                get { return loadByProjectId; }
                set { loadByProjectId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
