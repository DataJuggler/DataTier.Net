
#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net.Enumerations;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class UIField
    [Serializable]
    public partial class UIField
    {

        #region Private Variables
        private bool findByUserInterfaceId;
        #endregion

        #region Constructor
        public UIField()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public UIField Clone()
            {
                // Create New Object
                UIField newUIField = (UIField) this.MemberwiseClone();

                // Return Cloned Object
                return newUIField;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByUserInterfaceId
            /// <summary>
            /// This property gets or sets the value for 'FindByUserInterfaceId'.
            /// </summary>
            public bool FindByUserInterfaceId
            {
                get { return findByUserInterfaceId; }
                set { findByUserInterfaceId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
