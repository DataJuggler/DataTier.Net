

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ProjectReference
    [Serializable]
    public partial class ProjectReference
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ProjectReference()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ProjectReference Clone()
            {
                // Create New Object
                ProjectReference newProjectReference = (ProjectReference) this.MemberwiseClone();

                // Return Cloned Object
                return newProjectReference;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
