using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using DisiProject.SHA1;


namespace DisiProject.Util
{
    public class CFDI
    {
        public static string GenerateFileName(string rfc, int doc, string dct)
        {
            var sFecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            var sAnio = sFecha.Substring(0, 4);
            var sMes = sFecha.Substring(4, 2);
            var sDia = sFecha.Substring(6, 2);
            var sHora = sFecha.Substring(8, 2);
            var sMinuto = sFecha.Substring(10, 2);
            var sSegundo = sFecha.Substring(12, 2);

            return string.Format("{0}-{1}-{8}-{2}-{3}-{4}-{5}-{6}-{7}", rfc, doc, sAnio, sMes, sDia, sHora, sMinuto, sSegundo, dct);
        }

        public static void SerializarXML(string sNombreArchivo, Comprobante pComprobante)
        {
            try
            {
                var filename = string.Format("{0}.xml", sNombreArchivo);

                var xmlNameSpace = new XmlSerializerNamespaces();

                xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
                xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                xmlNameSpace.Add("schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd");

                // Creas una instancia de XMLSerializer con el tipo de dato Comprobante
                var xmlSerialize = new XmlSerializer(typeof(Comprobante));
                // Creas una instancia de XmlTextWriter donde se va a guardar el resultado de la serialización
                var xmlTextWriter = new XmlTextWriter(filename, Encoding.UTF8)
                {
                    Formatting = Formatting.Indented
                };

                xmlSerialize.Serialize(xmlTextWriter, pComprobante, xmlNameSpace);
                xmlTextWriter.Close();
            }
            catch (Exception)
            {
                //throw new SerializeXMLTempFolderException(ex);
            }
        }

        public static Comprobante GenerarCertificado(Comprobante comprobante, string sNombreArchivo, string sPathXslt, string sPathCer, string keyPath, string password, string SerialNumber)
        {
            try
            {
                var filename = string.Format("{0}.xml", sNombreArchivo);

                var reader = new StreamReader(filename);
                var myXPathDoc = new XPathDocument(reader);
                var myXslTrans = new XslCompiledTransform();

                myXslTrans.Load(sPathXslt);

                var str = new StringWriter();
                var myWriter = new XmlTextWriter(str);
                myXslTrans.Transform(myXPathDoc, null, myWriter);
                var result = str.ToString();

                var resultado = new RSAXml().FirmaRSA(result, sPathCer, keyPath, password, SerialNumber);

                var sello = resultado.Item1;
                var noCertificado = resultado.Item4;
                var Certificado = resultado.Item2;


                comprobante.sello = sello;
                comprobante.noCertificado = noCertificado;
                comprobante.certificado = Certificado;

                return comprobante;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string GenerarCadena(string sNombreArchivo)
        {
            try
            {
                var filename = string.Format(sNombreArchivo);

                var reader = new StreamReader(filename);
                var myXPathDoc = new XPathDocument(reader);
                var myXslTrans = new XslCompiledTransform();

                myXslTrans.Load("http://www.sat.gob.mx/sitio_internet/cfd/3/cadenaoriginal_3_0/cadenaoriginal_3_2.xslt");

                var str = new StringWriter();
                var myWriter = new XmlTextWriter(str);
                myXslTrans.Transform(myXPathDoc, null, myWriter);
                var result = str.ToString();



                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}