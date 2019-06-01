

#region using statements

using DataGateway;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Net;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTier.Net.Shared
{

    #region class FieldSetHelper
    /// <summary>
    /// This class is used to create the parameter strings for FieldSets.
    /// It needed to be in a common library because it is shared 
    /// between DataTier.Net.Client and the ProcedureWriter projects.
    /// </summary>
    public class FieldSetHelper
    {
        
        #region Methods

            #region GetParameterList(int fieldSetId)
            /// <summary>
            /// This method returns the Parameter List for the FieldSetId given
            /// </summary>
            public string GetParameterList(int fieldSetId)
            {
                // initial value
                string parameterList = "";

                // If the value for fieldSetId is greater than zero
                if (fieldSetId > 0)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    
                }
                
                // return value
                return parameterList;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
