

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNField
    [Serializable]
    public partial class DTNField
    {

        #region Private Variables
        #endregion

        #region Constructor
        public DTNField()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNField Clone()
            {
                // Create New Object
                DTNField newDTNField = (DTNField) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNField;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
