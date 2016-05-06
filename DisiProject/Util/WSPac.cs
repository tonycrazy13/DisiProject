using System;
using DisiProject.FacturaDigitalWS;

namespace DisiProject.Util
{
    public class WSPac
    {
        public Tuple<string, string> Respuesta(string cadena)
        {
            try
            {
                string usuario = "demo123";
                string pass = "demo123";

                //hacemos la llamada al web service de factura digital de pruebas
                FacturaDigitalWebServicePortTypeClient fac =
                    new FacturaDigitalWebServicePortTypeClient();

                var respu = fac.generarCFDIPorTexto(usuario, pass, cadena);
                var codigo1 = respu.mensajeError;
                var codigo2 = respu.codigo;


                return Tuple.Create(codigo1, codigo2);

            }
            catch (Exception ex)
            {
                return Tuple.Create(ex.Message, "");
            }
        }
    }
}
