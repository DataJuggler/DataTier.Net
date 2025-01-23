

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldView
    [Serializable]
    public partial class FieldView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public FieldView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public FieldView Clone()
            {
                // Create New Object
                FieldView newFieldView = (FieldView) this.MemberwiseClone();

                // Return Cloned Object
                return newFieldView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
