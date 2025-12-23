
#region using statements

using DataJuggler.Net;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSet
    [Serializable]
    public partial class FieldSet
    {

        #region Private Variables        
        private List<DTNField> fields;
        private List<DataField> dataFields;
        private List<FieldSetFieldView> fieldSetFields;
        private bool loadByTableId;
        #endregion

        #region Constructor
        public FieldSet()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods

            #region Clone()
            public FieldSet Clone()
            {
                // Create New Object
                FieldSet newFieldSet = (FieldSet) this.MemberwiseClone();

                // Return Cloned Object
                return newFieldSet;
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create the sub objects
                this.Fields = new List<DTNField>();
                this.FieldSetFields = new List<FieldSetFieldView>();
            }
            #endregion

            #region FindFieldSetFieldIndex()
            /// <summary>
            /// This method returns the Field Set Field Index
            /// </summary>
            public int FindFieldSetFieldIndex(int fieldId)
            {
                // initial value
                int fieldSetFieldIndex = -1;

                // if the Fields collection exists
                if (HasFieldSetFields)
                {
                    // iterate the fields
                    for (int x = 0; x < FieldSetFields.Count; x++)
                    {
                        // if this is the field being sought
                        if (FieldSetFields[x].FieldId == fieldId)
                        {
                            // set the return value
                            fieldSetFieldIndex = x;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return fieldSetFieldIndex;
            }
            #endregion
            
            #region FindFieldSetFieldView(int fieldId)
            /// <summary>
            /// This method returns the Field Set Field View
            /// </summary>
            public FieldSetFieldView FindFieldSetFieldView(int fieldId)
            {
                // initial value
                FieldSetFieldView fieldSetFieldView = null;

                // If the value for fieldId is greater than zero
                if ((fieldId > 0) && (HasFieldSetFields))
                {
                    // Iterate the collection of FieldSetFieldView objects
                    foreach (FieldSetFieldView field in FieldSetFields)
                    {
                        // if this is the field being sought
                        if (field.FieldId == fieldId)
                        {
                            // set the return value
                            fieldSetFieldView = field;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return fieldSetFieldView;
            }
            #endregion

            #region ToString()
            /// <summary>
            /// This method returns the Name of this object when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // initial value
                string toString = "";

                // If the Name text exists
                if (this.HasName)
                {
                    // Set the Name
                    toString = this.Name;
                }
                else
                {
                    // should only happen before saving a new object that hasn't had the name set
                    toString = "Field Set: Name unknown";
                }

                // return the name of this object
                return toString;
            }
            #endregion

        #endregion

        #region Properties

            #region DataFields
            /// <summary>
            /// This property gets or sets the value for 'DataFields'.
            /// </summary>
            public List<DataField> DataFields
            {
                get { return dataFields; }
                set { dataFields = value; }
            }
            #endregion
            
            #region Fields
            /// <summary>
            /// This property gets or sets the value for 'Fields'.
            /// </summary>
            public List<DTNField> Fields
            {
                get { return fields; }
                set { fields = value; }
            }
            #endregion
            
            #region FieldSetFields
            /// <summary>
            /// This property gets or sets the value for 'FieldSetFields'.
            /// </summary>
            public List<FieldSetFieldView> FieldSetFields
            {
                get { return fieldSetFields; }
                set { fieldSetFields = value; }
            }
            #endregion
            
            #region HasDataFields
            /// <summary>
            /// This property returns true if this object has a 'DataFields'.
            /// </summary>
            public bool HasDataFields
            {
                get
                {
                    // initial value
                    bool hasDataFields = (DataFields != null);

                    // return value
                    return hasDataFields;
                }
            }
            #endregion
            
            #region HasFields
            /// <summary>
            /// This property returns true if this object has a 'Fields'.
            /// </summary>
            public bool HasFields
            {
                get
                {
                    // initial value
                    bool hasFields = (Fields != null);

                    // return value
                    return hasFields;
                }
            }
            #endregion
            
            #region HasFieldSetFields
            /// <summary>
            /// This property returns true if this object has a 'FieldSetFields'.
            /// </summary>
            public bool HasFieldSetFields
            {
                get
                {
                    // initial value
                    bool hasFieldSetFields = (FieldSetFields != null);

                    // return value
                    return hasFieldSetFields;
                }
            }
            #endregion

            #region HasName
            /// <summary>
            /// This property returns true if the 'Name' exists.
            /// </summary>
            public bool HasName
            {
                get
                {
                    // initial value
                    bool hasName = (!String.IsNullOrEmpty(this.Name));
                    
                    // return value
                    return hasName;
                }
            }
            #endregion
            
            #region LoadByTableId
            /// <summary>
            /// This property gets or sets the value for 'LoadByTableId'.
            /// </summary>
            public bool LoadByTableId
            {
                get { return loadByTableId; }
                set { loadByTableId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}