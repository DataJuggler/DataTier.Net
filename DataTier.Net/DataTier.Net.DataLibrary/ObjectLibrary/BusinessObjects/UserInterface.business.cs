
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class UserInterface
    [Serializable]
    public partial class UserInterface
    {

        #region Private Variables
        private bool findByProjectId;
        #endregion

        #region Constructor
        public UserInterface()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public UserInterface Clone()
            {
                // Create New Object
                UserInterface newUserInterface = (UserInterface) this.MemberwiseClone();

                // Return Cloned Object
                return newUserInterface;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByProjectId
            /// <summary>
            /// This property gets or sets the value for 'FindByProjectId'.
            /// </summary>
            public bool FindByProjectId
            {
                get { return findByProjectId; }
                set { findByProjectId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
