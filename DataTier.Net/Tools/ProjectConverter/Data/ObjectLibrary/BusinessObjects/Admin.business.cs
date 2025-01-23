

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Admin
    [Serializable]
    public partial class Admin
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Admin()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Admin Clone()
            {
                // Create New Object
                Admin newAdmin = (Admin) this.MemberwiseClone();

                // Return Cloned Object
                return newAdmin;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
