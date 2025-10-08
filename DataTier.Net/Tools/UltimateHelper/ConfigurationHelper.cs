

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class ConfigurationHelper
    /// <summary>
    /// This class is used to read from the Web.config or App.config files
    /// </summary>
    public class ConfigurationHelper
    {
        
        #region Methods

            #region ReadAppSetting(string settingName)
            /// <summary>
            /// This method reads and decrypts the values
            /// in the App.config or Web.config appSettings section.
            /// </summary>
            /// <param name="settingName"></param>
            /// <returns></returns>
            public static string ReadAppSetting(string settingName)
            {
                // initial value
                string settingValue = null;

                // local
                string temp = "";

                try
                {
                    // if the setting exists
                    if (ConfigurationManager.AppSettings[settingName] != null)
                    {
                        // read the setting value from the App.Config or Web.Config
                        temp = ConfigurationManager.AppSettings[settingName].ToString();
                    }

                    // if the temp string exists
                    if (TextHelper.Exists(temp))
                    { 
                        // return the setting value as is
                        settingValue = temp;
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return settingValue;
            }
            #endregion

        #endregion
        
    }
    #endregion

}
