

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class FieldSetFieldViewController
    /// <summary>
    /// This class controls a(n) 'FieldSetFieldView' object.
    /// </summary>
    public class FieldSetFieldViewController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'FieldSetFieldViewController' object.
        /// </summary>
        public FieldSetFieldViewController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateFieldSetFieldViewParameter
            /// <summary>
            /// This method creates the parameter for a 'FieldSetFieldView' data operation.
            /// </summary>
            /// <param name='fieldsetfieldview'>The 'FieldSetFieldView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateFieldSetFieldViewParameter(FieldSetFieldView fieldSetFieldView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = fieldSetFieldView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(FieldSetFieldView tempFieldSetFieldView)
            /// <summary>
            /// This method fetches a collection of 'FieldSetFieldView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FieldSetFieldView_FetchAll'.</summary>
            /// <param name='tempFieldSetFieldView'>A temporary FieldSetFieldView for passing values.</param>
            /// <returns>A collection of 'FieldSetFieldView' objects.</returns>
            public List<FieldSetFieldView> FetchAll(FieldSetFieldView tempFieldSetFieldView)
            {
                // Initial value
                List<FieldSetFieldView> fieldSetFieldViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.FieldSetFieldViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFieldSetFieldViewParameter(tempFieldSetFieldView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FieldSetFieldView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        fieldSetFieldViewList = (List<FieldSetFieldView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return fieldSetFieldViewList;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
