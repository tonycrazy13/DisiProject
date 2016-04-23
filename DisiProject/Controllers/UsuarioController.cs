using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisiProject.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult MttoUsuario()
        {
            ViewBag.titulo = "Mantenimiento de Usuaios";
            ViewBag.titulo = "Mantenimiento de Usuaios 222"; 
            return View();
        }

    }
}
