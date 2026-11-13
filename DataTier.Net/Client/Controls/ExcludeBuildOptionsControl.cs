

#region using statements

using System.Windows.Forms;
using DataJuggler.Win.Controls.Interfaces;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.DataGateway;
using DataAccessComponent.Connection;
using System.Drawing;
using DataJuggler.Win.Controls;

#endregion

namespace DataTierClient.Controls
{

    #region class ExcludeBuildOptionsControl
    /// <summary>
    /// This class is used to handle saving and managing BuildExcludes
    /// </summary>
    public partial class ExcludeBuildOptionsControl : UserControl, ISaveCancelHost, ICheckChangedListener
    {
        
        #region Private Variables
        private BuildExcludes buildExcludes;
        private DTNTable selectedTable;
        private bool userCancelled;
        private BuildExcludes initialValues;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ExcludeBuildOptionsControl' object.
        /// </summary>
        public ExcludeBuildOptionsControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // deteremine the action by the name of the checkbox
                switch (sender.Name)
                {
                    case "ExcludeDelete":

                        // set to the new value
                        this.BuildExcludes.ExcludeDelete = isChecked;

                        // required
                        break;

                    case "ExcludeFetchAll":

                        // set to the new value
                        this.BuildExcludes.ExcludeFetchAll = isChecked;

                        // required
                        break;

                    case "ExcludeFind":

                        // set to the new value
                        this.BuildExcludes.ExcludeFind = isChecked;

                        // required
                        break;

                    case "ExcludeInsert":

                        // set to the new value
                        this.BuildExcludes.ExcludeInsert = isChecked;

                        // required
                        break;

                    case "ExcludeUpdate":

                        // set to the new value
                        this.BuildExcludes.ExcludeUpdate = isChecked;

                        // required
                        break;
                }

                // Enable the save button if there are any changes
                UIEnable();
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region DisplayBuildExcludes()
            /// <summary>
            /// Display Build Excludes
            /// </summary>
            public void DisplayBuildExcludes()
            {
                // initial value
                bool excludeDelete = false;
                bool excludeFetchAll = false;
                bool excludeFind = false;
                bool excludeInsert = false;
                bool excludeUpdate = false;

                // if the value for HasBuildExcludes is true
                if (HasBuildExcludes)
                {
                    // copy the values from this object
                    excludeDelete = BuildExcludes.ExcludeDelete;
                    excludeFetchAll = BuildExcludes.ExcludeFetchAll;
                    excludeFind = BuildExcludes.ExcludeFind;
                    excludeInsert = BuildExcludes.ExcludeInsert;
                    excludeUpdate = BuildExcludes.ExcludeUpdate;
                }

                // now check the box
                this.ExcludeDelete.Checked = excludeDelete;
                this.ExcludeFetchAll.Checked = excludeFetchAll;
                this.ExcludeFind.Checked = excludeFind;
                this.ExcludeInsert.Checked = excludeInsert;
                this.ExcludeUpdate.Checked = excludeUpdate;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // default to true
                UserCancelled = true;

                // Set up the SaveCancelControl
                this.SaveCancelControl.CancelButtonTextAlign = ContentAlignment.MiddleCenter;
                this.SaveCancelControl.CancelButtonWidth = 96;
                this.SaveCancelControl.SaveAndcloseButtonTextAlign = ContentAlignment.MiddleCenter;
                this.SaveCancelControl.SaveAndCloseButtonWidth = 144;
                this.SaveCancelControl.ShowSaveAndCloseButton = true;

                // Setup the Listeners
                this.ExcludeDelete.CheckChangedListener = this;
                this.ExcludeFetchAll.CheckChangedListener = this;
                this.ExcludeFind.CheckChangedListener = this;
                this.ExcludeInsert.CheckChangedListener = this;
                this.ExcludeUpdate.CheckChangedListener = this;
            }
            #endregion
            
            #region OnCancel()
            /// <summary>
            /// method On Cancel
            /// </summary>
            public void OnCancel()
            {
                // set UserCancelled to False (should already be true)
                UserCancelled = true;

                // If the ParentForm object exists
                if (ParentForm != null)
                {
                    // close the parent form
                    ParentForm.Close();
                }
            }
            #endregion
            
            #region OnSave(bool close)
            /// <summary>
            /// method On Save
            /// </summary>
            public bool OnSave(bool close)
            {
                // initial value
                bool saved = false;

                // if the value for HasBuildExcludes is true
                if (HasBuildExcludes)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(ConnectionConstants.Name);

                    // if nothing is checked
                    if (BuildExcludes.NothingExcluded)
                    {
                        // if ScheduledForDelete is true
                        if (BuildExcludes.ScheduledForDelete)
                        {
                            // this means there were some excludes, now there aren't
                            bool deleted = gateway.DeleteBuildExcludes(BuildExcludes.Id);

                            // if it deleted, the user didn't cancel
                            UserCancelled = !deleted;
                        }
                    }
                    else
                    {
                        // Here we need to save
                        saved = gateway.SaveBuildExcludes(ref buildExcludes);

                        // if it saved, the user didn't cancel
                        UserCancelled = !saved;
                    }

                    // If the ParentForm object exists
                    if (ParentForm != null)
                    {
                        // close this form
                        ParentForm.Close();
                    }
                }

                // return value
                return saved;
            }
            #endregion
            
            #region Setup(DTNTable table)
            /// <summary>
            /// Setup
            /// </summary>
            public void Setup(DTNTable table)
            {
                // store the arg
                this.SelectedTable = table;

                // if the value for HasSelectedTable is true
                if (HasSelectedTable)
                {
                    // Display the Table Name
                    this.SelectedTableTextBox.Text = SelectedTable.TableName;

                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(ConnectionConstants.Name);

                    // check if there is a BuildExcludes entry for this table
                    this.BuildExcludes = gateway.FindBuildExcludesByTableId(SelectedTable.TableId);

                    // if the value for HasBuildExcludes is false
                    if (!HasBuildExcludes)
                    {
                        // create a new BuildExcludes
                        BuildExcludes = new BuildExcludes();

                        // Set the TableId
                        BuildExcludes.TableId = SelectedTable.TableId;

                        // Set the DatabaseId and ProjectId
                        BuildExcludes.DatabaseId = table.DatabaseId;
                        BuildExcludes.ProjectId = table.ProjectId;
                    }

                    // Get a copy
                    InitialValues = BuildExcludes.Clone();
                }
                else
                {
                    // close this form
                    this.ParentForm.Close();
                }

                // Check any boxes if we have any existing values
                DisplayBuildExcludes();
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// UI Enable
            /// </summary>
            public void UIEnable()
            {
                // HasObjectChanged
                SaveCancelControl.EnableSaveAndCloseButton = HasObjectChanged;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region BuildExcludes
            /// <summary>
            /// This property gets or sets the value for 'BuildExcludes'.
            /// </summary>
            public BuildExcludes BuildExcludes
            {
                get { return buildExcludes; }
                set { buildExcludes = value; }
            }
            #endregion
            
            #region HasBuildExcludes
            /// <summary>
            /// This property returns true if this object has a 'BuildExcludes'.
            /// </summary>
            public bool HasBuildExcludes
            {
                get
                {
                    // initial value
                    bool hasBuildExcludes = (BuildExcludes != null);

                    // return value
                    return hasBuildExcludes;
                }
            }
            #endregion
            
            #region HasInitialValues
            /// <summary>
            /// This property returns true if this object has an 'InitialValues'.
            /// </summary>
            public bool HasInitialValues
            {
                get
                {
                    // initial value
                    bool hasInitialValues = (InitialValues != null);

                    // return value
                    return hasInitialValues;
                }
            }
            #endregion
            
            #region HasObjectChanged
            /// <summary>
            /// This read only property returns true if any of the values are not equal to the inital values
            /// </summary>
            public bool HasObjectChanged
            {
                get
                {
                    // initial value
                    bool hasObjectChanged = false;

                    // if the value for HasBuildExcludes and HasInitialValues are both true
                    if ((HasBuildExcludes) && (HasInitialValues))
                    {
                        // if any of the exclude values do not match the initial values
                        if ((BuildExcludes.ExcludeDelete != InitialValues.ExcludeDelete) ||
                            (BuildExcludes.ExcludeFetchAll != InitialValues.ExcludeFetchAll) ||
                            (BuildExcludes.ExcludeFind != InitialValues.ExcludeFind) ||
                            (BuildExcludes.ExcludeInsert != InitialValues.ExcludeInsert) ||
                            (BuildExcludes.ExcludeUpdate != InitialValues.ExcludeUpdate))
                        {
                            // set the return value
                            hasObjectChanged = true;
                        }
                    }

                    // return value
                    return hasObjectChanged;
                }
            }
            #endregion

            #region HasSelectedTable
            /// <summary>
            /// This property returns true if this object has a 'SelectedTable'.
            /// </summary>
            public bool HasSelectedTable
            {
                get
                {
                    // initial value
                    bool hasSelectedTable = (SelectedTable != null);

                    // return value
                    return hasSelectedTable;
                }
            }
            #endregion
            
            #region InitialValues
            /// <summary>
            /// This property gets or sets the value for 'InitialValues'.
            /// </summary>
            public BuildExcludes InitialValues
            {
                get { return initialValues; }
                set { initialValues = value; }
            }
            #endregion
            
            #region SelectedTable
            /// <summary>
            /// This property gets or sets the value for 'SelectedTable'.
            /// </summary>
            public DTNTable SelectedTable
            {
                get { return selectedTable; }
                set { selectedTable = value; }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
