
#region using statements

using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Notification
    [Serializable]
    public partial class Notification
    {

        #region Private Variables
        private bool findBy;
        private bool findByEmailAddress;
        #endregion

        #region Constructor
        public Notification()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Notification Clone()
            {
                // Create New Object
                Notification newNotification = (Notification) this.MemberwiseClone();

                // Return Cloned Object
                return newNotification;
            }
            #endregion

        #endregion

        #region Properties

            #region FindBy
            /// <summary>
            /// This property gets or sets the value for 'FindBy'.
            /// </summary>
            public bool FindBy
            {
                get { return findBy; }
                set { findBy = value; }
            }
            #endregion

            #region FindByEmailAddress
            /// <summary>
            /// This property gets or sets the value for 'FindByEmailAddress'.
            /// </summary>
            public bool FindByEmailAddress
            {
                get { return findByEmailAddress; }
                set { findByEmailAddress = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
