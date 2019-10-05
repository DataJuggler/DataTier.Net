

#region using statements

using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataGateway;
using DataJuggler.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class FieldSetHelper
    /// <summary>
    /// This class is used to load FieldSets to load the parameters
    /// </summary>
    public class FieldSetHelper
    {
        
        #region Methods
    
            #region FindField(List<DTNField> fields, int fieldId)
            /// <summary>
            /// This method returns the Field
            /// </summary>
            public static DTNField FindField(List<DTNField> fields, int fieldId)
            {
                // initial value
                DTNField field = null;

                // If the fields collection exists and has one or more items
                if ((ListHelper.HasOneOrMoreItems(fields)) && (fieldId > 0))
                {
                    // Iterate the collection of DTNField objects
                    foreach (DTNField tempField in fields)
                    {
                        // if this is the field being sought                        
                        if (tempField.FieldId == fieldId)
                        {
                            // set the return value                            
                            field = tempField;

                            // break;
                            break;
                        }
                    }
                }
                
                // return value
                return field;
            }
            #endregion

            #region FindFieldSetField(List<FieldSetField> fields, int fieldId)
            /// <summary>
            /// This method returns the Field
            /// </summary>
            public static FieldSetField FindFieldSetField(List<FieldSetField> fields, int fieldId)
            {
                // initial value
                FieldSetField field = null;

                // If the fields collection exists and has one or more items
                if ((ListHelper.HasOneOrMoreItems(fields)) && (fieldId > 0))
                {
                    // Iterate the collection of DTNField objects
                    foreach (FieldSetField tempField in fields)
                    {
                        // if this is the field being sought                        
                        if (tempField.FieldId == fieldId)
                        {
                            // set the return value                            
                            field = tempField;

                            // break;
                            break;
                        }
                    }
                }
                
                // return value
                return field;
            }
            #endregion
            
            #region GetParametersText(ref FieldSet fieldSet)
            /// <summary>
            /// This method returns the Parameters Text
            /// </summary>
            public static string GetParametersText(ref FieldSet fieldSet, List<Enumeration> enumerations)
            {
                // initial value
                string parametersText = "";

                // locals
                int count = 0;
                string parameterFieldDataType = "";
                string fieldParameter = "";

                // If the fieldSet object exists
                if (NullHelper.Exists(fieldSet))
                {
                    // load the fields for this fieldSet
                    fieldSet.Fields = FieldSetHelper.LoadFieldSetFields(fieldSet.FieldSetId);

                    // If the fields collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(fieldSet.Fields))
                    {
                        // Create a new instance of a 'StringBuilder' object.
                        StringBuilder sb = new StringBuilder();

                        // Iterate the collection of DTNField objects
                        foreach (DTNField field in fieldSet.Fields)
                        {
                            // Increment the value for count
                            count++;

                            // convert the DTN Field back to a DataField
                            DataField parameterField = DataConverter.ConvertDataField(field);

                            // If the value for the property field.IsEnumeration is true
                            if (field.DataType.ToString().ToLower() == "enumeration")
                            {
                                // set the dataType and fieldName
                                parameterFieldDataType = EnumerationHelper.GetEnumerationDataType(field.FieldName, enumerations);
                            }
                            else
                            {
                                // Convert the DataType
                                parameterFieldDataType = CSharpClassWriter.ConvertDataType(parameterField); 
                            }

                            // set the dataType and fieldName
                            fieldParameter = parameterFieldDataType + " " + CSharpClassWriter.CapitalizeFirstCharEx(field.FieldName, true);

                            // if this is after the firstItem
                            if (count > 1)
                            {
                                // append a comma and a space
                                sb.Append(", ");
                            }

                            // append the paremter
                            sb.Append(fieldParameter);
                        }
                        
                        // set the return value
                        parametersText = sb.ToString();
                    }
                }
                
                // return value
                return parametersText;
            }
            #endregion
            
            #region LoadFieldSetFields(int fieldSetId)
            /// <summary>
            /// This method returns a list of Field Set Fields View
            /// </summary>
            public static List<DTNField> LoadFieldSetFields(int fieldSetId)
            {
                // initial value
                List<DTNField> fields = null;

                // locals
                List<FieldSetFieldView> fieldSetFields = null;
                
                // If the value for fieldSetId is greater than zero
                if (fieldSetId > 0)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // find the fieldSet
                    FieldSet fieldSet = gateway.FindFieldSet(fieldSetId);

                    // If the fieldSet object exists
                    if (NullHelper.Exists(fieldSet))
                    {
                        // load the field set field view for this fieldSetId
                        fieldSetFields = gateway.LoadFieldSetFieldViewsByFieldSetId(fieldSetId);

                        // If the fieldSetFields collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(fieldSetFields))
                        {
                            // convert the fields to a view
                            fields = DataConverter.ConvertDataFields(fieldSetFields, fieldSet.DatabaseId, fieldSet.ProjectId, fieldSet.TableId);
                        }
                    }
                }
                
                // return value
                return fields;
            }
            #endregion            

            #region LoadFieldSetFields(List<FieldSetField> fieldSetFields, List<DTNField> fields)
            /// <summary>
            /// This method returns a list of Field Set Fields View
            /// </summary>
            public static List<DTNField> LoadFieldSetFields(List<FieldSetField> fieldSetFields, List<DTNField> fields)
            {
                // local
                DTNField field = null;

                // if there are one or more FieldSetFields
                if (ListHelper.HasOneOrMoreItems(fieldSetFields))
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // Iterate the collection of FieldSetField objects
                    foreach (FieldSetField fieldSetField in fieldSetFields)
                    {
                        // Attempt to find this field
                        field = FindField(fields, fieldSetField.FieldId);

                        // If the field object exists
                        if (NullHelper.IsNull(field))
                        {
                            // load the field
                            field = gateway.FindDTNField(fieldSetField.FieldId);                            
                        }

                        // If the field object exists
                        if (NullHelper.Exists(field, fields))
                        {
                            // set the fieldOrdinal
                            field.FieldOrdinal = fields.Count;

                            // add this field
                            fields.Add(field);
                        }

                        // sort by FieldOrdinal
                        fields = fields.OrderBy(x => x.FieldOrdinal).ToList();
                    }                    
                }
                
                // return value
                return fields;
            }
            #endregion            
            
        #endregion
        
    }
    #endregion

}
