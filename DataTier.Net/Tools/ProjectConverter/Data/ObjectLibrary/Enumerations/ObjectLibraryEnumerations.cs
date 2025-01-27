

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum SampleEnum : int
    /// <summary>
    /// This enum is only here so that the Enumerations reference compiles.
    /// You can remove this but if you do you also need to remove the reference
    /// in DataManager for this object.
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        Default = 0,
        ConvertOrFixProjects = 1,
        UpgradeProjects = 2,
        MoveProjects = 3
    }
    #endregion

}
