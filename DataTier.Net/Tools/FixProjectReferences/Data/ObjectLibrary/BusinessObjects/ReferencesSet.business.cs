
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ReferencesSet
    [Serializable]
    public partial class ReferencesSet
    {

        #region Private Variables
        
        private bool loadByProjectId;
        #endregion

        #region Constructor
        public ReferencesSet()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ReferencesSet Clone()
            {
                // Create New Object
                ReferencesSet newReferencesSet = (ReferencesSet) this.MemberwiseClone();

                // Return Cloned Object
                return newReferencesSet;
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
