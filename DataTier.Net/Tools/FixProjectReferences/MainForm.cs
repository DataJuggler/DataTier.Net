

#region using statements

using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using DataJuggler.UltimateHelper;

#endregion

namespace FixProjectReferences
{

    #region class MainForm
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region StartButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'StartButton' is clicked.
            /// </summary>
            private void StartButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(Connection.Name);

                // Load the projects
                List<Project> projects = gateway.LoadProjects();

                // If the projects collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(projects))
                {
                    // Iterate the collection of Project objects
                    foreach (Project project in projects)
                    {
                        // Load the referencesSets for this project
                        List<ReferencesSet> referencesSets = gateway.LoadReferencesSetsForProjectId(project.ProjectId);

                        // If the referencesSets collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(referencesSets))
                        {
                            // Iterate the collection of ReferencesSet objects
                            foreach (ReferencesSet referencesSet in referencesSets)
                            {
                                switch (referencesSet.ReferencesSetName)
                                {
                                    case "Controllers":
                                        project.ControllerReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    case "DataManager":
                                        project.DataManagerReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    case "DataOperations":
                                        project.DataOperationsReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    case "DataObjects":
                                        project.ObjectReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    case "Readers":
                                        project.ReaderReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    case "StoredProcedures":
                                        project.StoredProcedureReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    case "Writers":
                                        project.DataWriterReferencesSetId = referencesSet.ReferencesSetId;
                                        break;
                                    default:
                                        // Handle any unexpected cases here
                                        break;
                                }
                            }
                        }

                        // now clone the project
                        Project clone = project.Clone();

                        // now save the project
                        bool saved = gateway.SaveProject(ref clone);
                    }

                    // Show a message
                    MessageBox.Show("Finished", "Done");
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
        #endregion
        
        #region Properties
            
        #endregion
        
    }
    #endregion

}
