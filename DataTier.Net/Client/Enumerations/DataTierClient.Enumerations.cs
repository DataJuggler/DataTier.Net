

namespace DataTierClient.Enumerations
{

	#region ActiveControlEnum : int
    /// <summary>
    /// This is a list of images for buttons
    /// </summary>
    public enum ActiveControlEnum : int
    {
        NotSet = 0,
        ProjectsTab = 1,
        DatabasesTab = 2,
        DataObjectsTab = 3, 
        StoredProceduresTab = 4,
        ReadersTab = 5,
        WritersTab = 6,
        ControllersTab = 7,
        DataOperationsTab = 8,
        DataManagerTab = 9
    }
    #endregion

	#region ButtonImagesEnum : int
    /// <summary>
    /// This is a list of images for buttons
    /// </summary>
    public enum ButtonImagesEnum : int
    {
        NotSet = 0,
        DeepBlue = 1,
        DeepGray = 2
    }
    #endregion

	#region ExcludeObjectTypeEnum : int
	/// <summary>
    /// This object is used to set if an object in a ChangesSet
    /// is a DTNTable or a DTNField.
    /// </summary>
    public enum ExcludeObjectTypeEnum : int
    {
		Unknown = 0,
		Field = 1,
		Table = 2
	}
	#endregion

    #region TrueFalseEnum
    /// <summary>
    /// This enum is used to load the ComboBox for Encrypt Value.
    /// </summary>
    public enum TrueFalseEnum
    {
        False = 0,
        True = 1
    }
    #endregion

    #region VisibilityEnum : int
	/// <summary>
    /// This enum is ued to show or hide a control, because true false is confusing
    /// in a method called ShowOrHide.
    /// </summary>
    public enum VisibilityEnum : int
    {
	    Hide = 0,	
        Show = 1
	}
	#endregion

}
