
#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ObjectLibrary.BusinessObjects;
using ApplicationLogicComponent.ClientValidation;

#endregion

namespace ApplicationLogicComponent.Reflection
{

    #region class RADReflectionManager
    /// <summary>
    /// This class uses reflection for client validation,
    /// and stored procedure Parameter creation.
    /// </summary>
    public class ReflectionManager
    {

        #region ConvertObject(object sourceObject, object destinationObject)
        /// <summary>
        /// This method parses the sourceObject passed in and returns 
        /// the destination object with the values populated using
        /// reflection. The two objects passed in must be identical in
        /// the names of the properties and the number of properties
        /// or an error will occur. 
        /// </summary>
        /// <param name="sourceObject">The object to copy values from.</param>
        /// <param name="destinationObject">The object to paste values
        /// into and the object that will be returned.</param>
        /// <returns>The destination object with the values populated.</returns>
        public static object ConvertObject(object sourceObject, object destinationObject)
        {
            if ((sourceObject != null) && (destinationObject != null))
            {
                // Get the type of object sourceObject is.
                Type sourceType = sourceObject.GetType();

                // Get the type of object destinationObject is.
                Type destinationType = destinationObject.GetType();

                // Get Properties From Source Object
                PropertyInfo[] sourceProperties = sourceType.GetProperties();

                // Get Properties From Destination Object
                PropertyInfo[] destinationProperties = destinationType.GetProperties();

                // loop through each property
                foreach (PropertyInfo sourceInfoObject in sourceProperties)
                {
                    // get source property name
                    string sourcePropertyName = sourceInfoObject.Name;

                    // loop through each property in destination properties
                    // and find the matching property
                    foreach (PropertyInfo destinationInfoObject in destinationProperties)
                    {
                        // get destination property name
                        string destinationPropertyName = destinationInfoObject.Name;

                        // if this is the matching property
                        if (String.Compare(sourcePropertyName, destinationPropertyName) == 0)
                        {
                            // if this the matching property

                            // get source value
                            object sourceValue = destinationInfoObject.GetValue(sourceObject, null);

                            // set the value in destination object
                            destinationInfoObject.SetValue(sourceValue, destinationInfoObject, null);

                            // exit for loop
                            break;
                        }
                    }
                }
            }

            // Return Value
            return destinationObject;
        }
        #endregion

        #region GetPropertyAttributes
        /// <summary>
        /// This method returns the properties for an object instance
        /// with thier values.
        /// </summary>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        public static List<FieldValuePair> GetPropertyAttributes(object sourceObject)
        {
            // Initial Value
            List<FieldValuePair> properties = new List<FieldValuePair>();

            // Get the type of object sourceObject is.
            Type type = sourceObject.GetType();

            // Get a propretyInfo Array from sourceObject
            PropertyInfo[] propertyTypes = type.GetProperties();

            // loop through each property
            foreach (PropertyInfo infoObject in propertyTypes)
            {
                // get property name
                string propertyName = infoObject.Name;

                // If this is not a 'SystemProperty'.
                if (!SystemProperty(propertyName))
                {
                    // Get the value of this object
                    object propertyValue = infoObject.GetValue(sourceObject, null);

                    // Create new field value pair object
                    FieldValuePair property = new FieldValuePair(propertyName, propertyValue);

                    // Now add this property to properties collection.
                    properties.Add(property);
                }
            }

            // Return Value
            return properties;
        }
        #endregion

        #region SystemProperty(string propertyName)
        /// <summary>
        /// Determines if the propertyName passed in is a 
        /// property such as 'ErrorProcessor', 'InitialValues'
        /// or 'Validation'.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static bool SystemProperty(string propertyName)
        {
            // Initial Value
            bool systemProperty = false;

            // get a lowercase version of propertyName
            string property = propertyName.ToLower();

            // determine if the property is a 'SystemProperty'.
            switch (propertyName.ToLower())
            {
                case "errorprocessor":
                case "initialvalues":
                case "validation":

                    // this is a 'SystemProperty'.
                    systemProperty = true;
                    // required
                    break;
            }

            // Return Value      
            return systemProperty;
        }
        #endregion

        #region ParseDataType(string propertyName, object sourceObject)
        /// <summary>
        /// This method parses the sourceObject passed in and returns 
        /// the data type (FieldDataTypeEnum) for the property
        /// passed in.
        /// </summary>
        /// <param name="propertyName">Property to determine the data type of.</param>
        /// <param name="sourceObject">Object that this property is an attribute of.</param>
        /// <returns></returns>
        public static FieldDataTypeEnum ParseDataType(string propertyName, object sourceObject)
        {
            // Initial Value
            FieldDataTypeEnum tempDataType = FieldDataTypeEnum.NotSet;

            // Create Reflection Object
            Type mirror = sourceObject.GetType();

            // Verify FieldName exists
            if (!String.IsNullOrEmpty(propertyName))
            {
                // get property from this object.
                PropertyInfo property = mirror.GetProperty(propertyName);

                // verify property is not null.
                if (property != null)
                {
                    // Get Property Type From Object
                    string propertyType = property.PropertyType.ToString();

                    switch (propertyType)
                    {
                        case "System.String":

                            // Set DataType to string
                            tempDataType = FieldDataTypeEnum.String;

                            // required
                            break;
                    }
                }
            }

            // Return Value
            return tempDataType;
        }
        #endregion

    }
    #endregion

}
