
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
        private bool loadByFieldSetId;
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

            #region LoadByFieldSetId
            /// <summary>
            /// This property gets or sets the value for 'LoadByFieldSetId'.
            /// </summary>
            public bool LoadByFieldSetId
            {
                get { return loadByFieldSetId; }
                set { loadByFieldSetId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
