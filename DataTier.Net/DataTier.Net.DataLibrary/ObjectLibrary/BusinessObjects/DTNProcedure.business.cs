

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNProcedure
    [Serializable]
    public partial class DTNProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        public DTNProcedure()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNProcedure Clone()
            {
                // Create New Object
                DTNProcedure newDTNProcedure = (DTNProcedure) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNProcedure;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
