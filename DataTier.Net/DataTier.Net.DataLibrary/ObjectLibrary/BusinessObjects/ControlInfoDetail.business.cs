

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ControlInfoDetail
    [Serializable]
    public partial class ControlInfoDetail
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ControlInfoDetail()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ControlInfoDetail Clone()
            {
                // Create New Object
                ControlInfoDetail newControlInfoDetail = (ControlInfoDetail) this.MemberwiseClone();

                // Return Cloned Object
                return newControlInfoDetail;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
