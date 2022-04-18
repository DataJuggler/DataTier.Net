

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class UIObject
    [Serializable]
    public partial class UIObject
    {

        #region Private Variables
        #endregion

        #region Constructor
        public UIObject()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public UIObject Clone()
            {
                // Create New Object
                UIObject newUIObject = (UIObject) this.MemberwiseClone();

                // Return Cloned Object
                return newUIObject;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
