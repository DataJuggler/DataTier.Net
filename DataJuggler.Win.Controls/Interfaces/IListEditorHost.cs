

#region using statements

using DataJuggler.Win.Controls.Enumerations;
using System.Collections.Generic;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{
    
    /// <summary>
    /// This interface is used to host the ListEditorControl.
    /// </summary>
    public interface IListEditorHost
    {

        #region Properties
        
            #region EditMode
            /// <summary>
            /// This property gets or sets the value of EditMode
            /// </summary>
            EditModeEnum EditMode
            {
                get;
                set;
            }
            #endregion

            #region HasSelectedItem
            /// <summary>
            /// If the ParentListHost has a selected item, then return true;
            /// </summary>
            bool HasSelectedItem
            {
                get;
            }
            #endregion

            #region IsEditing
            /// <summary>
            /// This read only property returns true if EditMode is not equal to Read Only
            /// </summary>
            bool IsEditing
            {
                get;
            }
            #endregion

            #region SelectedItem
            /// <summary>
            /// The Selected object from the ListBox
            /// </summary>
            object SelectedItem
            {
                get;
                set;
            }
            #endregion

        #endregion

        #region Methods

            #region Add()
            /// <summary>
            /// This method is used to add an object to the list of items
            /// </summary>
            void Add();
            #endregion

            #region Cancel()
            /// <summary>
            /// Cancel the edit of the SelectedItem.
            /// </summary>
            void Cancel();
            #endregion

            #region Clear()
            /// <summary>
            /// Clear the control before adding or editing.
            /// </summary>
            void Clear();
            #endregion

            #region Edit()
            /// <summary>
            /// This method is used to edit an object in a list of items
            /// </summary>
            void Edit();
            #endregion

            #region Delete()
            /// <summary>
            /// This method is used to delete an object in a list of items
            /// </summary>
            void Delete();
            #endregion

            #region EnableSaveButton(bool enabled);
            /// <summary>
            /// This method is used to enable or disable the Save button based upon
            /// if there are changes or not
            /// </summary>
            /// <param name="enabled"></param>
            /// <returns></returns>
            void EnableSaveButton(bool enabled);
            #endregion

            #region ItemSelected(object selectedItem)
            /// <summary>
            /// This event is used to notify the ListEditorHost that the selected item has changed
            /// </summary>
            void ItemSelected(object selectedItem);
            #endregion

            #region LoadList()
            /// <summary>
            /// This method is used to Load the list of items
            /// </summary>
            List<object> LoadList();
            #endregion

            #region Save()
            /// <summary>
            /// This method is called when OnSave is called by the SaveCancelControl.
            /// </summary>
            bool Save();
            #endregion

        #endregion

    }
}
