

namespace DataJuggler.Core.UltimateHelper.Enumerations
{

    #region enum AssemblyTypeEnum : int
    /// <summary>
    /// This enumeration is used to to return the assembly Name and Guid.
    /// The 'Entry' assembly is the assembly for the application or process that was the main entry point for an 
    /// application. The 'Executing' assembly would return the current dll or .exe.
    /// </summary>
    public enum AssemblyTypeEnum : int
    {
        EntryAssembly = 0,
        ExecutingAssembly = 1
    }
    #endregion

    #region enum BrowseForTypeEnum : int
    /// <summary>
    /// This enumeration is used to set the type of object you want to browse for,
    /// a file or a directory
    /// </summary>
    public enum BrowseForTypeEnum : int
    {
        BrowseForFile = 1,
        BrowseForDirectory = 2,
        CustomeOpen = 3
    }
    #endregion
        
}
