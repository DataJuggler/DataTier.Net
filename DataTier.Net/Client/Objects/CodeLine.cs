

#region using statements

using DataJuggler.Core.UltimateHelper.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace DataTierClient.Objects
{

    #region class CodeLine
    /// <summary>
    /// This method represents one line of code.
    /// This is usually only 1 TextLine, but it can 
    /// be composed of multiple TextLines.
    /// </summary>
    public class CodeLine
    {
        
        #region Private Variables
        private bool multiLine;
        private TextLine textLine;
        private List<TextLine> textLines;
        private int indent;
        private Guid id;
        private string tag;
        #endregion
        
        #region Constructors
            
            #region Constructor
            /// <summary>
            /// Default Constructor
            /// </summary>
            public CodeLine()
            {
                // Create a new guid
                this.Id = Guid.NewGuid();
            } 
            #endregion
            
            #region Constructor
            /// <summary>
            /// Create a new CodeLine object and set the TextLine object.
            /// </summary>
            /// <param name="textLine"></param>
            public CodeLine(TextLine textLine)
            {
                // Set the property
                this.TextLine = textLine;

                // Create a new guid
                this.Id = Guid.NewGuid();
            } 
            #endregion
            
            #region Constructor
            /// <summary>
            /// Create a new CodeLine object and set the TextLine object.
            /// </summary>
            /// <param name="text"></param>
            public CodeLine(string text)
            {
                // Set the property
                this.TextLine = new TextLine(text);

                // Create a new guid
                this.Id = Guid.NewGuid();
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region ToString()
            /// <summary>
            /// This method is used to return the Text of this line
            /// when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // return the Text when ToString is called.
                return this.Text;
            } 
            #endregion
            
        #endregion
        
        #region Properties
            
            #region EndsWithSemiColon
            /// <summary>
            /// This read only property returns true if this line ends with a semicolon
            /// </summary>
            public bool EndsWithSemiColon
            {
                get
                {
                    // initial value
                    bool endsWithSemiColon = this.Text.EndsWith(";");
                    
                    // return value
                    return endsWithSemiColon;
                }
            } 
            #endregion
            
            #region FirstWord
            /// <summary>
            /// This read only property returns the first word
            /// </summary>
            public Word FirstWord
            {
                get
                {
                    // initial value
                    Word firstWord = null;
                    
                    if ((this.HasWords) && (this.Words.Count > 0))
                    {
                        // return the first word
                        firstWord = this.Words[0];
                    }
                    
                    // return value
                    return firstWord;
                }
            } 
            #endregion
            
            #region HasFirstWord
            /// <summary>
            /// Does the FirstWord property exist ?
            /// </summary>
            public bool HasFirstWord
            {
                get
                {
                    // initial value
                    bool hasFirstWord = (this.FirstWord != null);
                    
                    // return value
                    return hasFirstWord;
                }
            } 
            #endregion
            
            #region HasTag
            /// <summary>
            /// This property returns true if the 'Tag' exists.
            /// </summary>
            public bool HasTag
            {
                get
                {
                    // initial value
                    bool hasTag = (!String.IsNullOrEmpty(this.Tag));
                    
                    // return value
                    return hasTag;
                }
            }
            #endregion
            
            #region HasText
            /// <summary>
            /// This property returns true if the 'Text' exists.
            /// </summary>
            public bool HasText
            {
                get
                {
                    // initial value
                    bool hasText = (!String.IsNullOrEmpty(this.Text));
                    
                    // return value
                    return hasText;
                }
            }
            #endregion
            
            #region HasTextLine
            /// <summary>
            /// If this object has a TextLine
            /// </summary>
            public bool HasTextLine
            {
                get
                {
                    // initial value
                    bool hasTextLine = (this.TextLine != null);
                    
                    // return value
                    return hasTextLine;
                }
            } 
            #endregion
            
            #region HasWords
            /// <summary>
            /// This property returns true if this object has a Words collection.
            /// </summary>
            public bool HasWords
            {
                get
                {
                    // initial value
                    bool hasWords = (this.Words != null);
                    
                    // return value
                    return hasWords;
                }
            } 
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public Guid Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
            #region Indent
            /// <summary>
            /// This property gets or sets the value for the number of tabs
            /// this line should be indented in addition to its containing block.
            /// </summary>
            public int Indent
            {
                get { return indent; }
                set { indent = value; }
            } 
            #endregion

            #region IsBlankLine
            /// <summary>
            /// Is this line a blank line
            /// </summary>
            public bool IsBlankLine
            {
                get
                {
                    // initial value
                    bool isBlankLine = false;
                    
                    // trim the start of the line
                    string temp = this.Text.Trim();
                    
                    // set the return value
                    isBlankLine = String.IsNullOrEmpty(temp);
                    
                    // return value
                    return isBlankLine;
                }
            } 
            #endregion
            
            #region IsClassDeclarationLine
            /// <summary>
            /// This read only property returns true if a line contains the word class (For now this is the simple version).
            /// </summary>
            public bool IsClassDeclarationLine
            {
                get
                {
                    // initial value
                    bool isClass = false;
                    
                    // verify this is not a comment or a Region
                    if ((!this.IsComment) && (!this.IsRegion))
                    {
                        // if the TextLine.Words exists
                        if ((this.TextLine != null) && (this.TextLine.Words != null))
                        {
                            // itereate the words
                            foreach (Word word in textLine.Words)
                            {
                                // if this word contains the word class
                                if (word.Text == "class")
                                {
                                    // this is a class (for now)
                                    isClass = true;
                                    
                                    // break out of the loop
                                    break;
                                }
                            }
                        }
                    }
                    
                    // return value
                    return isClass;
                }
            }
            #endregion
            
            #region IsCloseBracket
            /// <summary>
            /// Is this line an CloseBracket ?
            /// </summary>
            public bool IsCloseBracket
            {
                get
                {
                    // initial value
                    bool isCloseBracket = false;
                    
                    // trim the start of the line
                    string temp = this.Text.Trim();
                    
                    // set the return value
                    isCloseBracket = (temp == "}");
                    
                    // return value
                    return isCloseBracket;
                }
            } 
            #endregion
            
            #region IsComment
            /// <summary>
            /// This read only property returns true if this line is a Comment.
            /// </summary>
            public bool IsComment
            {
                get
                {
                    // initial value
                    bool isComment = false;
                    
                    // verify the Text exists
                    if (!String.IsNullOrEmpty(this.Text))
                    {
                        // trim the start
                        string temp = this.Text.TrimStart();
                        
                        // set the return value
                        isComment = temp.StartsWith(@"//");
                    }
                    
                    // return value
                    return isComment;
                }
            } 
            #endregion

            #region IsCodeLine
            /// <summary>
            /// This read only property returns true if this line is not a Comment, Region or Tag;
            /// This does not mean it actually is a code line, but in a C# file this should be a code line.
            /// </summary>
            public bool IsCodeLine
            {
                get
                {
                    // initial value
                    bool isCodeLine = false;

                    // if this is not a Region
                    if ((!this.IsRegion) && (!this.IsComment) && (!this.IsTag))
                    {
                        // set to true
                        isCodeLine = true;
                    }

                    // return value
                    return isCodeLine;
                }
            } 
            #endregion
            
            #region IsDelegate
            /// <summary>
            /// This property returns true if this is a line is a Delegate Declaration Line.
            /// </summary>
            public bool IsDelegate
            {
                get
                {
                    // initial value
                    bool isDelegate = false;
                    
                    // If the Text exists and this is not a Region
                    if  ((!String.IsNullOrEmpty(this.Text)) && (!this.IsRegion))
                    {
                        // if this line is a delegate
                        if ((this.Text.Contains(" delegate ")) && (this.EndsWithSemiColon))
                        {
                            // set the return value to true
                            isDelegate = true;
                        }
                    }
                    
                    // return value
                    return isDelegate;
                }
            } 
            #endregion
            
            #region IsEmpty
            /// <summary>
            /// Is this a blank line ?
            /// </summary>
            public bool IsEmpty
            {
                get
                {
                    // initial value
                    bool isEmpty = false;
                    
                    // trim the line
                    string temp = this.Text.Trim();
                    
                    // if the string is empty
                    if (String.IsNullOrEmpty(temp))
                    {
                        // set the retur value to true
                        isEmpty = true;
                    }
                    
                    // return value
                    return isEmpty;
                }
            } 
            #endregion
            
            #region IsEndRegion
            /// <summary>
            /// Is this line an EndRegion line '#endregion'
            /// </summary>
            public bool IsEndRegion
            {
                get
                {
                    // initial value
                    bool isEndRegion = false;

                    // local
                    string temp = "";
                    
                    // if this object has text
                    if (this.HasText)
                    {
                        // trim the text
                        temp = this.Text.Trim();

                        // set the return value
                        isEndRegion = temp.StartsWith("#endregion");
                    }
                    
                    // return value
                    return isEndRegion;
                }
            } 
            #endregion
            
            #region IsEvent
            /// <summary>
            /// This read only property returns true if this line is an Event.
            /// </summary>
            public bool IsEvent
            {
                get
                {
                    // initial value
                    bool isEvent = false;
                    
                    // if this contains an underscore
                    if (this.Text.Contains("_"))
                    {
                        // this is an event
                        isEvent = true;    
                    }
                    else if (this.Text.Contains("object sender"))
                    {
                        // this is an event
                        isEvent = true;    
                    }
                    else if (this.Text.Contains("event"))
                    {
                        // this is an event
                        isEvent = true;    
                    }
                    else if (this.Text.Contains("Event"))
                    {
                        // this is an event
                        isEvent = true;    
                    }
                    else if (this.Text.Contains("Changed"))
                    {
                        // this is an event
                        isEvent = true;    
                    }
                    else if (this.Text.Contains("Clicked"))
                    {
                        // this is an event
                        isEvent = true;    
                    }
                    
                    // return value
                    return isEvent;
                }
            } 
            #endregion
            
            #region IsMethod
            /// <summary>
            /// This Property returns true if this is potentially a Method.
            /// </summary>
            public bool IsMethod 
            { 
                get
                {
                    // initial value
                    bool isMethod = false;
                    
                    // get the indexes of the paren's
                    int index = this.Text.IndexOf("(");
                    int index2 = this.Text.IndexOf(")");

                    // if this line has an open and close paren (this does not guaruntee a method, but it is a start)
                    if ((this.IsCodeLine) && (index > 0) && (index2 > 0))
                    {
                        // true eneough
                        isMethod = true;
                    }

                    // return value
                    return isMethod;
                }
            }
            #endregion
            
            #region IsNamespace
            /// <summary>
            /// Is this CodeLine a Namespace declaration line ?
            /// </summary>
            public bool IsNamespace
            {
                get
                {
                    // initial value
                    bool isNamespace = false;
                    
                    // if the TextLine.Words exists
                    if ((this.TextLine != null) && (this.TextLine.Words != null))
                    {
                        // if there are exactly two words
                        if (this.TextLine.Words.Count == 2)
                        {
                            // if the first word is namespace
                            if (this.TextLine.Words[0].Text == "namespace")
                            {
                                // this is a namespace
                                isNamespace = true;
                            }
                        }
                    }
                    
                    // return value
                    return isNamespace;
                }
            } 
            #endregion
            
            #region IsOpenBracket
            /// <summary>
            /// Is this line an OpenBracket ?
            /// </summary>
            public bool IsOpenBracket
            {
                get
                {
                    // initial value
                    bool isOpenBracket = false;
                    
                    // trim the start of the line
                    string temp = this.Text.Trim();
                    
                    // set the return value
                    isOpenBracket = (temp == "{");
                    
                    // return value
                    return isOpenBracket;
                }
            }
            #endregion
            
            #region IsPrivateVariable
            /// <summary>
            /// Is this a Private Varible line ?
            /// </summary>
            public bool IsPrivateVariable
            {
                get
                {
                    // initial value
                    bool isPrivateVariable = false;
                    
                    // get the start of the line
                    string temp = this.Text.TrimStart();
                    
                    // if the text Starts with private and and ends with ;
                    if  ((temp.StartsWith("private ") && (this.EndsWithSemiColon)))
                    {
                        // this is a private variable line
                        isPrivateVariable  = true;
                    }
                    
                    // return value
                    return isPrivateVariable;
                }
            } 
            #endregion
            
            #region IsRegion
            /// <summary>
            /// This this object a Region line ?
            /// </summary>
            public bool IsRegion
            {
                get
                {
                    // initial value
                    bool isRegion = false;
                    
                    // if this is not a comment
                    if (!this.IsComment)
                    {
                        // if this object has text
                        if (this.HasText)
                        {
                            // trim the text
                            string temp = this.Text.Trim();

                            // set the return value
                            isRegion = temp.StartsWith("#region");
                        }
                    }
                    
                    // return value
                    return isRegion;
                }
            } 
            #endregion
            
            #region IsTag
            /// <summary>
            /// This read only property returns true if this line is a Tag
            /// </summary>
            public bool IsTag
            {
                get
                {
                    // initial value
                    bool isTag = false;
                    
                    // local
                    string temp = this.Text.Trim();
                    
                    // if this string exists
                    if (!String.IsNullOrEmpty(temp))
                    {
                        // is this a tag
                        isTag = ((temp.StartsWith("[")) && (temp.EndsWith("]")));
                    }
                    
                    // return value
                    return isTag;
                }
            } 
            #endregion
            
            #region IsUsingStatement
            /// <summary>
            /// This read only property returns true if this line is a using statement
            /// </summary>
            public bool IsUsingStatement
            {
                get
                {
                    // initial value
                    bool isUsingStatement = false;
                    
                    // if the Text exists
                    if ((!String.IsNullOrEmpty(this.Text)) && (this.HasTextLine) && (this.TextLine.Words != null) && (this.TextLine.Words.Count > 0))
                    {
                        // get the first word (yes it is possible for a using statement to not be the first word, but that is 
                        // for version 1.1, Keep It Simple For Now
                        Word word = this.TextLine.Words[0];
                        
                        // if the first word.Text = "using"
                        if (word.Text == "using")
                        {
                            // this is a using statement if this line Ends with a Semicolon (for now)
                            if (this.EndsWithSemiColon)
                            {
                                // set the return value to true (exceptions will be fixed later)
                                isUsingStatement = true;
                            }
                        }
                    }
                    
                    // return value
                    return isUsingStatement;
                }
            } 
            #endregion
            
            #region LineNumber
            /// <summary>
            /// Return the LineNumber from the TexLine
            /// </summary>
            public int LineNumber
            {
                get
                {
                    // initial value
                    int lineNumber = 0;
                    
                    // if this object has a TextLine
                    if (this.HasTextLine)
                    {   
                        // set the return value
                        lineNumber = this.TextLine.LineNumber;
                    }
                    
                    // return value
                    return lineNumber;
                } 
            }
            #endregion
            
            #region MultiLine
            /// <summary>
            /// This property gets or sets the value for MultiLine
            /// </summary>
            public bool MultiLine
            {
                get { return multiLine; }
                set { multiLine = value; }
            } 
            #endregion

            #region RegionName
            /// <summary>
            /// This read only property returns the RegionName for this line.
            /// This must be a Region or this will return an empty string
            /// </summary>
            public string RegionName
            {
                get
                {
                    // initial value
                    string regionName = "";

                    // local
                    int startIndex = -1;

                    try
                    {
                        // if this is a region
                        if ((this.HasText) && (this.IsRegion))
                        {
                            // get the index of the region
                            startIndex = this.Text.ToLower().IndexOf("#region") + 7;

                            // if the startIndex was found
                            if (startIndex >= 7)
                            {
                                // see if there is an open paren
                                int endIndex = this.Text.IndexOf("(", startIndex);

                                // if the endIndex was found
                                if (endIndex > 0)
                                {
                                    // set the length
                                    int len = endIndex - startIndex;

                                    // set the regionName
                                    regionName = this.Text.Substring(startIndex, len).Trim();
                                }
                                else
                                {
                                    // set the regionName
                                    regionName = this.Text.Substring(startIndex + 1).Trim();
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only for now
                        string err = error.ToString();
                    }

                    // return value
                    return regionName;
                }
            }
            #endregion
            
            #region Tag
            /// <summary>
            /// This property gets or sets the value for 'Tag'.
            /// </summary>
            public string Tag
            {
                get { return tag; }
                set { tag = value; }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the Text for this CodeLine.
            /// </summary>
            public string Text
            {
                get
                {
                    // initial value
                    string text = "";
                    
                    // if the text line exists
                    if (this.HasTextLine)
                    {
                        // set the value
                        text = this.TextLine.Text;
                    }
                    
                    // return value
                    return text;
                }
                set
                {
                    // if the text line exists
                    if (this.HasTextLine)
                    {
                        // set the value
                        this.TextLine.Text = value;
                    }
                }
            } 
            #endregion
            
            #region TextLine
            /// <summary>
            /// This property gets or sets the value for TextLine
            /// </summary>
            public TextLine TextLine
            {
                get { return textLine; }
                set { textLine = value; }
            } 
            #endregion
            
            #region TextLines
            /// <summary>
            /// This property gets or sets the value for TextLines
            /// </summary>
            public List<TextLine> TextLines
            {
                get { return textLines; }
                set { textLines = value; }
            } 
            #endregion
            
            #region Words
            /// <summary>
            /// The Words for this CodeLine
            /// </summary>
            public List<Word> Words
            {
                get
                {
                    // initial value
                    List<Word> words = null;
                    
                    // if the TextLine exists
                    if (this.HasTextLine)
                    {
                        // set the return value
                        words = this.TextLine.Words;
                    }
                    
                    // return value
                    return words;
                }
            } 
            #endregion
            
        #endregion
        
    }
    #endregion

}
