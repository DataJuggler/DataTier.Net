

#region using statements

using System;
using System.Collections;

#endregion


namespace DataJuggler.Win.Controls.Objects
{

    #region class Item
    public partial class Item
    {

        #region Private Variables
        private bool defaultItem;
        private string displayName;
        private int itemID;
        private int itemSetID;
        private string itemValue;
        private bool delete;
        #endregion

        #region Methods

            #region Clone()
            public Item Clone()
            {
                // Create New Object
                Item NewItem = new Item();

                // Clone Each Property
                NewItem.defaultItem = this.DefaultItem;
                NewItem.displayName = this.DisplayName;
                NewItem.itemID = this.ItemID;
                NewItem.itemSetID = this.ItemSetID;
                NewItem.itemValue = this.ItemValue;

                // Return Cloned Object
                return NewItem;

            }
            #endregion

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the ID field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The ID field
                this.itemID = id;
            }
            #endregion

        #endregion

        #region Properties

            #region bool DefaultItem
            public bool DefaultItem
            {
                get
                {
                    return defaultItem;
                }
                set
                {
                    defaultItem = value;
                }
            }
            #endregion

            #region string DisplayName
            public string DisplayName
            {
                get
                {
                    return displayName;
                }
                set
                {
                    displayName = value;
                }
            }
            #endregion

            #region int ItemID
            public int ItemID
            {
                get
                {
                    return itemID;
                }
            }
            #endregion

            #region int ItemSetID
            public int ItemSetID
            {
                get
                {
                    return itemSetID;
                }
                set
                {
                    itemSetID = value;
                }
            }
            #endregion

            #region string ItemValue
            public string ItemValue
            {
                get
                {
                    return itemValue;
                }
                set
                {
                    itemValue = value;
                }
            }
            #endregion

            #region bool Delete
            public bool Delete
            {
                get
                {
                    return delete;
                }
                set
                {
                    delete = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.ItemID < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
