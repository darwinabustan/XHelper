using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace XHelper
{
    public partial class XPathExpression : Form
    {
        public string XMLString;
        public XPathExpression()
        {
            InitializeComponent();
            XMLString = string.Empty;
            this.AcceptButton = this.buttonApply;
        }

        public XPathExpression(string xmlString)
        {
            InitializeComponent();
            XMLString = xmlString;
            this.AcceptButton = this.buttonApply;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            XPathNavigator nav;
            XPathDocument docNav; 
            XPathNodeIterator NodeIter;

            try
            {
                // Open the XML.
                MemoryStream m = new MemoryStream(System.Text.Encoding.Default.GetBytes(XMLString));
                docNav = new XPathDocument(m);

                // Create a navigator to query with XPath.
                nav = docNav.CreateNavigator();
                XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);

                string[] xPathExpression = textExpression.Text.Split(' ');

                for (int i = 1; i < xPathExpression.Length; i++)
                {
                    string[] nameSpace = xPathExpression[i].Split('=');
                    if (nameSpace.Length < 2)
                    {
                         manager.AddNamespace(String.Empty, nameSpace[0]);
                    }
                    else
                    {
                        manager.AddNamespace(nameSpace[0], nameSpace[1]);
                    }
                }

                NodeIter = nav.Select(xPathExpression[0], manager);
                
                textResult.Clear();
                while (NodeIter.MoveNext())
                {
                    textResult.Text += NodeIter.Current.OuterXml + Environment.NewLine;
                };
            }
            catch(Exception ex)
            {
                this.ShowError(ex);
            }

        }


        public void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
