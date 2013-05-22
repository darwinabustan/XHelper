using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;


namespace XHelper
{
    class XSchemaValidator
    {
        private bool isValidXml = true;
        private string validationError = "";

        /// <SUMMARY>
        /// Empty Constructor.
        /// </SUMMARY>
        public XSchemaValidator()
        {
        }

        public bool XValidate(string xml, string schemaNamespace, string schemaUri)
        {
            // Create the XmlSchemaSet class.
            try
            {
                XmlSchemaSet sc = new XmlSchemaSet();

                // Add the schema to the collection.
                sc.Add(schemaNamespace, schemaUri);

                // Set the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = sc;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

                // Create the XmlReader object.
                StringReader sr = new StringReader(xml);
                XmlReader reader = XmlReader.Create(sr, settings);

                // Parse the file.  
                while (reader.Read()) ;

                //Clean Up
                settings.CloseInput = true;
                sr.Close();
                reader.Close();
                
                return true;
            }
            catch (Exception ex)
            {
                this.ValidationError = ex.Message;
                return false;
            }
        }

        /// <SUMMARY>
        /// Public get/set access to the validation error.
        /// </SUMMARY>
        public String ValidationError
        {
            get
            {
                return this.validationError;
            }
            set
            {
                this.validationError = value;
            }
        }

        /// <SUMMARY>
        /// Public get access to the isValidXml attribute.
        /// </SUMMARY>
        public bool IsValidXml
        {
            get
            {
                return this.isValidXml;
            }
        }

        /// <SUMMARY>
        /// This method is invoked when the XML does not match
        /// the XML Schema.
        /// </SUMMARY>
        /// <PARAM name="sender"></PARAM>
        /// <PARAM name="args"></PARAM>
        private void ValidationCallBack(object sender,ValidationEventArgs args)
        {
            // The xml does not match the schema.
            isValidXml = false;
            this.ValidationError = args.Message;
        }

    }

}
