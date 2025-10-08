

#region using statements

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using DataJuggler.Core.UltimateHelper.Enumerations;
using System.IO;
using DataJuggler.Core.UltimateHelper.Objects;
using System.Collections.Generic;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class SystemHelper
    /// <summary>
    /// This class is used to get information abou the current system and executing application name and Guid.
    /// More methods will be added to this class later.
    /// </summary>
    public class SystemHelper
    {
        
        #region Methods
            
            
            
            #region GetAssemblyDirectory(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            /// <summary>
            /// This method returns the Assembly Directory
            /// </summary>
            public static string GetAssemblyDirectory(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            {
                // initial value
                string assemblyDirectory = "";

                try
                {
                    // get the assemblyPath
                    string assemblyPath = GetAssemblyPath(assemblyType);

                    // if the AssemblyPath exists
                    if (TextHelper.Exists(assemblyPath))
                    {
                        // Get the last backslash
                        int index = assemblyPath.LastIndexOf(@"\");

                        // if the index was found
                        if (index > 0)
                        {
                            // set the return value
                            assemblyDirectory = assemblyPath.Substring(0, index + 1);
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return assemblyDirectory;
            }
            #endregion
            
            #region GetAssemblyPath(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            /// <summary>
            /// This method returns the Assembly Path
            /// </summary>
            public static string GetAssemblyPath(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            {
                // initial value
                string path = "";

                try
                {
                    // create assembly   
                    Assembly assembly = null;

                    // if the ExecutingAssembly is selected
                    if (assemblyType == AssemblyTypeEnum.ExecutingAssembly)
                    {
                        // use the ExecutingAssembly
                        assembly = Assembly.GetExecutingAssembly();
                    }
                    else
                    {
                        // use the EntryAssembly
                        assembly = Assembly.GetEntryAssembly();
                    }

                    // if the assembly exists
                    if (assembly != null)
                    {
                        // set the return value
                        path = assembly.Location;
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return path;
            }
            #endregion
            
            #region GetSystemProductGuid(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            /// <summary>
            /// This method returns the ‘Entry’ assembly.Guid or the ‘Executing’ assembly.Guid. 
            /// The Entry’ assembly is the assembly that executed that caused the ExecutingAssembly to run. 
            /// These may or not be the same assembly depending on if this is called by the main application 
            /// assembly or by a .dll that is referenced by the main application assembly.
            /// <param name="assemblyType">Specify if you want the Guid from the 'Entry' assembly or the 
            /// 'Executing' assembly.</param>
            public static string GetSystemProductGuid(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            {
                // initial value
                string productGuid = Guid.Empty.ToString();

                try
                {
                    // create assembly   
                    Assembly assembly = null;

                    // if the ExecutingAssembly is selected
                    if (assemblyType == AssemblyTypeEnum.ExecutingAssembly)
                    {
                        // use the ExecutingAssembly
                        assembly = Assembly.GetExecutingAssembly();
                    }
                    else
                    {
                        // use the EntryAssembly
                        assembly = Assembly.GetEntryAssembly();
                    }

                    // if the assembly exists
                    if (assembly != null)
                    {
                        // create the attributes
                        var attributes = (assembly.GetCustomAttributes(typeof(GuidAttribute), true));

                        // now parse the return value
                        productGuid = (attributes[0] as GuidAttribute).Value;
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return productGuid;
            }
            #endregion

            #region GetSystemProductName(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            /// <summary>
            /// This method returns the ‘Entry’ assembly.Name or the ‘Executing’ assembly name.
            /// The EntryAssembly is the assembly that executed that caused the Executing assembly to run.
            /// These may or not be the same assembly depending on if this is called by the main application 
            /// assembly or by a .dll that is referenced by the main application assembly.
            /// <param name="assemblyType">Specify if you want the name from the 'Entry' assembly or the 
            /// 'Executing' assembly.</param>
            /// </summary>
            public static string GetSystemProductName(AssemblyTypeEnum assemblyType = AssemblyTypeEnum.EntryAssembly)
            {
                // initial value
                string systemProductName = "";

                try
                {
                    // create assembly   
                    Assembly assembly = null;

                    // if the ExecutingAssembly is selected
                    if (assemblyType == AssemblyTypeEnum.ExecutingAssembly)
                    {
                        // use the ExecutingAssembly
                        assembly = Assembly.GetExecutingAssembly();
                    }
                    else
                    {
                        // use the EntryAssembly
                        assembly = Assembly.GetEntryAssembly();
                    }

                    // if the assembly exists
                    if (assembly != null)
                    {
                        // set the return value
                        systemProductName = assembly.GetName().Name;
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return systemProductName;
            }
            #endregion

        #endregion


    }
    #endregion

}
