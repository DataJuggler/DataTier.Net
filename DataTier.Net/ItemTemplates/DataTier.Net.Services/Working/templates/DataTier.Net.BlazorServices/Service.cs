

#region using statements

using ApplicationLogicComponent.Connection;
using DataJuggler.UltimateHelper.Core;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace DataGateway.Services
{

    #region class [TableName]Service
    /// <summary>
    /// This is the Service class for managing [TableName] objects.
    /// </summary>
    public class [TableName]Service
    {

        #region Methods
            
            #region Get[TableName]List()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<[TableName]>> Get[TableName]List()
            {
                // initial value
                List<[TableName]> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.Load[PluralTableName]();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region Remove[TableName]([TableName] [VariableName])
            /// <summary>
            /// This method is used to delete a [TableName]
            /// </summary>
            /// <returns></returns>
            public static Task<bool> Remove[TableName]([TableName] [VariableName])
            {
                // initial value
                bool deleted = false;
                
                // if the [VariableName] object exists
                if (NullHelper.Exists([VariableName]))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.Delete[TableName]([VariableName].Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region Save[TableName](ref [TableName] [VariableName])
            /// <summary>
            /// This method is used to create [TableName] objects
            /// </summary>
            /// <param name="[VariableName]">Pass in an object of type [TableName] to save</param>
            /// <returns></returns>
            public static Task<bool> Save[TableName](ref [TableName] [VariableName])
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.Save[TableName](ref [VariableName]);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
