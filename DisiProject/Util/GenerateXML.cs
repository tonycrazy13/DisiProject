using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace DisiProject.Util
{
    public class GenerateXML
    {
        public void GenerarXml(string filename)
        {
            var doc = new XmlDocument();
            doc.Load(filename);
            var navigator = doc.CreateNavigator();
            if (navigator.NameTable != null)
            {
                var ns = new XmlNamespaceManager(navigator.NameTable);
                ns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                var aNodes = doc.SelectNodes("cfdi:Comprobante", ns);
                foreach (XmlNode aNode in aNodes)
                {
                    XmlAttribute idAttribute = aNode.Attributes["sello"];
                    if (idAttribute != null)
                    {
                        string currentValue = idAttribute.Value;
                        if (string.IsNullOrEmpty(currentValue))
                        {
                            // idAttribute.Value = Sello;
                        }
                    }

                }

                doc.Save(filename);
                var docfinal = new XmlDocument();
                docfinal.Load(filename);
                navigator = docfinal.CreateNavigator();
                if (navigator.NameTable != null)
                {
                    ns = new XmlNamespaceManager(navigator.NameTable);
                    ns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                    var aNodes2 = docfinal.SelectNodes("cfdi:Comprobante", ns);
                    foreach (XmlNode aNode in aNodes2)
                    {
                        var idAttribute = aNode.Attributes["noCertificado"];
                        if (idAttribute != null)
                        {
                            var currentValue = idAttribute.Value;
                            if (string.IsNullOrEmpty(currentValue))
                            {
                                // idAttribute.Value = noCertificado;
                            }
                        }

                    }
                    docfinal.Save(filename);
                    var docfinal2 = new XmlDocument();
                    docfinal2.Load(filename);
                    navigator = docfinal2.CreateNavigator();
                    if (navigator.NameTable != null) ns = new XmlNamespaceManager(navigator.NameTable);
                }

                ns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                var aNodes3 = docfinal.SelectNodes("cfdi:Comprobante", ns);
                foreach (XmlNode aNode in aNodes3)
                {
                    var idAttribute = aNode.Attributes["certificado"];
                    if (idAttribute != null)
                    {
                        string currentValue = idAttribute.Value;
                        if (string.IsNullOrEmpty(currentValue))
                        {
                            // idAttribute.Value = Certificado;
                        }
                    }
                }

                docfinal.Save(filename);
            }
        }
    }
}