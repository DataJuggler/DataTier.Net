

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNDatabase
    [Serializable]
    public partial class DTNDatabase
    {

        #region Private Variables
        #endregion

        #region Constructor
        public DTNDatabase()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNDatabase Clone()
            {
                // Create New Object
                DTNDatabase newDTNDatabase = (DTNDatabase) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNDatabase;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
