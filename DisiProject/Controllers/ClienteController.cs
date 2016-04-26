using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.Models;

namespace DisiProject.Controllers
{
    public class ClienteController : Controller
    {
        //private DisiContext db = new DisiContext();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        //
        // GET: /Cliente/Detalles/5

        public ActionResult Detalles(decimal id = 0)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Crear

        public ActionResult Crear()
        {
            return View();
        }

        //
        // POST: /Cliente/Crear

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);

                cliente.IdUsuario = WebSecurity.CurrentUserId;
                //cliente.UserUpdateID = WebSecurity.CurrentUserId;
                cliente.FecMod = DateTime.Now;
                cliente.FecAlta = DateTime.Now;
                if(validaContactosDirecciones(cliente))
                { 
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(cliente);
        }

        private bool validaContactosDirecciones(Cliente cliente)
        {
            var clientesContacto = = db.ClientesContacto.Include(cliente).Where(x => x.IdCliente == cliente.IdCliente, x => x.Estatus == 1);
            db.contactos.Include(c => c.Cliente).Where(x => x.ID == id);
            var contactos = db.Contactos.Include(clientesContacto.IdContacto).Where(x => x.IdContacto == clientesContacto.IdContacto, x => x.Estatus == 1);
            if(clientesContacto == null || contactos == null)
            {
                return false;
            }
            var direcciones = db.Direcciones.Include(contactos.IdContacto).Where(x => x.IdContacto == contactos.IdContacto, x => x.Estatus == 1);
            if(direcciones == null )
            {
                return false;
            }
            return true;
            //throw new NotImplementedException();
        }

        //
        // GET: /Cliente/Editar/5

        public ActionResult Editar(decimal id = 0)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Editar/5

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;

                cliente.IdUsuario = WebSecurity.CurrentUserId;
                cliente.FecMod = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Borrar/5

        public ActionResult Borrar(decimal id = 0)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Borrar/5

        [HttpPost, ActionName("Borrar")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Entry(cliente).State = EntityState.Modified;

            cliente.IdUsuario = WebSecurity.CurrentUserId;
            cliente.FecMod = DateTime.Now;
            cliente.Estatus = 0;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
