using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.AddModelError;
using DisiProject.Models;

namespace DisiProject.Controllers
{
    public class PrivilegiosController : Controller
    {
        readonly Error _mensajes = new Error();
        //
        // GET: /Privilegios/

        public ActionResult Index()
        {
            ViewBag.idArea = new SelectList();

            return View();
        }

        //
        // POST: /Valida Permisos y Privilegios

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult creaPrivilegio(Privilegios model)
        {

            if (ModelState.IsValid)
            {

                try
                {
                   
                }
                catch (Exception e)
                {
                    ViewBag.Error = _mensajes.AlertaCorreo() + e.Message;
                }

            }

            ModelState.Clear();

            return View();

        }

    }
}
