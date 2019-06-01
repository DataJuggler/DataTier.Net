

#region using statements

using DataTierClient.Enumerations;
using DataTierClient.Objects;
using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class ChangeManager
    /// <summary>
    /// This class is used to quickly return a list of integers to represent the excluded tables and fields for a project.
    /// </summary>
    public class ChangeManager
    {
        
        #region Methods

            #region ChangesSet GetChangesSet(List<ExcludeInfo> originalValues, List<ExcludeInfo> currentValues)
            /// <summary>
            /// This method returns the Changes Set
            /// </summary>
            public static ChangesSet GetChangesSet(List<ExcludeInfo> originalValues, List<ExcludeInfo> currentValues)
            {
                // initial value
                ChangesSet changesSet = new ChangesSet();

                // if both lists of objects have items
                if (ListHelper.HasOneOrMoreItems(originalValues, currentValues))
                {
                    // Iterate the collection of ExcludeInfo objects
                    foreach (ExcludeInfo original in originalValues)
                    {
                        // find the current value of this type
                        ExcludeInfo current = currentValues.FirstOrDefault(x => x.TableId == original.TableId && x.ObjectType == original.ObjectType && x.FieldId == original.FieldId);

                        // If the current object exists and the values for Exclude are different
                        if ((NullHelper.Exists(current)) && (current.Exclude != original.Exclude))
                        {
                            // Add this change
                            changesSet.Changes.Add(current);
                        }
                    }
                }
                
                // return value
                return changesSet;
            }
            #endregion
            
            #region GetObjectValues(List<DTNTable> tables)
            /// <summary>
            /// method returns a list of integer values to represent the Exclude values
            /// </summary>
            public static List<ExcludeInfo> GetObjectValues(List<DTNTable> tables)
            {
                // initial value
                List<ExcludeInfo> values = new List<ExcludeInfo>();

                // local
                ExcludeInfo excludeInfo = null;
                
                // If the tables collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(tables))
                {
                    // Iterate the collection of DTNTable objects
                    foreach (DTNTable table in tables)
                    {  
                        // set the excludeInfo
                        excludeInfo = new ExcludeInfo();

                        // Set the value for Exclude
                        excludeInfo.Exclude = table.Exclude;

                        // Set the ObjectType
                        excludeInfo.ObjectType = ExcludeObjectTypeEnum.Table;

                        // Set the TableId
                        excludeInfo.TableId = table.TableId;

                        // Add this value
                        values.Add(excludeInfo);
                        
                        // if the Fields collection exists
                        if (table.HasFields)
                        {
                            // iterate the fields
                            foreach (DTNField field in table.Fields)
                            {  
                                 // set the excludeInfo
                                excludeInfo = new ExcludeInfo();

                                // Set the value for Exclude
                                excludeInfo.Exclude = field.Exclude;

                                // Set the ObjectType
                                excludeInfo.ObjectType = ExcludeObjectTypeEnum.Field;

                                // Set the FieldId
                                excludeInfo.TableId = table.TableId;
                                excludeInfo.FieldId = field.FieldId;

                                // Add this value
                                values.Add(excludeInfo);
                            }
                        }
                    }
                }
                
                // return value
                return values;
            }
            #endregion

            #region HasObjectChanged(List<bool> originalValues, List<bool> currentValues)
            /// <summary>
            /// This method compares two Lists of ExcludeInfo objects. If the number of items is different, or if 
            /// any of the values are different, then the object has changed. 
            /// </summary>
            /// <param name="originalValues"></param>
            /// <param name="currentValues"></param>
            /// <returns></returns>
            public static bool HasObjectChanged(List<ExcludeInfo> originalValues, List<ExcludeInfo> currentValues)
            {
                // initial value
                bool hasObjectChanged = false;

                // If both objects exist
                if (NullHelper.Exists(originalValues, currentValues))
                {
                    // if the counts are different
                    if (originalValues.Count != currentValues.Count)
                    {
                         // these objects are different
                        hasObjectChanged = true;
                    }
                    else
                    {
                        // iterate the items
                        for(int x = 0; x < originalValues.Count; x++)
                        {
                            // if the values are different
                            if (originalValues[x].Exclude != currentValues[x].Exclude)
                            {
                                // these objects are different
                                hasObjectChanged = true;

                                // break out of loop
                                break;
                            }
                        }
                    }
                }
                else if ((NullHelper.IsNull(originalValues)) && (NullHelper.Exists(currentValues)))
                {
                    // these objects are different
                    hasObjectChanged = true;
                }
                else if ((NullHelper.IsNull(currentValues)) && (NullHelper.Exists(originalValues)))
                {
                    // these objects are different
                    hasObjectChanged = true;
                }

                // return value
                return hasObjectChanged;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
