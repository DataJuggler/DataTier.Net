

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

#endregion

namespace $safeprojectname$.Security
{

    #region class ConfigurationHelper
    /// <summary>
    /// This class is used to read from the Web.config or App.config files
    /// </summary>
    public class ConfigurationHelper
    {
        
        #region Methods

            #region ReadAppSetting(string settingName, bool dataIsEncrypted = false, string encryptionKey = "")
            /// <summary>
            /// This method reads and decrypts the values
            /// in the App.config or Web.config appSettings section.
            /// </summary>
            /// <param name="settingName"></param>
            /// <returns></returns>
            public static string ReadAppSetting(string settingName, bool dataIsEncrypted = false, string encryptionKey = "")
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
                        // if the data is encrypted
                        if (dataIsEncrypted)
                        {
                            // we must decrypt the data
                            if (TextHelper.Exists(encryptionKey))
                            {
                                // use the default encryption key
                                settingValue = CryptographyManager.DecryptString(temp, encryptionKey);
                            }
                            else
                            {
                                // use the default encryption key
                                settingValue = CryptographyManager.DecryptString(temp);
                            }
                        }
                        else
                        {
                            // return the setting value as is
                            settingValue = temp;
                        }
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
