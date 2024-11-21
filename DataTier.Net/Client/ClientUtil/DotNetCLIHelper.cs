

#region using statements

using System.Diagnostics;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class DotNetCLIHelper
    /// <summary>
    /// This class is used to test if a NuGet package is already installed.in the DotNetCLI
    /// </summary>
    public class DotNetCLIHelper
    {
        
        #region Methods
            
            #region IsTemplatePackageInstalled(string packageName, string packageVersion)
            /// <summary>
            /// method Is Template Package Installed
            /// </summary>
            public static bool IsTemplatePackageInstalled(string packageName)
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "dotnet",
                        Arguments = "new list",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                    };
                    
                    process.Start();
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    bool returnValue = result.Contains(packageName);
                    
                    // return true if installed
                    return returnValue;
                }
                #endregion
                
            #endregion
            
        }
        #endregion
    
    }
