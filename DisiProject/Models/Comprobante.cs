using System.Collections.Generic;
using System.Xml.Serialization;

namespace DisiProject.Models
{
    public class Comprobante
    {

        [XmlIgnore]
        public TimbreFiscalDigital TimbreFiscalDigital { get; set; }

        [XmlIgnore]
        public string Rotulo { get; set; }

        [XmlIgnore]
        public double IEPS { get; set; }

        [XmlIgnore]
        public double IVA0 { get; set; }

        [XmlIgnore]
        public double IVA16 { get; set; }

        [XmlIgnore]
        public string FechaEntrega { get; set; }

        [XmlIgnore]
        public string FechaVencimiento { get; set; }

        [XmlIgnore]
        public string RotuloTotalLetra { get; set; }

        [XmlIgnore]
        public string OrdenVenta { get; set; }

        [XmlIgnore]
        public string OrdenCompra { get; set; }

        [XmlIgnore]
        public string NoCuenta { get; set; }

        [XmlIgnore]
        public string NombreE { get; set; }
        [XmlIgnore]
        public string CalleLE { get; set; }
        [XmlIgnore]
        public string CalleNoExteriorLE { get; set; }
        [XmlIgnore]
        public string CalleNoInteriorrLE { get; set; }
        [XmlIgnore]
        public string ColoniaLE { get; set; }
        [XmlIgnore]
        public string NoDireccionEntrega { get; set; }
        [XmlIgnore]
        public string MunicipioLE { get; set; }
        [XmlIgnore]
        public string EstadoLE { get; set; }
        [XmlIgnore]
        public string PaisLE { get; set; }
        [XmlIgnore]
        public string CodigoPostaLE { get; set; }
        [XmlIgnore]
        public string CiudadEntrega { get; set; }
        [XmlIgnore]
        public string RutaEntrega { get; set; }
        [XmlIgnore]
        public string TotalPiezas { get; set; }
        [XmlIgnore]
        public string TotalKilos { get; set; }
        [XmlIgnore]
        public string NombreTienda { get; set; }

        [XmlIgnore]
        public string Time { get; set; }

        [XmlIgnore]
        public string Anexo001 { get; set; }
        [XmlIgnore]
        public string Anexo002 { get; set; }
        [XmlIgnore]
        public string Anexo003 { get; set; }

        [XmlIgnore]
        public string TipoFolioDocumento { get; set; }
        [XmlIgnore]
        public string CondicionesVenta { get; set; }
        [XmlIgnore]
        public string InstruccionesEntrega { get; set; }
        [XmlIgnore]
        public string TotalCajas { get; set; }
        [XmlIgnore]
        public string OrdenCompraCliente { get; set; }
        [XmlIgnore]
        public string DocumentoEmbarque { get; set; }
        [XmlIgnore]
        public string ImporteImpuestos { get; set; }
        [XmlIgnore]
        public string RotuloHeader { get; set; }
        [XmlIgnore]
        public string CiudadExpedidoEn { get; set; }
    }

    public partial class ComprobanteConcepto
    {
        [XmlIgnore]
        public string Lote { get; set; }

        [XmlIgnore]
        public string LITM { get; set; }

        [XmlIgnore]
        public double LNID { get; set; }

        [XmlIgnore]
        public string Conversion { get; set; }

        [XmlIgnore]
        public IList<object> ItemsList { get; set; }

        [XmlIgnore]
        public string AnexoDetalle001 { get; set; }

        [XmlIgnore]
        public string AnexoDetalle002 { get; set; }

        [XmlIgnore]
        public string AnexoDetalle003 { get; set; }
    }

    public partial class ComprobanteEmisor
    {
        [XmlIgnore]
        public string Telf { get; set; }
    }

    public partial class t_UbicacionFiscal
    {
        [XmlIgnore]
        public string Ciudad { get; set; }
    }
    public partial class t_Ubicacion
    {
        [XmlIgnore]
        public string Ciudad { get; set; }
    }

    public partial class ComprobanteReceptor
    {
        [XmlIgnore]
        public string Ruta { get; set; }

        [XmlIgnore]
        public string NoCliente { get; set; }
    }
}
