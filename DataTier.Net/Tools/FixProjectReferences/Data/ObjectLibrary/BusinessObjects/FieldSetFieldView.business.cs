

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSetFieldView
    [Serializable]
    public partial class FieldSetFieldView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public FieldSetFieldView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public FieldSetFieldView Clone()
            {
                // Create New Object
                FieldSetFieldView newFieldSetFieldView = (FieldSetFieldView) this.MemberwiseClone();

                // Return Cloned Object
                return newFieldSetFieldView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
