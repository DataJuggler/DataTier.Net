

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ControlInfo
    [Serializable]
    public partial class ControlInfo
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ControlInfo()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ControlInfo Clone()
            {
                // Create New Object
                ControlInfo newControlInfo = (ControlInfo) this.MemberwiseClone();

                // Return Cloned Object
                return newControlInfo;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
