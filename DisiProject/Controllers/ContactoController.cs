using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.Models;

using WebMatrix.WebData;
using System.Data;
using System.Data.Entity;

namespace DisiProject.Controllers
{
    public class ContactoController : ComunController
    {
        
        //
        // GET: /Contacto/

        public ActionResult Index(Decimal id)
        {
            if(id != 0){
                var contactos = _db.ClientesContacto.Where(x => x.IdCliente == id);

                ViewBag.Cliente = _db.Clientes.Find(id);

                return View(contactos.ToList());
            }
            return RedirectToAction("Crear", "Contactos");
        }
        //
        // GET: /Contactos/Detalles/

        public ActionResult Detalles(Decimal id = 0)
        {
            /*Contacto contacto = _db.Contactos.Include(c => c.Cliente).FirstOrDefault(x => x.ID == id);
            if (contacto == null)
            {
                return HttpNotFound();
            }*/
            Contacto contacto = new Contacto();
            return View(contacto);
        }

        //
        // GET: /Contactos/Crear

        public ActionResult Crear(List<Direccion> listaDirecciones, List<ContactoDireccion> contactoDirecciones, string info)
        {
            if(info != null)
            {
                ViewBag.Info = info;
            } 
            
            ViewBag.fieldEstadoCivil = new SelectList(_db.EstadosCivil.Where(r => r.Estatus == 1), "IdEstadoCivil", "Descripcion");
            ViewBag.fieldTipoContacto = new SelectList(_db.TiposContacto.Where(r => r.Estatus == 1), "IdTipoContacto", "DescripcionCorta");
            ViewBag.fieldTipoPersona = new SelectList(_db.TiposPersona.Where(r => r.Estatus == 1), "IdTipoPersona", "Descripcion");
            Contacto cf = new Contacto();

            return View(cf);
        }

        //
        // POST: /Contactos/Crear

        [HttpPost]
        public ActionResult Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _db.Contactos.Add(contacto);
                ClienteContacto cf = new ClienteContacto();
                cf.IdCliente = ViewBag.IdCliente;
                cf.IdContacto = contacto.IdContacto;
                cf.Estatus = 1;
                cf.FecAlta= DateTime.Now;

                contacto.IdUsuario = WebSecurity.CurrentUserId;
                //contacto.UserUpdateID = WebSecurity.CurrentUserId;
                contacto.FecMod = DateTime.Now;
                contacto.FecAlta = DateTime.Now;

                _db.SaveChanges();
                return RedirectToAction("Index", new { id = cf.IdCliente });
            }

            return View(contacto);
        }

        //
        // GET: /Contactos/Editar/

        public ActionResult Editar(Decimal id = 0)
        {
            /*ClienteContacto clientecontacto = _db.ClientesContacto.Include(c => c.Cliente).FirstOrDefault(x => x.ID == id);
            Contacto contacto = _db.Contactos.Include(clientecontacto.IdContacto).FirstOrDefault(x => x.IdContacto == id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(_db.Clientes, "IdCliente", "NombreComercial", clientecontacto.IdCliente);

             */
            Contacto contacto = new Contacto();
            return View(contacto);

        }

        //
        // POST: /Contactos/Editar/

        [HttpPost]
        public ActionResult Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(contacto).State = EntityState.Modified;

                contacto.IdUsuario = WebSecurity.CurrentUserId;
                contacto.FecMod = DateTime.Now;

                _db.SaveChanges();
                return RedirectToAction("Index", new { id = ViewBag.IdCliente });
            }
            return View(contacto);
        }

        //
        // GET: /Contactos/Borrar/

        public ActionResult Borrar(Decimal id = 0)
        {
            /*ClienteContacto clientecontacto = _db.ClientesContacto.Include(c => c.Cliente).FirstOrDefault(x => x.ID == id);
            Contacto contacto = _db.Contactos.Include(clientecontacto.IdContacto).FirstOrDefault(x => x.IdContacto == id);
            if (contacto == null)
            {
                return HttpNotFound();
            }*/
            Contacto contacto = new Contacto();
            return View(contacto);
        }

        //
        // POST: /Contactos/Borrar/

        [HttpPost, ActionName("Delete")]
        public ActionResult BorrarConfirmed(Decimal id)
        {
            Contacto contacto = _db.Contactos.Find(id);

            _db.Entry(contacto).State = EntityState.Modified;

            contacto.IdUsuario = WebSecurity.CurrentUserId;
            contacto.FecMod = DateTime.Now;
            contacto.Estatus = 0;

            _db.SaveChanges();
            return RedirectToAction("Index", new { id = ViewBag.IdCliente });
        }

        protected override void Dispose(Boolean disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
