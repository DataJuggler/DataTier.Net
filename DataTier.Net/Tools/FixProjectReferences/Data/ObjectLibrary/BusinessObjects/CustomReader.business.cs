

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class CustomReader
    [Serializable]
    public partial class CustomReader
    {

        #region Private Variables
        #endregion

        #region Constructor
        public CustomReader()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public CustomReader Clone()
            {
                // Create New Object
                CustomReader newCustomReader = (CustomReader) this.MemberwiseClone();

                // Return Cloned Object
                return newCustomReader;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
