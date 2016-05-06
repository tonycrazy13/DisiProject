using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace DisiProject.Util
{
    public class LeerXml
    {
        public string Xml(string filename)
        {
            // var directory = new DirectoryInfo(filename);
            string uuid = null;

            //var files = directory.GetFiles("*.xml");

            //foreach (var fileInfo in files)
            //{
            try
            {
                var doc = new XPathDocument(filename);
                var navigator = doc.CreateNavigator();
                var ns = new XmlNamespaceManager(navigator.NameTable);
                ns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");

                ns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                var nodes = navigator.Select("cfdi:Comprobante", ns);


                //var UUID = " ";
                //var FTTAX = " ";
                //var FTTAXS = " ";
                //var FTBRTPO = "GTO";
                //var FTTXR1 = "0";
                //var FTTXR2 = "0";
                //var FTTXR3 = "0";
                //var FTTXR4 = "0";
                //var FTTXR5 = "0";
                //var FTAFA1 = "0";
                //var FTAFA2 = "0";
                //var FTAFA3 = "0";
                //var FTAFA4 = "0";
                //var FTAFA5 = "0";
                //var FTCRCD = " ";
                //var FTCRR = "0";
                //var FTAMRT1 = "0";
                //var FTAMRT2 = "0";
                //var FTAMRT3 = "0";
                //var FTIVD = " ";
                //var FTAA10 = " ";
                //var FTAA20 = " ";
                //var FTDS20 = " ";
                //var FTDESC = " ";
                //var FTURAB = " ";
                //var FTURRF = " ";
                //var DCTO = string.Empty; //TIPODECOMPROBANTE
                //var DOCO = string.Empty; //FOLIO
                //var VR01 = string.Empty; //SERIE



                //string fecha = "";
                //DateTime? dFecha = null;
                //decimal nFecha = 0;
                //while (nodes.MoveNext())
                //{
                //    var node = nodes.Current;

                //    //fecha = node.GetAttribute("fecha", ns.DefaultNamespace).Trim();
                //    //fecha = fecha.Substring(0, 10);
                //    //dFecha = Convert.ToDateTime(fecha);
                //    //FTIVD = nFecha.ToString(CultureInfo.InvariantCulture);
                //    //FTURAB = node.GetAttribute("folio", ns.DefaultNamespace).Trim();
                //    //FTURRF = node.GetAttribute("serie", ns.DefaultNamespace).Trim();
                //}

                //nodes = navigator.Select("cfdi:Comprobante/cfdi:Receptor", ns);

                //while (nodes.MoveNext())
                //{
                //    var node = nodes.Current;

                //    // rfc = node.GetAttribute("rfc", ns.DefaultNamespace).Trim();
                //}

                nodes = navigator.Select("cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital", ns);

                while (nodes.MoveNext())
                {
                    var node = nodes.Current;

                    uuid = node.GetAttribute("UUID", ns.DefaultNamespace).Trim();
                }

                //nodes = navigator.Select("cfdi:Comprobante/cfdi:Emisor", ns);

                //while (nodes.MoveNext())
                //{
                //    var node = nodes.Current;

                //   // FTTAX = node.GetAttribute("rfc", ns.DefaultNamespace).Trim();
                //}


                //nodes = navigator.Select("cfdi:Comprobante/cfdi:Receptor", ns);

                //while (nodes.MoveNext())
                //{
                //    var node = nodes.Current;

                //    //FTTAXS = node.GetAttribute("rfc", ns.DefaultNamespace).Trim();
                //}

                //nodes = navigator.Select("cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", ns);

                //var index = 1;
                //while (nodes.MoveNext())
                //{
                //    var node = nodes.Current;

                //    if (index == 1)
                //    {
                //        //FTTXR1 =
                //        //    (decimal.Parse(node.GetAttribute("tasa", ns.DefaultNamespace).Trim()) * 1000).ToString
                //        //        ();
                //        //FTAFA1 =
                //        //    Math.Round(
                //        //        decimal.Parse(node.GetAttribute("importe", ns.DefaultNamespace).Trim()) * 10000, 4)
                //        //        .ToString();
                //    }
                //    if (index == 2)
                //    {
                //        //FTTXR2 =
                //        //    (decimal.Parse(node.GetAttribute("tasa", ns.DefaultNamespace).Trim()) * 1000).ToString
                //        //        ();
                //        //FTAFA2 =
                //        //    Math.Round(
                //        //        decimal.Parse(node.GetAttribute("importe", ns.DefaultNamespace).Trim()) * 10000, 4)
                //        //        .ToString();
                //    }
                //    if (index == 3)
                //    {
                //        //FTTXR3 =
                //        //    (decimal.Parse(node.GetAttribute("tasa", ns.DefaultNamespace).Trim()) * 1000).ToString
                //        //        ();
                //        //FTAFA3 =
                //        //    Math.Round(
                //        //        decimal.Parse(node.GetAttribute("importe", ns.DefaultNamespace).Trim()) * 10000, 4)
                //        //        .ToString(CultureInfo.InvariantCulture);
                //    }
                //    if (index == 4)
                //    {
                //        //FTTXR4 =
                //        //    (decimal.Parse(node.GetAttribute("tasa", ns.DefaultNamespace).Trim()) * 1000).ToString
                //        //        ();
                //        //FTAFA4 =
                //        //    Math.Round(
                //        //        decimal.Parse(node.GetAttribute("importe", ns.DefaultNamespace).Trim()) * 10000, 4)
                //        //        .ToString(CultureInfo.InvariantCulture);
                //    }
                //    if (index == 5)
                //    {
                //        //FTTXR5 =
                //        //    (decimal.Parse(node.GetAttribute("tasa", ns.DefaultNamespace).Trim()) * 1000).ToString
                //        //        ();
                //        //FTAFA5 =
                //        //    Math.Round(
                //        //        decimal.Parse(node.GetAttribute("importe", ns.DefaultNamespace).Trim()) * 10000, 4)
                //        //        .ToString(CultureInfo.InvariantCulture);
                //    }



                //    index++;
                //}

                //nodes = navigator.Select("cfdi:Comprobante", ns);


                //while (nodes.MoveNext())
                //{
                //    var node = nodes.Current;



                //    //FTCRCD = node.GetAttribute("Moneda", ns.DefaultNamespace).Trim();

                //    //switch (FTCRCD)
                //    //{
                //    //    case "pesos":
                //    //        FTCRCD = "MXN";
                //    //        break;
                //    //    case "Pesos":
                //    //        FTCRCD = "MXN";
                //    //        break;
                //    //    case "dolares":
                //    //        FTCRCD = "USD";
                //    //        break;
                //    //    case "Dolares":
                //    //        FTCRCD = "USD";
                //    //        break;
                //    //    case "euros":
                //    //        FTCRCD = "EUR";
                //    //        break;
                //    //    case "Euros":
                //    //        FTCRCD = "EUR";
                //    //        break;
                //    //}

                //    //if (FTCRCD.Length > 3)
                //    //{
                //    //    FTCRCD = FTCRCD.Substring(0, 3);
                //    //}

                //    //FTCRR = node.GetAttribute("TipoCambio", ns.DefaultNamespace).Trim();

                //    //if (FTCRR.Length == 0)
                //    //{
                //    //    FTCRR = "0";
                //    //}
                //    //FTAMRT1 =
                //    //    Math.Round(decimal.Parse(node.GetAttribute("total", ns.DefaultNamespace).Trim()) * 10000,
                //    //               4).ToString();
                //    //FTAMRT2 =
                //    //    Math.Round(
                //    //        decimal.Parse(node.GetAttribute("subTotal", ns.DefaultNamespace).Trim()) * 10000, 4)
                //    //        .ToString();
                //    //FTAMRT3 =
                //    //    Math.Round(decimal.Parse(node.GetAttribute("total", ns.DefaultNamespace).Trim()) * 10000,
                //    //               4).ToString();
                //}

                //nodes = navigator.Select("cfdi:Comprobante/cfdi:Addenda", ns);


                //while (nodes.MoveNext())
                //{
                //    //var node = nodes.Current;
                //    //nodes = node.Select("Probiomed");
                //    //var a = node.MoveToFirstChild();
                //    //FTDESC = node.GetAttribute("tipoDocumento", ns.DefaultNamespace).Trim();
                //    //FTDS20 = node.GetAttribute("sustituye", ns.DefaultNamespace).Trim();
                //    //FTAA10 = node.GetAttribute("tipoOc", ns.DefaultNamespace).Trim();
                //    //FTAA20 = node.GetAttribute("numeroOc", ns.DefaultNamespace).Trim();

                //}
            }
            catch (Exception )
            {
                // _logger.Error(string.Format("Se ha generado un Error al intentar Importar el fichero [{0}]{1}", fileInfo.FullName, ex.Message), ex);
            }
            //}

            return uuid;

        }
    }
}