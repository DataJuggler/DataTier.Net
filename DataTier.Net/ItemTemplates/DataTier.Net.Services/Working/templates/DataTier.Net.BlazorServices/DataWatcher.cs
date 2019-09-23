
#region using statements

using DataJuggler.Net.Core.Enumerations;
using DataJuggler.UltimateHelper.Core;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class [TableName]DataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// [TableName] item, the delegate is notified so the values are saved.
    /// </summary>
    public class [TableName]DataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                [TableName] [VariableName] = itemChanged as [TableName];

                // If the [VariableName] object exists
                if (NullHelper.Exists([VariableName]))
                {
                    // perform the saved
                    bool saved = await [TableName]Service.Save[TableName](ref [VariableName]);
                }
            }
            #endregion

            #region Watch(List<[TableName]> [VariableName])
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="[PluralVariableName]">The list of [TableName] objects to set a delegate on.</param>
            public void Watch(List<[TableName]> [PluralVariableName])
            {
                // If the [PluralVariableName] collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems([PluralVariableName]))
                {
                    // Iterate the collection of [TableName] objects
                    foreach ([TableName] [VariableName] in [PluralVariableName])
                    {
                        // Setup the Callback for each item
                       [VariableName].Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
