

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

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
