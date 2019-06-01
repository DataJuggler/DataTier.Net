

#region using statements

using System;
using ObjectLibrary.Enumerations;

#endregion

namespace ObjectLibrary.Parsers
{

    #region class Parser
    /// <summary>
    /// This class parses enumerations for this project.
    /// </summary>
    public class Parser
    {

        #region Static Methods

            #region ParseClassFileOption(FileOptionsEnum fileOptions)
            /// <summary>
            /// This method returns a string for the class file options.
            /// </summary>
            /// <param name="fileOptions"></param>
            /// <returns></returns>
            public static string ParseFileOption(FileOptionsEnum fileOptions)
            {
                // initial value
                string fileOption = "";
                
                // determine string for each case
                switch(fileOptions)
                {
                    case FileOptionsEnum.SeperateFilesPerDatabase:
                    
                        // set file option
                        fileOption = "Seperate File Per Database";
                        
                            // required
                            break;
                            
                    case FileOptionsEnum.SeperateFilesPerTable:

                        // set file option
                        fileOption = "Seperate File Per Table";

                        // required
                        break;

                    case FileOptionsEnum.SingleFile:

                        // set file option
                        fileOption = "Single File";

                        // required
                        break;
                }
                
                // return value
                return fileOption;
            }
            #endregion

            #region ParseMethodType(string methodTypeSource)
            /// <summary>
            /// This method returns a MethodTypeEnum for the string given.
            /// </summary>
            /// <param name="methodTypeSource"></param>
            /// <returns></returns>
            public static MethodTypeEnum ParseMethodType(string methodTypeSource)
            {
                // initial value
                MethodTypeEnum methodType = MethodTypeEnum.Unknown;
                
                // determine MethodType for each case
                switch(methodTypeSource)
                {
                    case "Delete By":
                    case "Delete_By":

                        // set methodType
                        methodType = MethodTypeEnum.Delete_By;
                        
                        // required
                        break;

                    case "Find By":
                    case "Find_By":

                        // set methodType
                        methodType = MethodTypeEnum.Find_By;
                        
                        // required
                        break;
                    
                    case "Load By":
                    case "Load_By":

                       // set methodType
                        methodType = MethodTypeEnum.Load_By;

                        // required
                        break;
                }
                
                // return value
                return methodType;
            }
            #endregion

            #region ParseParameterType(string parameterTypeSource)
            /// <summary>
            /// This parameter returns a ParameterTypeEnum for the string given.
            /// </summary>
            /// <param name="parameterTypeSource"></param>
            /// <returns></returns>
            public static ParameterTypeEnum ParseParameterType(string parameterTypeSource)
            {
                // initial value
                ParameterTypeEnum parameterType = ParameterTypeEnum.No_Parameters;
                
                // determine ParameterType for each case
                switch(parameterTypeSource)
                {
                    case "Field_Set":
                    case "Field Set":

                        // set parameterType
                        parameterType = ParameterTypeEnum.Field_Set;
                        
                        // required
                        break;
                            
                    case "No Parameters":
                    case "No_Parameters":

                        // set parameterType
                        parameterType = ParameterTypeEnum.No_Parameters;

                        // required
                        break;

                    case "Single Field":
                    case "Single_Field":

                       // set parameterType
                        parameterType = ParameterTypeEnum.Single_Field;

                        // required
                        break;
                }
                
                // return value
                return parameterType;
            }
            #endregion

            #region ParseOrderByType(string orderByTypeSource)
            /// <summary>
            /// This orderBy returns a OrderByTypeEnum for the string given.
            /// </summary>
            /// <param name="orderByTypeSource"></param>
            /// <returns></returns>
            public static OrderByTypeEnum ParseOrderByType(string orderByTypeSource)
            {
                // initial value
                OrderByTypeEnum orderByType = OrderByTypeEnum.No_Order_By;
                
                // determine OrderByType for each case
                switch(orderByTypeSource)
                {
                    case "Field_Set":
                    case "Field Set":

                        // set orderByType
                        orderByType = OrderByTypeEnum.Field_Set;
                        
                        // required
                        break;
                            
                    case "No OrderBys":
                    case "No_OrderBys":

                        // set orderByType
                        orderByType = OrderByTypeEnum.No_Order_By;

                        // required
                        break;

                    case "Single Field":
                    case "Single_Field":

                       // set orderByType
                        orderByType = OrderByTypeEnum.Single_Field;

                        // required
                        break;
                }
                
                // return value
                return orderByType;
            }
            #endregion

        #endregion

    }
    #endregion

}
