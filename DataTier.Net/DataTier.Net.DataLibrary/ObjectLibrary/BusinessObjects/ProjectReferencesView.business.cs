

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
        #endregion

    }
    #endregion

}
