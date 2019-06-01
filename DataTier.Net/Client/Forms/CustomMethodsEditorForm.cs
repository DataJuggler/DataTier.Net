

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Forms
{

    #region class CustomMethodsEditorForm
    /// <summary>
    /// This form is used to host the CustomMethods editor.
    /// </summary>
    public partial class CustomMethodsEditorForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomMethodsEditorForm' object.
        /// </summary>
        public CustomMethodsEditorForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods
            
            #region Setup(DTNTable selectedTable, List<Method> methods)
            /// <summary>
            /// method returns a list of
            /// </summary>
            public void Setup(DTNTable selectedTable, List<Method> methods)
            {
                // Setup the control
                this.CustomMethodsEditor.Setup(selectedTable, methods);
            }
        #endregion

        #endregion

        #region Properties

            #region ActionType
            /// <summary>
            /// This read only property returns the ActionType from the CustomMethodsEditor control. 
            /// </summary>
            public ActionTypeEnum ActionType
            {
                get
                {
                    // initial value
                    ActionTypeEnum actionType = ActionTypeEnum.NoAction;

                    // If the CustomMethodsEditor object exists
                    if (CustomMethodsEditor != null)
                    {
                        // set the return value
                        actionType = CustomMethodsEditor.ActionType;
                    }

                    // return value
                    return actionType;
                }
            }
            #endregion

            #region HasSelectedMethod
            /// <summary>
            /// This property returns true if this object has a 'SelectedMethod'.
            /// </summary>
            public bool HasSelectedMethod
            {
                get
                {
                    // initial value
                    bool hasSelectedMethod = (this.SelectedMethod != null);
                    
                    // return value
                    return hasSelectedMethod;
                }
            }
            #endregion
            
            #region IsActionRequired
            /// <summary>
            /// This property returns true if the ActionType is Add or Edit.
            /// </summary>
            public bool IsActionRequired
            {
                get
                {
                    // initial value
                    bool isActionRequired = ((ActionType == ActionTypeEnum.AddButtonClicked) || (ActionType == ActionTypeEnum.EditButtonClicked));
                    
                    // return value
                    return isActionRequired;
                }
            }
            #endregion
            
            #region SelectedMethod
            /// <summary>
            /// This read only property returns the value for 'SelectedMethod'.
            /// </summary>
            public Method SelectedMethod
            {
                get
                {
                    // initial value
                    Method selectedMethod = null;

                    // If the CustomMethodsEditor object exists
                    if (CustomMethodsEditor != null)
                    {
                        // set the return value
                        selectedMethod = CustomMethodsEditor.SelectedMethod;
                    }
                    
                    // return value
                    return selectedMethod;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
