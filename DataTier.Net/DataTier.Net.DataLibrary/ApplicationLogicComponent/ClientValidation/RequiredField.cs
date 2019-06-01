
#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using ApplicationLogicComponent.Exceptions;
using ApplicationLogicComponent.Logging;
using ApplicationLogicComponent.Reflection;

#endregion

namespace ApplicationLogicComponent.ClientValidation
{

    #region class RequiredField
    /// <summary>
    /// This class represents a field that must be
    /// filled out before continuing (logging in, saving, etc.)
    /// </summary>
    [Serializable]
    public class RequiredField
    {

        #region Private Variables
        private string fieldName;
        private string failedMessage;
        private bool isRequiredFolder;
        private FieldDataTypeEnum dataType;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a property name
        /// </summary>
        /// <param name="propertyNameArg">The name of the 'Property' that is required.</param>
        /// <param name="failedMessageArg">The message to display when the field is missing.</param>
        public RequiredField(string fieldNameArg, string failedMessageArg, object parentObjectArg, bool isRequiredFolderArg)
        {
            // Set Properties
            this.FieldName = fieldNameArg;
            this.FailedMessage = failedMessageArg;
            this.IsRequiredFolder = isRequiredFolderArg;
          
            try
            {
                // Set DataType
                this.DataType = ReflectionManager.ParseDataType(this.FieldName, parentObjectArg);
            }
            catch
            {
                
            }
        }
        #endregion

        #region Methods

            #region CreateMissingRequiredFieldMessage
            /// <summary>
            /// Create the failed message for a missing required field.
            /// </summary>
            /// <param name="propertyName">The 'RequiredField' that is missing.</param>
            /// <returns></returns>
            public static string CreateMissingRequiredFieldMessage(string fieldName, object value, bool isRequiredFolder)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();

                // If 
                if(isRequiredFolder)
                {
                    // if the value does not exist
                    if(value == null)
                    {
                        // Append The Field
                        sb.Append("The field '");

                        // Append FieldName
                        sb.Append(fieldName);

                        // append rest of message
                        sb.Append("' is required.");
                    }
                    else
                    {
                        // Append The Field
                        sb.Append("The folder '");
                        
                        // Append the value
                        sb.Append(value);
                        
                        // append rest of message
                        sb.Append("' does not exist.");
                    }
                }
                else
                {
                    // Append The Field
                    sb.Append("The field '");

                    // Append FieldName
                    sb.Append(fieldName);
                
                    // append rest of message
                    sb.Append("' is required.");
                }

                // return value
                return sb.ToString();
            }
            #endregion

        #endregion

        #region Properties

            #region DataType
            /// <summary>
            /// The type of property this required field is.
            /// </summary>
            public FieldDataTypeEnum DataType
            {
                get { return dataType; }
                set { dataType = value; }
            }
            #endregion

            #region FailedMessage
            /// <summary>
            /// The message to display when the field is missing.
            /// </summary>
            public string FailedMessage
            {
                get { return failedMessage; }
                set { failedMessage = value; }
            }
            #endregion

            #region FieldName
            /// <summary>
            /// The name of the field that is a 'RequiredField'.
            /// </summary>
            public string FieldName
            {
                get { return fieldName; }
                set { fieldName = value; }
            }
            #endregion

            #region IsRequiredFolder
            /// <summary>
            /// Is this required field a required folder. If yes
            /// this field must have a value in the parent object
            /// and that value must be a valid directory
            /// using System.IO.Directory.Exists(path).
            /// </summary>
            public bool IsRequiredFolder
            {
                get { return isRequiredFolder; }
                set { isRequiredFolder =  value; }
            } 
            #endregion

        #endregion

    }
    #endregion

}
