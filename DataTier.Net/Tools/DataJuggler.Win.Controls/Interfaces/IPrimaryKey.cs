

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region interface IPrimaryKey
    /// <summary>
    /// This interface is used so that objects can define a primary key.
    /// The LabelComboBoxControl used this property to set the value of the
    /// ListItem to the Primary Key if the object implements IPrimaryKey.
    /// You should move this call to a shared location in your project.
    /// </summary>
    public interface IPrimaryKey
    {

        #region DisplayValue
        /// <summary>
        /// This object must return a string display value for the object.
        /// </summary>
        string DisplayValue
        {
            get;
        }
        #endregion

        #region PrimaryKeyValue
        /// <summary>
        /// This object must return a value for the PrimaryKeyID
        /// </summary>
        int PrimaryKeyValue
        {
            get;
        }
        #endregion

    }
    #endregion

}
