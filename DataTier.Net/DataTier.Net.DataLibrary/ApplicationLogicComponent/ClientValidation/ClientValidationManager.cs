
#region using statements

using System;
using System.Collections.Generic;
using System.IO;
using ApplicationLogicComponent.Reflection;
using ObjectLibrary.BusinessObjects;

#endregion

namespace ApplicationLogicComponent.ClientValidation
{

    #region ClientValidationManager
    /// <summary>
    /// This class handles client validation for this application.
    /// </summary>
    public class ClientValidationManager
    {

        #region Private Variables
        private List<RequiredField> missingFields;
        private List<RequiredField> requiredFields;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ClientValidationManager.
        /// </summary>
        public ClientValidationManager()
        {
            // Perform Initializations
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs any initializations 
            /// for this object.
            /// </summary>
            private void Init()
            {
                // Create Required Fields Object
                this.RequiredFields = new List<RequiredField>();
                this.MissingFields = new List<RequiredField>();
            }
            #endregion

            #region Validate(object sourceObject)
            /// <summary>
            /// This method validates an object.
            /// </summary>
            /// <param name="sourceObject"></param>
            /// <returns></returns>
            public bool Validate(object sourceObject)
            {
                // initial value
                bool valid = false;
            
                 // Clear Missing Fields
                 this.MissingFields = new List<RequiredField>();
                 
                 // local
                 bool validField = false;
                 
                 // Get the property Attributes
                 List<FieldValuePair> attributes = ReflectionManager.GetPropertyAttributes(sourceObject);
                 
                 // Loop thr ough each required field
                 foreach(RequiredField field in this.RequiredFields)
                 {
                    // reset
                    validField = false;
                 
                     // Loop through each field value pair in attributes
                     foreach(FieldValuePair fieldPair in attributes)
                     {
                        // If the fieldNames match
                        if(fieldPair.FieldName == field.FieldName)
                        {   
                            // If the field validates
                            if(fieldPair.FieldValue != null)
                            {
                                // if this is a required folder
                                if(field.IsRequiredFolder)
                                {
                                    // Test if the folder exists
                                    string folderPath = fieldPair.FieldValue.ToString();
                                    
                                    // if the folderPath string exists
                                    if ((!String.IsNullOrEmpty(folderPath)) && (Directory.Exists(folderPath)))
                                    {
                                        // this is a valid field
                                        validField = true;
                                    }
                                }
                                else if(field.DataType == FieldDataTypeEnum.String)
                                {
                                    // if FieldValue
                                    if(!String.IsNullOrEmpty(fieldPair.FieldValue.ToString()))
                                    {   
                                        // This is not a missing field
                                        validField = true;
                                    }
                                }
                                else
                                {
                                    // not sure if this is needed
                                    validField = true;
                                }
                            }
                                     
                            // break out of inner foreach loop (as not valid)
                            break;
                        }
                     }

                     // if this is not a valid field
                     if (!validField)
                     {
                         // Add to missing fields
                         this.MissingFields.Add(field);
                     }
                }
                
                // If the missing fields has items this is not valid.
                valid = (this.MissingFields.Count == 0);
                
                // return value
                return valid;
            }
            #endregion
            
        #endregion

        #region Properties

            #region MissingFields
            /// <summary>
            /// This is a collection of missing fields
            /// </summary>
            public List<RequiredField> MissingFields
            {
                get { return missingFields; }
                set { missingFields = value; }
            }
            #endregion

            #region RequiredFields
            /// <summary>
            /// The collection of required fields for this 
            /// object.
            /// </summary>
            public List<RequiredField> RequiredFields
            {
                get { return requiredFields; }
                set { requiredFields = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
