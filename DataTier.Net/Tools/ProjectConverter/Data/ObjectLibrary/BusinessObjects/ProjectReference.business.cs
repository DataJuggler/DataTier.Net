
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
        private bool loadByReferencesSetId;
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

            #region LoadByReferencesSetId
            /// <summary>
            /// This property gets or sets the value for 'LoadByReferencesSetId'.
            /// </summary>
            public bool LoadByReferencesSetId
            {
                get { return loadByReferencesSetId; }
                set { loadByReferencesSetId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
