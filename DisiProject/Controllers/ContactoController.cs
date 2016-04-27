using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.Models;

namespace DisiProject.Controllers
{
    public class ContactoController : Controller
    {
        //private DisiContext db = new DisiContext();
        //
        // GET: /Contacto/

        public ActionResult Index(Decimal id)
        {
            //veificar como sacar los contactos nada mas de la relacion cliente/contacto
            var contactos = db.contactos.Include(c => c.Cliente).Where(x => x.ID == id);

            ViewBag.Cliente = db.Clientes.Find(id);

            return View(contactos.ToList());
        }
        //
        // GET: /Contactos/Detalles/

        public ActionResult Details(Decimal id = 0)
        {
            Contacto contacto = db.Contactos.Include(c => c.Cliente).FirstOrDefault(x => x.ID == id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        //
        // GET: /Contactos/Crear

        public ActionResult Create(Decimal id)
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NombreComercial");

            Contacto cf = new Contacto();

            return View(cf);
        }

        //
        // POST: /Contactos/Crear

        [HttpPost]
        public ActionResult Create(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Contactos.Add(contacto);
                ClienteContacto cf = new ClienteContacto();
                cf.IdCliente = ViewBag.IdCliente;
                cf.IdContacto = contacto.IdContacto;
                cf.Estatus = 1;
                cf.FecAlta= DateTime.Now;

                contacto.IdUsuario = WebSecurity.CurrentUserId;
                //contacto.UserUpdateID = WebSecurity.CurrentUserId;
                contacto.FecMod = DateTime.Now;
                contacto.FecAlta = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index", new { id = cf.IdCliente });
            }

            return View(contacto);
        }

        //
        // GET: /Contactos/Editar/

        public ActionResult Edit(Decimal id = 0)
        {
            ClienteContacto clientecontacto = db.ClientesContacto.Include(c => c.Cliente).FirstOrDefault(x => x.ID == id);
            Contacto contacto = db.Contactos.Include(clientecontacto.IdContacto).FirstOrDefault(x => x.IdContacto == id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IdCliente", "NombreComercial", clientecontacto.IdCliente);
            return View(contacto);
        }

        //
        // POST: /Contactos/Editar/

        [HttpPost]
        public ActionResult Edit(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;

                contacto.IdUsuario = WebSecurity.CurrentUserId;
                contacto.FecMod = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index", new { id = ViewBag.IdCliente });
            }
            return View(contacto);
        }

        //
        // GET: /Contactos/Borrar/

        public ActionResult Delete(Decimal id = 0)
        {
            ClienteContacto clientecontacto = db.ClientesContacto.Include(c => c.Cliente).FirstOrDefault(x => x.ID == id);
            Contacto contacto = db.Contactos.Include(clientecontacto.IdContacto).FirstOrDefault(x => x.IdContacto == id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        //
        // POST: /Contactos/Borrar/

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Decimal id)
        {
            Contacto contacto = db.Contactos.Find(id);

            db.Entry(contacto).State = EntityState.Modified;

            contacto.IdUsuario = WebSecurity.CurrentUserId;
            contacto.FecMod = DateTime.Now;
            contacto.Estatus = 0;

            db.SaveChanges();
            return RedirectToAction("Index", new { id = ViewBag.IdCliente });
        }

        protected override void Dispose(Boolean disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
