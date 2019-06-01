

#region using statements

using DataTierClient.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class ExcludeInfo
    /// <summary>
    /// This class is used to keep track of which tables and fields
    /// have had the value for Exclude change.
    /// </summary>
    public class ExcludeInfo
    {

        #region Private Variables
        private bool exclude;
        private ExcludeObjectTypeEnum objectType;
        private int tableId;
        private int fieldId;
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // initial value
                string info = "";
                
                // if Exclude
                if (Exclude)
                {
                    // set the return value
                    info = "Exclude: true ";
                }
                else
                {
                    // set the return value
                    info = "Exclude: false ";
                }

                // set the info
                info += " Table Id " + TableId.ToString();

                // if Field
                if (ObjectType == ExcludeObjectTypeEnum.Field)
                {
                    // set the info
                    info += " Field Id " + FieldId.ToString();
                }
                
                // return value
                return info;
            }
            #endregion

        #endregion

        #region Properties

        #region Exclude
        /// <summary>
        /// This property gets or sets the value for 'Exclude'.
        /// </summary>
        public bool Exclude
            {
                get { return exclude; }
                set { exclude = value; }
            }
            #endregion
            
            #region FieldId
            /// <summary>
            /// This property gets or sets the value for 'FieldId'.
            /// </summary>
            public int FieldId
            {
                get { return fieldId; }
                set { fieldId = value; }
            }
            #endregion
            
            #region HasFieldId
            /// <summary>
            /// This property returns true if the 'FieldId' is set.
            /// </summary>
            public bool HasFieldId
            {
                get
                {
                    // initial value
                    bool hasFieldId = (this.FieldId > 0);
                    
                    // return value
                    return hasFieldId;
                }
            }
            #endregion
            
            #region HasTableId
            /// <summary>
            /// This property returns true if the 'TableId' is set.
            /// </summary>
            public bool HasTableId
            {
                get
                {
                    // initial value
                    bool hasTableId = (this.TableId > 0);
                    
                    // return value
                    return hasTableId;
                }
            }
            #endregion
            
            #region ObjectType
            /// <summary>
            /// This property gets or sets the value for 'ObjectType'.
            /// </summary>
            public ExcludeObjectTypeEnum ObjectType
            {
                get { return objectType; }
                set { objectType = value; }
            }
            #endregion
            
            #region TableId
            /// <summary>
            /// This property gets or sets the value for 'TableId'.
            /// </summary>
            public int TableId
            {
                get { return tableId; }
                set { tableId = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
