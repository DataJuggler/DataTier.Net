

#region using statements

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class FileHelper
    /// <summary>
    /// This class helps with accessing Files
    /// </summary>
    public class FileHelper
    {

        #region Methods

            #region AddFiles(List<string> sourceFiles, List<string> filesToAdd)
            /// <summary>
            /// This method returns a list of Files
            /// </summary>
            public static List<string> AddFiles(List<string> sourceFiles, List<string> filesToAdd)
            {
                // initial value
                List<string> files = null;

                // If the sourceFiles object exists
                if (NullHelper.Exists(sourceFiles))
                {
                    // Set the return value to the sourceFiles so far
                    files = sourceFiles;
                }
                else 
                {
                    // Create the return value
                    files = new List<string>();
                }

                // At this point the files return value has to exist

                // If the filesToAdd collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(filesToAdd))
                {   
                    // Iterate the collection of string objects
                    foreach (string file in filesToAdd)
                    {  
                        // Add this file
                        files.Add(file);
                    }
                }
                
                // return value
                return files;
            }
            #endregion

            #region CreateFileNameWithPartialGuid(string sourceFileName, int numberChars, bool addExtension = true, bool fileNameOnly = false)
            /// <summary>
            /// This method appends a partial Guid to a filename
            /// </summary>
            public static string CreateFileNameWithPartialGuid(string sourceFileName, int numberChars, bool addExtension = true, bool fileNameOnly = false)
            {
                // initial value
                string newPath = "";

                if (TextHelper.Exists(sourceFileName))
                {
                    // Get a fileInfo of the oldPath
                    FileInfo fileInfo = new FileInfo(sourceFileName);

                    // get the name
                    string name = GetFileNameWithoutExtension(sourceFileName);

                    // Get the directory
                    DirectoryInfo directory = fileInfo.Directory;

                    // get the directoryFullname
                    string fullPath = directory.FullName;

                    // newFileName
                    string newFileName = name + "." + Guid.NewGuid().ToString().Substring(0, numberChars);
                    
                    // if addExtension is true
                    if (addExtension)
                    {
                        // put the extension back
                        newFileName += fileInfo.Extension;
                    }

                    // if fileNameOnly
                    if (fileNameOnly)
                    {
                        // set the return value to the newFileName
                        newPath = newFileName;
                    }
                    else
                    {
                        // Get the new full Path
                        newPath = Path.Combine(fullPath, newFileName);
                    }
                }

                // return value
                return newPath;
            }
            #endregion
            
            #region DoesFileNameContainPartialGuid(string fileName)
            /// <summary>
            /// method returns the File Name Contain Partial Guid
            /// </summary>
            public static bool DoesFileNameContainPartialGuid(string fileName)
            {
                // initial value
                bool containsPartialGuid = false;
                
                try
                {
                    // if the fileName exists
                    if (TextHelper.Exists(fileName))
                    {
                        // if the name contains a quote, this causes an error
                        if (!fileName.Contains('\"'))
                        {
                            // Create a new instance of a 'FileInfo' object.
                            FileInfo fileInfo = new FileInfo(fileName);

                            // if the extension exists
                            if ((TextHelper.Exists(fileInfo.Extension)) && (fileInfo.Extension == ".pdf"))
                            {
                                // remove the extension
                                fileName = fileName.Replace(fileInfo.Extension, "");
                            }
                    
                            // get a reverse string
                            char[] charArray = fileName.Reverse().ToArray();
                            string temp = new string(charArray);
                    
                            // if greater than 12 character name
                            if (temp.Length > 12)
                            {
                                // this is most likely a partial guid created by TestOp
                                if ((temp[3] == '-') && (temp[12] == '.'))
                                {
                                    // set the return value
                                    containsPartialGuid = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("DoesFileNameContainPartialGuid", "FileHelper.cs", error);
                }
                
                // return value
                return containsPartialGuid;
            }
            #endregion

            #region Exists(string filePath)
            /// <summary>
            /// method returns the
            /// </summary>
            public static bool Exists(string filePath)
            {
                // initial value
                bool exists = false;

                // if the string exists
                if (TextHelper.Exists(filePath))
                {
                    // if the fileExists
                    if (System.IO.File.Exists(filePath))
                    {
                        // set to true
                        exists = true;
                    }
                }

                // return value
                return exists;
            }
            #endregion
           
            #region GetFileNameWithoutExtension(string fullName)
            /// <summary>
            /// This method returns the File Name Without Extension
            /// </summary>
            public static string GetFileNameWithoutExtension(string fullName)
            {
                // initial value
                string fileNameWithoutExtension = "";

                // Create a fileInfo object
                FileInfo fileInfo = new FileInfo(fullName);

                // if the extension exists
                if (TextHelper.Exists(fileInfo.Extension))
                {
                    // Remove the extension
                    fileNameWithoutExtension = fileInfo.Name.Replace(fileInfo.Extension, "");
                }
                else
                {
                    // There is not an extension
                    fileNameWithoutExtension = fileInfo.Name;
                }

                // return value
                return fileNameWithoutExtension;
            }
            #endregion

            #region GetFileNameWithoutExtensionEx(string fullName, ref string extension)
            /// <summary>
            /// This method returns the File Name Without Extension
            /// </summary>
            public static string GetFileNameWithoutExtensionEx(string fullName, ref string extension)
            {
                // initial value
                string fileNameWithoutExtension = "";

                // Create a fileInfo object
                FileInfo fileInfo = new FileInfo(fullName);

                 // if the extension exists
                if (TextHelper.Exists(fileInfo.Extension))
                {
                    // Remove the extension
                    fileNameWithoutExtension = fileInfo.Name.Replace(fileInfo.Extension, "");
                }
                else
                {
                    // There is not an extension
                    fileNameWithoutExtension = fileInfo.Name;
                }

                // set the extension
                extension = fileInfo.Extension;

                // return value
                return fileNameWithoutExtension;
            }
            #endregion

            #region GetFiles(string directoryPath, string filterExtension = "", bool removeExtension = false)
            /// <summary>
            /// This method returns a list of file names.
            /// </summary>
            /// <param name="directoryPath">The path to the Directory containing the files</param>
            /// <param name="filterExtension">If an extension is passed in, only files matching this extension
            /// will be returned.</param>
            /// <param name="removeExtension">If true, the extension is removed</param>
            /// <returns></returns>
            public static List<string> GetFiles(string directoryPath, string filterExtension = "", bool removeExtension = false)
            {
                // initial value
                List<string> files = new List<string>();

                // local
                string extension = "";

                // If the filePath string exists
                if ((TextHelper.Exists(directoryPath)) && (Directory.Exists(directoryPath)))
                {
                    // get the fileNames
                    string[] fileNames = Directory.GetFiles(directoryPath);

                    // if the fileNames exist
                    if ((fileNames != null) && (fileNames.Length > 0))
                    {
                        // if the value for removeExtension is true
                        if (removeExtension)
                        {
                            // get a tempList
                            List<string> tempNames = fileNames.ToList();

                            // Iterate the collection of string objects
                            foreach (string tempName in fileNames)
                            {
                                // get the name without the extension
                                string name = GetFileNameWithoutExtensionEx(tempName, ref extension);

                                // If the filterExtension string exists
                                if (TextHelper.Exists(filterExtension))
                                {
                                    // if the extension exists
                                    if (TextHelper.IsEqual(filterExtension, extension))
                                    {
                                        // Add this file
                                        files.Add(name);
                                    }
                                }
                                else
                                {
                                    // Add this file
                                    files.Add(name);
                                }
                            }
                        }
                        // if the filterExtension exists
                        else if (TextHelper.Exists(filterExtension))
                        {
                            // get a tempList
                            List<string> tempNames = fileNames.ToList();

                            // Iterate the collection of string objects
                            foreach (string tempName in fileNames)
                            {
                                // The name is not needed here, just getting the extension
                                GetFileNameWithoutExtensionEx(tempName, ref extension);

                                // if the extension exists
                                if (TextHelper.IsEqual(filterExtension, extension))
                                {
                                    // Add this file
                                    files.Add(tempName);
                                }
                            }
                        }
                        else
                        {
                            // get a tempList
                            List<string> tempNames = fileNames.ToList();

                            // Iterate the collection of string objects
                            foreach (string tempName in fileNames)
                            {
                                // Add this file
                                files.Add(tempName);
                            }
                        }
                    }
                }

                // return value
                return files;
            }
            #endregion

            #region GetFiles(string directoryPath, string filterExtension = "", bool removeExtension = false)
            /// <summary>
            /// This method returns a list of file names.
            /// </summary>
            /// <param name="directoryPath">The path to the Directory containing the files</param>
            /// <param name="filterExtensions">This override accepts a list of filters instead of just one so that mutliple types can be found</param>
            /// will be returned.</param>
            /// <param name="removeExtension">If true, the extension is removed</param>
            /// <returns></returns>
            public static List<string> GetFiles(string directoryPath, List<string> filterExtensions = null, bool removeExtension = false)
            {
                // initial value
                List<string> files = new List<string>();

                // local
                string extension = "";

                // If the filePath string exists
                if ((TextHelper.Exists(directoryPath)) && (Directory.Exists(directoryPath)))
                {
                    // get the fileNames
                    string[] fileNames = Directory.GetFiles(directoryPath);

                    // if the fileNames exist
                    if ((fileNames != null) && (fileNames.Length > 0))
                    {
                        // if the value for removeExtension is true
                        if (removeExtension)
                        {
                            // get a tempList
                            List<string> tempNames = fileNames.ToList();

                            // Iterate the collection of string objects
                            foreach (string tempName in fileNames)
                            {
                                // get the name without the extension
                                string name = GetFileNameWithoutExtensionEx(tempName, ref extension);

                                // If the filterExtension string exists
                                if (ListHelper.HasOneOrMoreItems(filterExtensions))
                                {
                                    // Iterate the collection of string objects
                                    foreach (string filterExtension in filterExtensions)
                                    {
                                        // if the extension exists
                                        if (TextHelper.IsEqual(filterExtension, extension))
                                        {
                                            // Add this file
                                            files.Add(name);
                                        }
                                    }
                                }
                                else
                                {
                                    // Add this file
                                    files.Add(name);
                                }
                            }
                        }
                        // if the filterExtension exists
                        else if (ListHelper.HasOneOrMoreItems(filterExtensions))
                        {
                            // get a tempList
                            List<string> tempNames = fileNames.ToList();

                            // Iterate the collection of string objects
                            foreach (string tempName in fileNames)
                            {
                                // The name is not needed here, just getting the extension
                                GetFileNameWithoutExtensionEx(tempName, ref extension);

                                // Iterate the collection of string objects
                                foreach (string filterExtension in filterExtensions)
                                {
                                    // if the extension exists
                                    if (TextHelper.IsEqual(filterExtension, extension))
                                    {
                                        // Add this file
                                        files.Add(tempName);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // get a tempList
                            List<string> tempNames = fileNames.ToList();

                            // Iterate the collection of string objects
                            foreach (string tempName in fileNames)
                            {
                                // Add this file
                                files.Add(tempName);
                            }
                        }
                    }
                }

                // return value
                return files;
            }
            #endregion

            #region GetFilesRecursively(string directoryPath, ref List<string> files, List<string> filterExtensions = null, bool removeExtension = false)
            /// <summary>
            /// This method returns a list of file names.
            /// </summary>
            /// <param name="files">The files must be passed in by reference because this method calls itself over and over and over and over, so use caution on where you call this.</param>
            /// <param name="directoryPath">The path to the Directory containing the files</param>
            /// <param name="filterExtensions">This override accepts a list of filters instead of just one so that mutliple types can be found</param>
            /// will be returned.</param>
            /// <param name="removeExtension">If true, the extension is removed</param>
            /// <returns></returns>
            public static List<string> GetFilesRecursively(string directoryPath, ref List<string> files, List<string> filterExtensions = null, bool removeExtension = false)
            {
                // locals
                List<string> tempFiles = null;
                List<string> directories = null;

                // If the filePath string exists
                if ((TextHelper.Exists(directoryPath)) && (Directory.Exists(directoryPath)))
                {
                    // get the files
                    tempFiles = GetFiles(directoryPath, filterExtensions, removeExtension);

                    // Add the files that were found (if the source files do not exist, they will be created)
                    files = AddFiles(files, tempFiles);

                    // get a list of directories
                    directories = Directory.GetDirectories(directoryPath).ToList();

                    // If the directories collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(directories))
                    {
                        // Iterate the collection of string objects
                        foreach (string directory in directories)
                        {
                            // get the files
                            tempFiles = GetFilesRecursively(directory, ref files, filterExtensions, removeExtension);

                            //// if any files were found
                            //if (ListHelper.HasOneOrMoreItems(tempFiles))
                            //{
                            //    // Add the files that were found (if the source files do not exist, they will be created)
                            //    files = AddFiles(files, tempFiles);
                            //}
                        }
                    }
                }

                // return value
                return files;
            }
            #endregion

            #region RemovePartialGuid(string fileName, bool fileNameOnly)
            /// <summary>
            /// returns the Partial Guid
            /// </summary>
            public static string RemovePartialGuid(string fileName, bool fileNameOnly)
            {
                // initial value
                if (TextHelper.Exists(fileName))
                {
                    // Create a new instance of a 'FileInfo' object.
                    FileInfo fileInfo = new FileInfo(fileName);

                    // set the index
                    int index = fileInfo.Name.IndexOf(".");

                    // if the index was found
                    if (index > 0)
                    {
                        // get the temp string
                        string temp  = fileInfo.Name.Substring(0, index);

                        // if fileNameOnly
                        if (fileNameOnly)
                        {
                            // add the extension back
                            fileName = temp + fileInfo.Extension;
                        }
                        else
                        {
                            // Get the new fileName
                            fileName = Path.Combine(fileInfo.DirectoryName, temp) + fileInfo.Extension;
                        }
                    }
                }
                
                // return value
                return fileName;
            }
            #endregion
            
            #region RemovePartialGuid(string fileNameWithPartialGuid)
            /// <summary>
            /// returns the Partial Guid
            /// </summary>
            /// <param name="fileNameWithPartialGuid">The file name with a partial guid such as Banana.853edcd1-216.jpg</param>
            public string RemovePartialGuid(string fileNameWithPartialGuid)
            {
                // initial value
                string fileName = "";

                // If the fileNameWithPartialGuid string exists
                if (TextHelper.Exists(fileNameWithPartialGuid))
                {
                    // get the index of the first dot
                    int index = fileNameWithPartialGuid.IndexOf(".");

                    // get the root name before the first dot
                    string subString = fileNameWithPartialGuid.Substring(0, index);

                    // Create a fileInfo object
                    FileInfo fileInfo = new FileInfo(fileNameWithPartialGuid);

                    // Set the return value
                    fileName = subString + fileInfo.Extension;
                }
                
                // return value
                return fileName;
            }
            #endregion

            #region ReplacePartialGuid(string fileName, bool addExtension = true, bool fileNameOnly)
            /// <summary>
            /// returns the Partial Guid
            /// </summary>
            public static string ReplacePartialGuid(string fileName, int numberChars, bool addExtension = true, bool fileNameOnly = false)
            {
                // initial value
                if (FileHelper.DoesFileNameContainPartialGuid(fileName))
                {
                    // remove the partial guid
                    fileName = RemovePartialGuid(fileName, fileNameOnly);    

                    // Create the fileName with a partial guid
                    fileName = CreateFileNameWithPartialGuid(fileName, numberChars, addExtension, fileNameOnly);
                }
                
                // return value
                return fileName;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
