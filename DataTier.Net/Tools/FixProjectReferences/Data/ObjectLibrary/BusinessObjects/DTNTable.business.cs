

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
        #endregion

    }
    #endregion

}
