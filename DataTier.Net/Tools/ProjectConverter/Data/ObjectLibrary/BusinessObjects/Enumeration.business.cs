

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Enumeration
    [Serializable]
    public partial class Enumeration
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Enumeration()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Enumeration Clone()
            {
                // Create New Object
                Enumeration newEnumeration = (Enumeration) this.MemberwiseClone();

                // Return Cloned Object
                return newEnumeration;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
