

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Method
    [Serializable]
    public partial class Method
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Method()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Method Clone()
            {
                // Create New Object
                Method newMethod = (Method) this.MemberwiseClone();

                // Return Cloned Object
                return newMethod;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
