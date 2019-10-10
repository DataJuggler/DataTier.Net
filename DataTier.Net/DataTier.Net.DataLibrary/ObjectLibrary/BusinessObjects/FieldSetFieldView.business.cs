
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

            #region ToString()
            /// <summary>
            /// This method is used to display the FieldName & 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // initial value
                string toString = FieldName;
            
                // if the value for OrderByDescending is true
                if (OrderByDescending)
                {
                    // add desc to the end
                    toString += " desc";
                }

                // return value
                return toString;
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
