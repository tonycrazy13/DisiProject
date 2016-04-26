using DisiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisiProject.Controllers
{
    [Authorize]
    public class UsuarioController : ComunController
    {

        public ActionResult MttoUsuario()
        {
            ViewBag.titulo = "Mantenimiento de Usuaios";

            List<Usuario> list =_db.Usuarios.ToList();
            return View(list);
        }

    }
}
