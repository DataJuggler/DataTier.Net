
#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DataAccessComponent.Reflection
{

    #region class RADFieldValuePair
    /// <summary>
    /// This object represents one property
    /// in a RADBusinessObject.
    /// This is used to determine if an object
    /// has been modified since it was loaded.
    /// </summary>
    public class FieldValuePair
    {

        #region Private Variables
        private string fieldName;
        private object fieldValue;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a 
        /// </summary>
        /// <param name="fieldNameArg"></param>
        /// <param name="fieldValueArg"></param>
        public FieldValuePair(string fieldNameArg, object fieldValueArg)
        {
            // set properties
            this.FieldName = fieldNameArg;
            this.fieldValue = fieldValueArg;
        }
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // override the default type display
                return this.FieldName + " = " + this.FieldValue;
            }
            #endregion
            
        #endregion

        #region Properties

        #region FieldName
        /// <summary>
        /// The name for this field.
        /// </summary>
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        #endregion

        #region FieldValue
        /// <summary>
        /// The value for this property
        /// </summary>
        public object FieldValue
        {
            get { return fieldValue; }
            set { fieldValue = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
