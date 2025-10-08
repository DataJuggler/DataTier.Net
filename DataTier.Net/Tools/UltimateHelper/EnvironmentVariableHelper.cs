using System;

namespace DataJuggler.Core.UltimateHelper
{  
    
    public class EnvironmentVariableHelper
    {

        #region Methods
            
            #region GetEnvironmentVariableValue(string variableName, EnvironmentVariableTarget target)
            /// <summary>
            /// This method is used to get an environment value
            /// </summary>
            /// <param name="variableName"></param>
            /// <returns></returns>
            public static string GetEnvironmentVariableValue(string variableName, EnvironmentVariableTarget target)
            {
                // initial value
                string value = "";

                try
                {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        // Change the directory to %WINDIR%
                        value = Environment.GetEnvironmentVariable(variableName, target);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only, do something else with it if you need to
                    DebugHelper.WriteDebugError("GetEnvironmentVariableValue", "GetEnvironmentVariableValue", error);
                }

                // return value
                return value;
            }
            #endregion

            #region SetEnvironmentVariableValue(string name, string value, EnvironmentVariableTarget target)
            /// <summary>
            /// returns the Environment Variable Value
            /// </summary>
            public static bool SetEnvironmentVariableValue(string variableName, string value, EnvironmentVariableTarget target)
            {
                // initial value
                bool valueSet = false;

                try
                {
                    // if Windows
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        // Create the EnvironmentVariable value
                        Environment.SetEnvironmentVariable(variableName, value, target);

                        // set the value
                        valueSet = true;
                    }
                    else
                    {
                        // else I only use windows so others platforms are not supported.
                    }
                }
                catch (Exception error)
                {
                    // for debugging only, do something else with it if you need to
                    string err = error.ToString();
                }
                
                // return value
                return valueSet;
            }
            #endregion

        #endregion

    }

}
