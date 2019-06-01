
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

    #region class MatchedField
    /// <summary>
    /// This class represents two fields that must be
    /// equal before continuing (passwords for example.)
    /// </summary>
    public class MatchedField
    {

        #region Private Variables
        private string field1Name;
        private string field2Name;
        private string failedMessage;
        private FieldDataTypeEnum dataType;
        private ErrorHandler errorProcessor;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a 'MatchedField'.
        /// </summary>
        /// <param name="fieldName1Arg">The name of the first field.</param>
        /// <param name="fieldName2Arg">The name of the second field. </param>
        /// <param name="failedMessageArg"></param>
        /// <param name="parentObject"></param>
        /// <param name="errorProcessorArg"></param>
        public MatchedField(string fieldName1Arg, string fieldName2Arg, string failedMessageArg, object parentObject, ErrorHandler errorProcessorArg)
        {
            // Set Properties
            this.Field1Name = fieldName1Arg;
            this.Field2Name = fieldName2Arg;
            this.FailedMessage = failedMessageArg;
            this.ErrorProcessor = errorProcessorArg;

            try
            {
                // Set DataType
                this.DataType = ReflectionManager.ParseDataType(this.Field1Name, parentObject);
            }
            catch (Exception error)
            {
                // If ErrorProcessor exists
                if (this.ErrorProcessor != null)
                {
                    // locals
                    string methodName = "RequiredFieldConstructor";
                    string objectName = "ApplicationLogicComponent.ClientValidation.RequiredField";

                    // Log the exception
                    this.ErrorProcessor.LogError(methodName, objectName, error);
                }
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
        public static string CreateMissingRequiredFieldMessage(string fieldName)
        {
            // Create StringBuilder
            StringBuilder sb = new StringBuilder("The field '");

            // append fieldName
            sb.Append(fieldName);

            // append rest of message
            sb.Append("' is required.");

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

        #region ErrorProcessor
        /// <summary>
        /// This object handles all errors in this application.
        /// </summary>
        public ErrorHandler ErrorProcessor
        {
            get { return errorProcessor; }
            set { errorProcessor = value; }
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

        #region Field1Name
        /// <summary>
        /// The name of the field that is a 'RequiredField'.
        /// </summary>
        public string Field1Name
        {
            get { return field1Name; }
            set { field1Name = value; }
        }
        #endregion

        #region Field2Name
        /// <summary>
        /// The name of the field that is a 'RequiredField'.
        /// </summary>
        public string Field2Name
        {
            get { return field2Name; }
            set { field2Name = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
