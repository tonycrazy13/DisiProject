using DisiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.AddModelError;

namespace DisiProject.Controllers
{
    public class ComunController : Controller
    {
        public DisiContext _db = new DisiContext();
        readonly Error _mensajes = new Error();
    }
}
