using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DisiProject.Datos;
using DisiProject.Util;

namespace DisiProject.Controllers.PortalClientes
{
    public class FacturasController : Controller
    {
        // readonly PruebaUsuarioDisiDataContext _db = new PruebaUsuarioDisiDataContext();
        readonly linq _validacion = new linq();
        readonly CFDI _cadena = new CFDI();
        readonly WSPac _respuesta = new WSPac();
        readonly LeerXml _uuid = new LeerXml();
        //
        // GET: /Facturas/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string fName = "";
            try
            {




                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase files = Request.Files[fileName];
                    //Save file content goes here
                    if (files != null)
                    {
                        fName = files.FileName;


                        if (files.ContentLength <= 0) continue;

                        if (file.FileName.EndsWith("pdf"))
                        {


                            //guardamos el archivo PDF
                            files.SaveAs(HttpContext.Server.MapPath("~/Content/PDF/") + Path.GetFileName(fName));
                            var rutaPdf = HttpContext.Server.MapPath("~/Content/PDF/") + Path.GetFileName(fName);


                            //consultamos si existe el registro por UUID

                            var aTexto = fName.Split('.');
                            var folio = aTexto[0];




                            //revisar condicion!!!
                            if (_validacion.ValidaPdf(folio))
                            {
                                System.IO.File.Delete(rutaPdf);
                                return Json(new { error = "El archivo " + fName + " ya  ha sido guardado anteriormente" });

                            }

                            //convertimos archivo en byte!! 
                            byte[] contenido = System.IO.File.ReadAllBytes(rutaPdf);

                            //insertamos
                            //_validacion.InsertPdf(contenido, folio);
                            System.IO.File.Delete(rutaPdf);



                        }
                        else
                        {

                            //guardamos archivo para lectura
                            files.SaveAs(HttpContext.Server.MapPath("~/Content/XML/") + Path.GetFileName(fName));
                            var rutaXml = HttpContext.Server.MapPath("~/Content/XML/") + Path.GetFileName(fName);

                            //cadena original de documento xml

                            //var res = _cadena.GenerarCadena(rutaXml);

                            ////consumo de WS para respuesta
                            //var codigos = _respuesta.Respuesta(res);
                            //var errorWsMsj = codigos.Item1;
                            //var errorWsCodigo = codigos.Item2;
                            var folio = _uuid.Xml(rutaXml);

                            //if (errorWsCodigo != "200") //si es exitosa la respuesta!!
                            //{
                            //    //Eliminamos si existe pdf asociado anteriormente
                            //    _validacion.EliminaPdf(folio);

                            //    //eliminar archivo 
                            //    System.IO.File.Delete(rutaXml);

                            //    //return mensaje
                            //    return Json(new { error = "Error al guardar el archivo " + fName + "   " + errorWsMsj });

                            //}


                            //consultamos si existe el registro por UUID
                            if (_validacion.ValidaXml(folio))
                            {
                                System.IO.File.Delete(rutaXml);
                                return Json(new { error = "El archivo " + fName + " ya  ha sido guardado anteriormente" });

                            }

                            byte[] contenido = System.IO.File.ReadAllBytes(rutaXml);

                            //insertamos
                           // _validacion.InsertXml(contenido, folio);
                            System.IO.File.Delete(rutaXml);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return Json(new { error = "Error al guardar el archivo " + fName + "   " + ex });
            }

            return Json(new { message = "El archivo " + fName + " a sido guardado correctamente" });
        }


        public ActionResult Estatus()
        {
            return View();
        }






    }
}
