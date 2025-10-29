


#region using statements

using DataJuggler.Core.UltimateHelper;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class GridColumn
    /// <summary>
    /// This class is used by the Grid to define columns
    /// </summary>
    public class GridColumn
    {
        
        #region Private Variables
        private string caption;        
        private int columnNumber;        
        private int height;
        private int index;        
        private bool readOnly;
        private int width;
        private bool lastColumn;
        private bool visible;
        private string format;
        private string parent;
        private string fontName;
        private int fontSize;
        private bool fontBold;
        private bool initialized;
        private DTNField field;
        #endregion

        #region Methods

            #region Initialize()
            /// <summary>
            /// Initialized
            /// </summary>
            public void Initialize(DTNField field, string fontName, int fontSize, int height, int width)
            {
                // store the args
                Field = field;
                FontName = fontName;
                FontSize = fontSize;
                Height = height;
                Width = width;

                // if the Field exists
                if (HasField)
                {
                    // Set Caption
                    Caption = Field.FieldName;
                }

                // This object has been initialized
                Initialized = true;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Caption
            /// <summary>
            /// This property gets or sets the value for 'Caption'.
            /// </summary>
            public string Caption
            {
                get { return caption; }
                set { caption = value; }
            }
            #endregion
            
            #region ClassName
            /// <summary>
            /// This read only property builds and returns the ClassName value
            /// based on the current settings of this GridColumn and its Field.
            /// </summary>
            public string ClassName
            {
                get
                {
                    // initial value
                    string className = "displayinlineblock textdonotwrap";

                    // if the Field exists
                    if (HasField)
                    {
                        // parse the width
                        int width = Field.GridColumn.Width;

                        // If the value for width is greater than zero
                        if (width > 0)
                        {
                            // add to className
                            className += " width" + width;
                        }

                        // parse the height
                        int height = Field.GridColumn.Height;

                        // If the value for height is greater than zero
                        if (height > 0)
                        {
                            // add to className
                            className += " height" + height;
                        }

                        // if the font name exists
                        if (TextHelper.Exists(Field.GridColumn.FontName))
                        {
                            // add to className
                            className += " font" + Field.GridColumn.FontName;
                        }

                        // parse the font size
                        int fontSize = Field.GridColumn.FontSize;

                        // If the value for fontSize is greater than zero
                        if (fontSize > 0)
                        {
                            // add to className
                            className += " font" + fontSize;
                        }

                        // if bold
                        if (Field.GridColumn.FontBold)
                        {
                            // add to className
                            className += " fontbold";
                        }
                    }

                    // return value
                    return className;
                }
            }
            #endregion
            
            #region ColumnNumber
            /// <summary>
            /// This property gets or sets the value for 'ColumnNumber'.
            /// </summary>
            public int ColumnNumber
            {
                get { return columnNumber; }
                set { columnNumber = value; }
            }
            #endregion
            
            #region DataType
            /// <summary>
            /// This read only property returns the value of DataType from the object Field.
            /// </summary>
            public string DataType
            {

                get
                {
                    // initial value
                    string dataType = "";

                    // if Field exists
                    if (HasField)
                    {
                        // set the return value
                        dataType = Field.DataType.ToString();
                    }

                    // return value
                    return dataType;
                }
            }
            #endregion

            #region Field
            /// <summary>
            /// This property gets or sets the value for 'Field'.
            /// </summary>
            public DTNField Field
            {
                get { return field; }
                set { field = value; }
            }
            #endregion
            
            #region FieldName
            /// <summary>
            /// This read only property returns the value of FieldName from the object Field.
            /// </summary>
            public string FieldName
            {

                get
                {
                    // initial value
                    string fieldName = "";

                    // if Field exists
                    if (HasField)
                    {
                        // set the return value
                        fieldName = Field.FieldName;
                    }

                    // return value
                    return fieldName;
                }
            }
            #endregion

            #region FontBold
            /// <summary>
            /// This property gets or sets the value for 'FontBold'.
            /// </summary>
            public bool FontBold
            {
                get { return fontBold; }
                set { fontBold = value; }
            }
            #endregion
            
            #region FontName
            /// <summary>
            /// This property gets or sets the value for 'FontName'.
            /// </summary>
            public string FontName
            {
                get { return fontName; }
                set { fontName = value; }
            }
            #endregion
            
            #region FontSize
            /// <summary>
            /// This property gets or sets the value for 'FontSize'.
            /// </summary>
            public int FontSize
            {
                get { return fontSize; }
                set { fontSize = value; }
            }
            #endregion
            
            #region Format
            /// <summary>
            /// This property gets or sets the value for 'Format'.
            /// </summary>
            public string Format
            {
                get { return format; }
                set { format = value; }
            }
            #endregion
            
            #region HasCaption
            /// <summary>
            /// This property returns true if the 'Caption' exists.
            /// </summary>
            public bool HasCaption
            {
                get
                {
                    // initial value
                    bool hasCaption = (!String.IsNullOrEmpty(this.Caption));
                    
                    // return value
                    return hasCaption;
                }
            }
            #endregion
            
            #region HasDataType
            /// <summary>
            /// This property returns true if the 'DataType' exists.
            /// </summary>
            public bool HasDataType
            {
                get
                {
                    // initial value
                    bool hasDataType = (!String.IsNullOrEmpty(this.DataType));
                    
                    // return value
                    return hasDataType;
                }
            }
            #endregion
            
            #region HasField
            /// <summary>
            /// This property returns true if this object has a 'Field'.
            /// </summary>
            public bool HasField
            {
                get
                {
                    // initial value
                    bool hasField = (Field != null);

                    // return value
                    return hasField;
                }
            }
            #endregion
            
            #region HasFieldName
            /// <summary>
            /// This property returns true if the 'FieldName' exists.
            /// </summary>
            public bool HasFieldName
            {
                get
                {
                    // initial value
                    bool hasFieldName = (!String.IsNullOrEmpty(this.FieldName));
                    
                    // return value
                    return hasFieldName;
                }
            }
            #endregion
            
            #region HasWidth
            /// <summary>
            /// This property returns true if the 'Width' is set.
            /// </summary>
            public bool HasWidth
            {
                get
                {
                    // initial value
                    bool hasWidth = (this.Width >= 16);
                    
                    // return value
                    return hasWidth;
                }
            }
            #endregion
            
            #region Height
            /// <summary>
            /// This property gets or sets the value for 'Height'.
            /// </summary>
            public int Height
            {
                get { return height; }
                set { height = value; }
            }
            #endregion
            
            #region Index
            /// <summary>
            /// This property gets or sets the value for 'Index'.
            /// </summary>
            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            #endregion
            
            #region Initialized
            /// <summary>
            /// This property gets or sets the value for 'Initialized'.
            /// </summary>
            public bool Initialized
            {
                get { return initialized; }
                set { initialized = value; }
            }
            #endregion
            
            #region LastColumn
            /// <summary>
            /// This property gets or sets the value for 'LastColumn'.
            /// </summary>
            public bool LastColumn
            {
                get { return lastColumn; }
                set { lastColumn = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            public string Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            #endregion
            
            #region ReadOnly
            /// <summary>
            /// This property gets or sets the value for 'ReadOnly'.
            /// </summary>
            public bool ReadOnly
            {
                get { return readOnly; }
                set { readOnly = value; }
            }
            #endregion
            
            #region Valid
            /// <summary>
            /// This read only property returns the value for 'Valid'.
            /// </summary>
            public bool Valid
            {
                get
                {
                    // initial value
                    bool valid = (HasCaption && HasDataType && HasFieldName && HasWidth);
                    
                    // return value
                    return valid;
                }
            }
            #endregion
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }
            #endregion
            
            #region Width
            /// <summary>
            /// This property gets or sets the value for 'Width'.
            /// </summary>
            public int Width
            {
                get { return width; }
                set { width = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}