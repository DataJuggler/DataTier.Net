

#region using statements

using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class OrderByControl
    /// <summary>
    /// This control is used to host the OrderByFieldControl. 
    /// </summary>
    public partial class OrderByControl : UserControl
    {
        
        #region Private Variables
        private OrderByFieldControl selectedField;
        private string hash;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'OrderByControl' object.
        /// </summary>
        public OrderByControl()
        {
            // Create controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Clear()
            /// <summary>
            /// This method Clear
            /// </summary>
            public void Clear()
            {
                // Clear each control
                FieldControl1.Text = "";
                FieldControl2.Text = "";
                FieldControl3.Text = "";
                FieldControl4.Text = "";
                FieldControl1.Visible = false;
                FieldControl2.Visible = false;
                FieldControl3.Visible = false;
                FieldControl4.Visible = false;

                // refresh everything
                this.Refresh();
            }
            #endregion
            
            #region DisplayFields()
            /// <summary>
            /// This method Display Fields
            /// </summary>
            public void DisplayFields()
            {
                // initial value
                int index = -1;

                // Get the Hash
                string tempHash = GetFieldsHash();

                // if tempHash does not match
                if (!TextHelper.IsEqual(tempHash, this.Hash))
                {
                    // set the value for Hash so this doesn't fire more than once for the same fieldSet unless the names change
                    this.Hash = tempHash;

                    // Clear all controls
                    Clear();

                    // if the value for HasFields is true
                    if ((HasFields) && (Fields.Count > 0))
                    {
                        // Iterate the collection of DTNField objects
                        foreach (DTNField field in Fields)
                        {
                            // Increment the value for index
                            index++;

                            // Set the FieldOrdinal
                            field.FieldOrdinal = index;

                            // Determine the action by the index
                            switch (index)
                            {
                                case 0:

                                    // Setup this control
                                    FieldControl1.Text = field.FieldName;
                                    FieldControl1.Visible = true;
                                    
                                    // required
                                    break;

                                case 1:

                                    // Setup this control
                                    FieldControl2.Text = field.FieldName;
                                    FieldControl2.Visible = true;
                                
                                    // required
                                    break;

                                case 2:

                                    // Setup this control
                                    FieldControl3.Text = field.FieldName;
                                    FieldControl3.Visible = true;

                                    // required
                                    break;

                                case 3:

                                    // Setup this control
                                    FieldControl4.Text = field.FieldName;
                                    FieldControl4.Visible = true;
                                
                                    // required
                                    break;

                            }
                        }
                    }
                }
            }
            #endregion
            
            #region FieldSelected(OrderByFieldControl selectededField)
            /// <summary>
            /// This method is used to set the SelectedField and
            /// deselect any previously selected fields.
            /// </summary>
            /// <param name="selectededField"></param>
            public void FieldSelected(OrderByFieldControl selectedField)
            {
                // if the selectedField exists
                if (NullHelper.Exists(selectedField))
                {
                    // if we have a previously selected field and it is a different field
                    if ((HasSelectedField) && (SelectedField.Index != selectedField.Index))
                    {
                        // unselect
                        this.selectedField.Selected = false;
                    }
                }

                // Set the SelectedField
                this.SelectedField = selectedField;    

                // if the SelectedField exists
                if (HasSelectedField)
                {
                    // select this field
                    selectedField.Selected = true;
                }
            }
            #endregion

            #region FieldSelected(OrderByFieldControl selectededField)
            /// <summary>
            /// This method is used to set the SelectedField and
            /// deselect any previously selected fields.
            /// </summary>
            /// <param name="index"></param>
            public void FieldSelected(int index)
            {
                // local
                OrderByFieldControl selectedControl = null;

                // Determine the action by the index
                switch (index)
                {
                    case 0:

                        // set the selectedControl
                        selectedControl = FieldControl1;

                       // required
                       break;

                    case 1:

                        // set the selectedControl
                        selectedControl = FieldControl2;

                       // required
                       break;

                    case 2:

                        // set the selectedControl
                        selectedControl = FieldControl3;

                       // required
                       break;

                    case 3:

                        // set the selectedControl
                        selectedControl = FieldControl4;

                       // required
                       break;
                }

                // Set the SelectedField
                this.SelectedField = selectedControl;    

                // if the value for HasSelectedField is true
                if (HasSelectedField)
                {
                    // select this field
                    SelectedField.Selected = true;
                }
            }
            #endregion

            #region FindFieldOrdinal(string fieldName)
            /// <summary>
            /// This method returns the Field Ordinal
            /// </summary>
            public int FindFieldOrdinal(string fieldName)
            {
                // initial value
                int fieldOrdinal = -1;

                // if the text matches field1
                if ((TextHelper.IsEqual(FieldControl1.Text, fieldName)) && (FieldControl1.Visible))
                {
                    // set the return value
                    fieldOrdinal = 0;
                }

                // if the text matches field1
                if ((TextHelper.IsEqual(FieldControl2.Text, fieldName)) && (FieldControl2.Visible))
                {
                    // set the return value
                    fieldOrdinal = 1;
                }

                // if the text matches field1
                if ((TextHelper.IsEqual(FieldControl3.Text, fieldName)) && (FieldControl3.Visible))
                {
                    // set the return value
                    fieldOrdinal = 2;
                }

                // if the text matches field1
                if ((TextHelper.IsEqual(FieldControl4.Text, fieldName)) && (FieldControl4.Visible))
                {
                    // set the return value
                    fieldOrdinal = 3;
                }
                
                // return value
                return fieldOrdinal;
            }
            #endregion
            
            #region GetFieldsHash()
            /// <summary>
            /// This method returns the Fields Hash
            /// </summary>
            public string GetFieldsHash()
            {
                // initial value
                string fieldsHash = "";

                // If the Fields collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(Fields))
                {
                    // Order by the FieldOrderinal
                    List<DTNField> sortedFields = Fields.OrderBy(x => x.FieldOrdinal).ToList();

                    // update the Fields
                    this.FieldSet.Fields = sortedFields;

                    // create a string builder
                    StringBuilder sb = new StringBuilder();

                    // Iterate the collection of DTNField objects
                    foreach (DTNField field in Fields)
                    {
                        // encrypt this FieldName and AddIt    
                        sb.Append(CryptographyHelper.EncryptString(field.FieldName));
                    }

                    // set the return value
                    fieldsHash = sb.ToString();
                }
                
                // return value
                return fieldsHash;
            }
            #endregion

            #region SwapFieldLeft(int index)
            /// <summary>
            /// method swaps the field at the given index to the right (increased)
            /// </summary>
            public bool SwapFieldLeft(int index)
            {
                // initial value
                bool swapped = false;
                
                // if the value for HasFields is true
                if ((HasFields) && (index < Fields.Count))
                {
                    // Decrement the value for FieldOrdinal
                    Fields[index].FieldOrdinal--;

                    // Swap the value for FieldOrdinal
                    Fields[index - 1].FieldOrdinal++;

                    // Display the Fields (which resorts)
                    DisplayFields();

                    // Reselect the field
                    FieldSelected(index - 1);

                    // if the value for HasParentFieldSetEditor is true
                    if (HasParentFieldSetEditor)
                    {
                        // Enable the Save button if there are changes, or disable it if no changes
                        ParentFieldSetEditor.UIEnable();
                    }

                    // Set to true
                    swapped = true;
                }
                
                // return value
                return swapped;
            }
            #endregion
            
            #region SwapFieldRight(int index)
            /// <summary>
            /// method swaps the field at the given index to the right (increased)
            /// </summary>
            public bool SwapFieldRight(int index)
            {
                // initial value
                bool swapped = false;
                
                // if the value for HasFields is true
                if ((HasFields) && ((index + 1) < Fields.Count))
                {
                    // Increment the value for FieldOrdinal
                    Fields[index].FieldOrdinal++;

                    // Swap the value for FieldOrdinal
                    Fields[index + 1].FieldOrdinal--;

                    // Display the Fields (which resorts)
                    DisplayFields();

                    // Reselect the field
                    FieldSelected(index + 1);

                    // if the value for HasParentFieldSetEditor is true
                    if (HasParentFieldSetEditor)
                    {
                        // Enable the Save button if there are changes, or disable it if no changes
                        ParentFieldSetEditor.UIEnable();
                    }

                    // Set to true
                    swapped = true;
                }
                
                // return value
                return swapped;
            }
            #endregion
            
        #endregion

        #region Properties

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

            #region EditMode
            /// <summary>
            /// This read only property returns the value for 'EditMode'.
            /// </summary>
            public bool EditMode
            {
                get
                {
                    // initial value
                    bool editMode = false;

                    // if the value for HasParentFieldSetEditor is true
                    if (HasParentFieldSetEditor)
                    {
                        // set the return value
                        editMode = ParentFieldSetEditor.IsInEditMode;
                    }
                    
                    // return value
                    return editMode;
                }
            }
            #endregion
            
            #region Fields
            /// <summary>
            /// This read only property returns the value for 'Fields'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public List<DTNField> Fields
            {
                get
                {
                    // initial value
                    List<DTNField> fields = null;
                    
                    // if the value for HasFieldSet is true
                    if (HasFieldSet)
                    {
                        // set the return value
                        fields = FieldSet.Fields;
                    }

                    // return value
                    return fields;
                }
            }
            #endregion

            #region FieldsCount
            /// <summary>
            /// This read only property returns the value for 'FieldsCount'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int FieldsCount
            {
                get
                {
                    // initial value
                    int fieldsCount = 0;
                    
                    // if the value for HasFields is true
                    if (HasFields)
                    {
                        // set the return value
                        fieldsCount = Fields.Count;
                    }

                    // return value
                    return fieldsCount;
                }
            }
            #endregion
            
            #region FieldSet
            /// <summary>
            /// This property gets or sets the value for 'FieldSet'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public FieldSet FieldSet
            {
                get 
                {
                    // initial value
                    FieldSet fieldSet = null;

                    // if the value for HasParentFieldSetEditor is true
                    if (HasParentFieldSetEditor)
                    {
                        // set the return value
                        fieldSet = ParentFieldSetEditor.SelectedFieldSet;
                    }

                    // return value
                    return fieldSet; 
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
                    bool hasFields = (this.Fields != null);
                    
                    // return value
                    return hasFields;
                }
            }
            #endregion
            
            #region HasFieldSet
            /// <summary>
            /// This property returns true if this object has a 'FieldSet'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool HasFieldSet
            {
                get
                {
                    // initial value
                    bool hasFieldSet = (this.FieldSet != null);
                    
                    // return value
                    return hasFieldSet;
                }
            }
            #endregion
            
            #region Hash
            /// <summary>
            /// This property gets or sets the value for 'Hash'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public string Hash
            {
                get { return hash; }
                set { hash = value; }
            }
            #endregion
            
            #region HasHash
            /// <summary>
            /// This property returns true if the 'Hash' exists.
            /// </summary>
            public bool HasHash
            {
                get
                {
                    // initial value
                    bool hasHash = (!String.IsNullOrEmpty(this.Hash));
                    
                    // return value
                    return hasHash;
                }
            }
            #endregion
            
            #region HasParentFieldSetEditor
            /// <summary>
            /// This property returns true if this object has a 'ParentFieldSetEditor'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool HasParentFieldSetEditor
            {
                get
                {
                    // initial value
                    bool hasParentFieldSetEditor = (this.ParentFieldSetEditor != null);
                    
                    // return value
                    return hasParentFieldSetEditor;
                }
            }
            #endregion
            
            #region HasSelectedField
            /// <summary>
            /// This property returns true if this object has a 'SelectedField'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool HasSelectedField
            {
                get
                {
                    // initial value
                    bool hasSelectedField = (this.SelectedField != null);
                    
                    // return value
                    return hasSelectedField;
                }
            }
            #endregion
            
            #region ParentFieldSetEditor
            /// <summary>
            /// This read only property returns the value for 'ParentFieldSetEditor'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public FieldSetEditor ParentFieldSetEditor
            {
                get
                {
                    // initial value
                    FieldSetEditor editor = this.Parent as FieldSetEditor;
                    
                    // return value
                    return editor;
                }
            }
            #endregion
            
            #region SelectedField
            /// <summary>
            /// This property gets or sets the value for 'SelectedField'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public OrderByFieldControl SelectedField
            {
                get { return selectedField; }
                set 
                { 
                    // if the value for HasSelectedField is true
                    if (HasSelectedField) 
                    {
                        // if the value does not exist or a different field was selected
                        if ((value == null) || (value.Index != SelectedField.Index))
                        {
                            // Not Selected
                            SelectedField.Selected = false;
                        }
                    }

                    // Set the Selected Field
                    selectedField = value;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
