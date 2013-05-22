using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.IO;

namespace XHelper
{
    class XSignature
    {
        public bool Check(string xmlData)
        {
            XmlDocument document = new XmlDocument();
            document.Load(new StringReader(xmlData));
            SignedXml xml = new SignedXml(document);
            XmlNodeList elementsByTagName = document.GetElementsByTagName("Signature", "*");
            xml.LoadXml((XmlElement)elementsByTagName[0]);
            return xml.CheckSignature();
        }
    }
}
