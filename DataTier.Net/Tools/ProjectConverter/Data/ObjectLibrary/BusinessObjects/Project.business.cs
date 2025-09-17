
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Project
    [Serializable]
    public partial class Project
    {

        #region Private Variables
        private bool findByProjectName;
        #endregion

        #region Constructor
        public Project()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Project Clone()
            {
                // Create New Object
                Project newProject = (Project) this.MemberwiseClone();

                // Return Cloned Object
                return newProject;
            }
        #endregion

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // helpful forr debugging
                return ProjectName + " - " + ProjectFolder;
            }
            #endregion
            
        #endregion

        #region Properties

            #region FindByProjectName
            /// <summary>
            /// This property gets or sets the value for 'FindByProjectName'.
            /// </summary>
            public bool FindByProjectName
            {
                get { return findByProjectName; }
                set { findByProjectName = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
