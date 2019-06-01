

#region using statements

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

    #region class OrderByFieldControl
    /// <summary>
    /// This control is used to display a field and the field order for the Order by Control. 
    /// </summary>
    public partial class OrderByFieldControl : UserControl
    {
        
        #region Private Variables
        private bool selected;
        private string text;
        private int index;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'OrderByFieldControl' object.
        /// </summary>
        public OrderByFieldControl()
        {
            // Create controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region FieldNameLabel_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'FieldNameLabel' is clicked.
            /// </summary>
            private void FieldNameLabel_Click(object sender, EventArgs e)
            {
                // Set Selected
                this.Selected = !this.Selected;
            }
            #endregion
            
            #region MoveLeftButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'MoveLeftButton' is clicked.
            /// </summary>
            private void MoveLeftButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentOrderByControl is true
                if (HasParentOrderByControl)
                {
                    // Swap the Field
                    ParentOrderByControl.SwapFieldLeft(this.Index);
                }
            }
            #endregion
            
            #region MoveRightButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'MoveRightButton' is clicked.
            /// </summary>
            private void MoveRightButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentOrderByControl is true
                if (HasParentOrderByControl)
                {
                    // Swap the Field
                    ParentOrderByControl.SwapFieldRight(this.Index);
                }
            }
            #endregion
            
            #region MoveRightButton_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Move Right Button _ Mouse Enter
            /// </summary>
            private void MoveRightButton_MouseEnter(object sender, EventArgs e)
            {
                 // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region MoveRightButton_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Move Right Button _ Mouse Leave
            /// </summary>
            private void MoveRightButton_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region DisplaySelectedImage(bool selected)
            /// <summary>
            /// This method Display Selected Image
            /// </summary>
            public void DisplaySelectedImage(bool selected)
            {
                // if selected and in EditMode
                if ((selected) && (EditMode))
                {
                    // Set to yellow
                    this.MainPanel.BackgroundImage = Properties.Resources.MellowYellow;
                }
                else
                {
                    // Set to gray
                    this.MainPanel.BackgroundImage = Properties.Resources.JackIsADullBoyGray;
                }
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                // Display the background image
                DisplaySelectedImage(selected);
                
                // if the value for Selected is true
                if ((Selected) && (EditMode))
                {
                    switch (index)
                    {
                        case 0:

                            // Can't move left
                            MoveLeftButton.Visible = false;

                            // Can only move right if there are one or more fields present after this one
                            MoveRightButton.Visible = ((Index + 1) < FieldsCount);

                            // required
                            break;

                        case 1:

                            // Can move left
                            MoveLeftButton.Visible = true;

                            // Can only move right if there are one or more fields present after this one
                            MoveRightButton.Visible = ((Index + 1) < FieldsCount);

                            // required
                            break;

                        case 2:

                            // Can move left
                            MoveLeftButton.Visible = true;

                            // Can only move right if there are one or more fields present after this one
                            MoveRightButton.Visible = ((Index + 1) < FieldsCount);

                            // required
                            break;

                        case 3:

                             // Can move left
                            MoveLeftButton.Visible = true;

                            // Can only move right if there are one or more fields present after this one
                            MoveRightButton.Visible = false;

                            // required
                            break;
                    }
                }
                else
                {
                    // Hide both
                    MoveLeftButton.Visible = false;
                    MoveRightButton.Visible = false;
                }
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

                    // if the value for HasParentOrderByControl is true
                    if (HasParentOrderByControl)
                    {
                        // set the return value
                        editMode = ParentOrderByControl.EditMode;
                    }
                    
                    // return value
                    return editMode;
                }
            }
            #endregion

            #region FieldsCount
            /// <summary>
            /// This read only property returns the value for 'FieldsCount'.
            /// </summary>
            public int FieldsCount
            {
                get
                {
                    // initial value
                    int fieldsCount = 0;
                    
                    // if the value for HasParentOrderByControl is true
                    if (HasParentOrderByControl)
                    {
                        // set the return value
                        fieldsCount = ParentOrderByControl.FieldsCount;
                    }
                    
                    // return value
                    return fieldsCount;
                }
            }
            #endregion
            
            #region HasParentOrderByControl
            /// <summary>
            /// This property returns true if this object has a 'ParentOrderByControl'.
            /// </summary>
            public bool HasParentOrderByControl
            {
                get
                {
                    // initial value
                    bool hasParentOrderByControl = (this.ParentOrderByControl != null);
                    
                    // return value
                    return hasParentOrderByControl;
                }
            }
            #endregion
            
            #region Index
            /// <summary>
            /// This property gets or sets the value for 'Index'.
            /// </summary>
            public int Index
            {
                get { return index; }
                set 
                { 
                    // set the value
                    index = value;
                    
                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region ParentOrderByControl
            /// <summary>
            /// This read only property returns the value for 'ParentOrderByControl'.
            /// </summary>
            public OrderByControl ParentOrderByControl
            {
                get
                {
                    // initial value
                    OrderByControl orderByControl = this.Parent as OrderByControl;
                    
                    // return value
                    return orderByControl;
                }
            }
            #endregion
            
            #region Selected
            /// <summary>
            /// This property gets or sets the value for 'Selected'.
            /// </summary>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public bool Selected
            {
                get { return selected; }
                set 
                {
                    // set the value
                    selected = value;

                    // if the Parent exists
                    if (HasParentOrderByControl)
                    {
                        // Set the SelectedField
                        ParentOrderByControl.SelectedField = this;
                    }
                    
                    // Handle the UI
                    UIEnable();
                }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public new string Text
            {
                get { return text; }
                set 
                {
                    text = value; 
                    
                    // set the text of the label
                    FieldNameLabel.Text = value;
                }
            }
        #endregion

        #endregion
    }
    #endregion

}
