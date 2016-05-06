using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.AddModelError;

namespace DisiProject.Controllers.PortalClientes
{
    public class PortalClientesController : Controller
    {
        readonly Error _mensajes = new Error();
        //
        // GET: /PortalClientes/Index

        public ActionResult Index()
        {
            return View();
        }






        //
        // GET: /PortalClientes/Credito

        public ActionResult Credito()
        {
            return View();
        }



        //
        // GET: /PortalClientes/Pendientes

        public ActionResult Pendientes()
        {
            return View();
        }


        //
        // GET: /PortalClientes/Saldos

        public ActionResult Saldos()
        {
            return View();
        }


        //
        // GET: /PortalClientes/Reporte

        public ActionResult Reporte()
        {
            return View();
        }


        //
        // GET: /PortalClientes/Reporte

        public ActionResult FacturasDisi()
        {
            return View();
        }







    }
}
