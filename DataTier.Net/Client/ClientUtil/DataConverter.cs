

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class DataConverter
    /// <summary>
    /// This class is used to convert DataJuggler.Net.DataTable to an ObjectLibrary.BusinessObjects.DTNTable
    /// </summary>
    internal class DataConverter
    {
        
        #region Methods

            #region ConvertDataField(DTNField sourceField)
            /// <summary>
            /// This method converts a DTNField to a DataField.
            /// </summary>
            public static DataField ConvertDataField(DTNField sourceField)
            {
                // initial value
                DataField field = null;

                // If the sourceField object exists
                if (NullHelper.Exists(sourceField))
                {
                    // Create a new instance of a 'DTNField' object.
                    field = new DataField();

                    // Set each property
                    field.AccessMode = (DataManager.AccessMode) sourceField.AccessMode;
                    field.Caption = sourceField.Caption;
                    
                    // Both enums derive from int, so the double cast converts the Enum types
                    field.DataType = (DataManager.DataTypeEnum) sourceField.DataType;

                    field.DecimalPlaces = sourceField.DecimalPlaces;
                    field.DefaultValue = sourceField.DefaultValue;
                    field.FieldName = sourceField.FieldName;
                    field.FieldOrdinal = sourceField.FieldOrdinal;
                    field.Size = sourceField.FieldSize;
                    field.PrimaryKey = sourceField.PrimaryKey;
                    field.Required = sourceField.Required;
                    field.Scope = (DataManager.Scope) sourceField.Scope;
                    field.Exclude = sourceField.Exclude;
                }
                
                // return value
                return field;
            }
            #endregion

            #region ConvertDataField(FieldSetFieldView sourceField, int databaseId, int projectId, int tableId)
            /// <summary>
            /// This method converts a DataField to a DTNField.
            /// </summary>
            public static DTNField ConvertDataField(FieldSetFieldView sourceField, int databaseId, int projectId, int tableId)
            {
                // initial value
                DTNField field = null;

                // If the sourceField object exists
                if (NullHelper.Exists(sourceField))
                {
                    // Create a new instance of a 'DTNField' object.
                    field = new DTNField();

                    // Set each property
                    // field.AccessMode = (AccessModeEnum)((int) sourceField.AccessMode);
                    // field.Caption = sourceField.Caption;
                    field.DatabaseId = databaseId;

                    // Both enums derive from int, so the double cast converts the Enum types
                    field.DataType = (DataTypeEnum)((int) sourceField.DataType);

                    // set the properties
                    field.DecimalPlaces = sourceField.DecimalPlaces;
                    field.DefaultValue = sourceField.DefaultValue;
                    field.EnumDataTypeName = sourceField.EnumDataTypeName;
                    field.FieldName = sourceField.FieldName;
                    field.FieldOrdinal = sourceField.FieldOrdinal;
                    field.FieldSize = sourceField.FieldSize;
                    field.IsEnumeration = sourceField.IsEnumeration;
                    field.PrimaryKey = sourceField.PrimaryKey;
                    field.ProjectId = projectId;
                    field.Required = sourceField.Required;
                    field.Scope = (ScopeEnum) ((int) sourceField.Scope);
                    field.TableId = tableId;

                    // Update the FieldId
                    field.UpdateIdentity(sourceField.FieldId);
                }
                
                // return value
                return field;
            }
            #endregion

            #region ConvertDataField(DataField sourceField, int databaseId, int projectId, int tableId)
            /// <summary>
            /// This method converts a DataField to a DTNField.
            /// </summary>
            public static DTNField ConvertDataField(DataField sourceField, int databaseId, int projectId, int tableId)
            {
                // initial value
                DTNField field = null;

                // If the sourceField object exists
                if (NullHelper.Exists(sourceField))
                {
                    // Create a new instance of a 'DTNField' object.
                    field = new DTNField();

                    // Set each property
                    field.AccessMode = (AccessModeEnum)((int) sourceField.AccessMode);
                    field.Caption = sourceField.Caption;
                    field.DatabaseId = databaseId;

                    // Both enums derive from int, so the double cast converts the Enum types
                    field.DataType = (DataTypeEnum)((int) sourceField.DataType);

                    field.DecimalPlaces = sourceField.DecimalPlaces;
                    field.DefaultValue = sourceField.DefaultValue;
                    field.EnumDataTypeName = sourceField.EnumDataTypeName;
                    field.Exclude = sourceField.Exclude;
                    field.FieldName = sourceField.FieldName;
                    field.FieldOrdinal = sourceField.FieldOrdinal;
                    field.FieldSize = sourceField.Size;
                    field.IsEnumeration = sourceField.IsEnumeration;
                    field.PrimaryKey = sourceField.PrimaryKey;
                    field.ProjectId = projectId;
                    field.Required = sourceField.Required;
                    field.Scope = (ScopeEnum) ((int) sourceField.Scope);
                    field.TableId = tableId;

                    // Update 3.26.2019: Set the FieldId, so if set an update is performed
                    //                            and not a failed duplicate attempt.
                    field.UpdateIdentity(sourceField.FieldId);
                }
                
                // return value
                return field;
            }
            #endregion
            
            #region ConvertDataFields(List<DTNField> sourceFields)
            /// <summary>
            /// This method returns a list of Data Fields
            /// </summary>
            public static List<DataField> ConvertDataFields(List<DTNField> sourceFields)
            {
                // initial value
                List<DataField> fields = null;

                // If the sourceFields collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(sourceFields))
                {
                    // create the return value
                    fields = new List<DataField>();

                    // Iterate the collection of DataField objects
                    foreach (DTNField sourceField in sourceFields)
                    {
                        // Convert this field
                        DataField field = ConvertDataField(sourceField);

                        // Add this field
                        fields.Add(field);
                    }
                }
                
                // return value
                return fields;
            }
            #endregion

            #region ConvertDataFields(List<DataField> sourceFields, int databaseId, int projectId, int tableId)
            /// <summary>
            /// This method returns a list of Data Fields
            /// </summary>
            public static List<DTNField> ConvertDataFields(List<DataField> sourceFields, int databaseId, int projectId, int tableId)
            {
                // initial value
                List<DTNField> fields = null;

                // If the sourceFields collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(sourceFields))
                {
                    // create the return value
                    fields = new List<DTNField>();

                    // Iterate the collection of DataField objects
                    foreach (DataField dataField in sourceFields)
                    {  
                        // Convert this field
                        DTNField field = ConvertDataField(dataField, databaseId, projectId, tableId);

                        // Add this field
                        fields.Add(field);
                    }
                }
                
                // return value
                return fields;
            }
            #endregion

            #region ConvertDataFields(List<FieldSetFieldView> sourceFields, int databaseId, int projectId, int tableId)
            /// <summary>
            /// This method returns a list of Data Fields
            /// </summary>
            public static List<DTNField> ConvertDataFields(List<FieldSetFieldView> sourceFields, int databaseId, int projectId, int tableId)
            {
                // initial value
                List<DTNField> fields = null;

                // local
                DTNField field = null;

                // If the sourceFields collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(sourceFields))
                {
                    // create the return value
                    fields = new List<DTNField>();

                    // Iterate the collection of DataField objects
                    foreach (FieldSetFieldView fieldSetFieldView in sourceFields)
                    {
                        // Convert this field
                        field = ConvertDataField(fieldSetFieldView, databaseId, projectId, tableId);

                        // Add this field
                        fields.Add(field);
                    }
                }
                
                // return value
                return fields;
            }
            #endregion
            
            #region ConvertDataTable(DataTable sourceTable, Project project, DTNDatabase dtnDatabase)
            /// <summary>
            /// This method converts a Data Table to a DTNTable for storing some of the scheme info in SQL.
            /// </summary>
            public static DTNTable ConvertDataTable(DataTable sourceTable, Project project, DTNDatabase dtnDatabase)
            {
                // initial value
                DTNTable table = null;

                // if the sourceTable exists and there are one or more Databases for this project
                if ((NullHelper.Exists(sourceTable, project, dtnDatabase)) && (project.HasDatabases) && (ListHelper.HasOneOrMoreItems(project.Databases)))
                {
                    // Create a new instance of a 'DTNTable' object.
                    table = new DTNTable();

                    // Set any properties to store
                    table.ClassFileName = sourceTable.ClassFileName;
                    table.ClassName = sourceTable.ClassName;
                    table.Exclude = sourceTable.Exclude;
                    table.CreateBindingCallback = sourceTable.CreateBindingCallback;
                    
                    // Only 1 Database is officially supported now
                    table.DatabaseId = project.Databases[0].DatabaseId;

                    // Convert the Fields 
                    table.Fields = ConvertDataFields(sourceTable.Fields, table.DatabaseId, project.ProjectId, sourceTable.TableId);
                    table.IsView = sourceTable.IsView;
                    table.ProjectId = project.ProjectId;
                    table.Serializable = sourceTable.Serializable;
                    table.TableName = sourceTable.Name;

                    // Update 3.26.2019: The TableId does not actually exist on the DataTable.
                    // This will only be set when a project is reopened so that duplicate tables
                    // are not attempted to be inserted.
                    table.UpdateIdentity(sourceTable.TableId);
                }
                
                // return value
                return table;
            }
            #endregion

            #region ConvertDataTable(DTNTable sourceTable, Project project)
            /// <summary>
            /// This method converts a Data Table to a DTNTable for storing some of the scheme info in SQL.
            /// </summary>
            public static DataJuggler.Net.DataTable ConvertDataTable(DTNTable sourceTable, Project project)
            {
                // initial value
                DataJuggler.Net.DataTable table = null;

                // if the sourceTable exists 
                if (NullHelper.Exists(sourceTable))
                {
                    // Create a new instance of a 'DTNTable' object.
                    table = new DataJuggler.Net.DataTable();

                    // Set any properties to store
                    table.ClassFileName = sourceTable.ClassFileName;
                    table.ClassName = sourceTable.ClassName;
                    table.IsView = sourceTable.IsView;
                    
                    // Convert the Fields 
                    table.Fields = ConvertDataFields(sourceTable.Fields);
                    table.Serializable = sourceTable.Serializable;
                    table.Name = sourceTable.TableName;

                    // New field used with Blazor
                    if ((NullHelper.Exists(project)) && (project.EnableBlazorFeatures) && (project.BindingCallbackOption != BindingCallbackOptionEnum.No_Binding))
                    {
                        // if the Project has Create Binding, this implies all tables or if the sourceTable has CreatingBindingCallback set to true
                        if ((project.BindingCallbackOption == BindingCallbackOptionEnum.Create_Binding) || (sourceTable.CreateBindingCallback))
                        {
                            // set the value for CreateBindingCallback to true
                            table.CreateBindingCallback = true;    
                        }
                    }
                }
                
                // return value
                return table;
            }
            #endregion
            
            #region FindDatabaseByName(string name, List<DTNDatabase> projectDatabases)
            /// <summary>
            /// This method returns the Database By Name
            /// </summary>
            public static DTNDatabase FindDatabaseByName(string name, List<DTNDatabase> projectDatabases)
            {
                // initial value
                DTNDatabase database = null;

                // If the projectDatabases collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(projectDatabases))
                {
                    // Iterate the collection of Database objects
                    foreach (DTNDatabase tempDatabase in projectDatabases)
                    {
                        // if this is the name being sought
                        if (TextHelper.IsEqual(tempDatabase.DatabaseName, name))
                        {
                            // set the return value
                            database = tempDatabase;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return database;
            }
            #endregion
            
            #region FindDatabaseIdByName(string name, List<DTNDatabase> projectDatabases)
            /// <summary>
            /// This method returns the Database Id By Name
            /// </summary>
            public static int FindDatabaseIdByName(string name, List<DTNDatabase> projectDatabases)
            {
                // initial value
                int databaseId = 0;

                // attempt to find the database by name
                DTNDatabase database = FindDatabaseByName(name, projectDatabases);

                // If the database object exists
                if (NullHelper.Exists(database))
                {
                    // set the return value
                    databaseId = database.DatabaseId;
                }
                
                // return value
                return databaseId;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
