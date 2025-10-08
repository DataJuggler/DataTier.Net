

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace DataJuggler.Win.Controls.Enumerations
{

    #region BrowseTypeEnum : int 
    /// <summary>
    /// This enumeration is used to determine which type of an object is being browsed for
    /// </summary>
    public enum BrowseTypeEnum : int 
    {
        File = 0,
        Folder = 1,
        CustomOpen = 2
    }
    #endregion

    #region CardTypeEnum : int
    /// <summary>
    /// The types of credit cards accepted
    /// </summary>
    public enum CardTypeEnum
    {
        NotSet = 0,
        Visa = 1,
        MasterCard = 2,
        AmericanExpress = 3
    }
    #endregion

    #region LocalTestType : int
    /// <summary>
    /// This enum represents the types of LocalTest
    /// </summary>
    public enum LocalTestType : int 
    {
        NewLocalTest = 0,
        OpenLocalTest = 1
    }
    #endregion

    #region ObjectTypeEnum : int
    /// <summary>
    /// You must create an ObjectID for any type of object you wish to edit.
    /// </summary>
    public enum ObjectTypeEnum : int
    {
        NotSet = 0,
        Product = 1,
        License = 2
    } 
    #endregion
    
    #region UseCaseTypeEnum
    /// <summary>
    /// Determine the type of use case to use
    /// </summary>
    public enum UseCaseTypeEnum : int
    {
        NotSet = 0,
        EditProduct = 1,
        EditProductList = 2,
        EditLicense = 3,
        EditLicenseList = 4
    } 
    #endregion
    
}
