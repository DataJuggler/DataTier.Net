
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class DTNTable
    [Serializable]
    public partial class DTNTable
    {

        #region Private Variables
        private bool loadByProjectId;
        #endregion

        #region Constructor
        public DTNTable()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNTable Clone()
            {
                // Create New Object
                DTNTable newDTNTable = (DTNTable) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNTable;
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
