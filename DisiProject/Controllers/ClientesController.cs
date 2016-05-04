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
    public class ClientesController : ComunController
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            ViewBag.titulo = "Mantenimiento de Clientes";

            List<Cliente> list = _db.Clientes.ToList();

            return View(list);
        }

        //
        // GET: /Cliente/Detalles/5

        public ActionResult Detalles(decimal id = 0)
        {
            Cliente cliente = _db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Crear

        public ActionResult Crear(List<Direccion> listaDirecciones, List<ClienteDireccion> clienteDirecciones, string info)
        {
            if (info != null)
            {
                ViewBag.Info = info;
            } 
            ViewBag.fieldEstadoCliente = new SelectList(_db.EdosCliente.Where(r => r.Estatus == 1), "IdEstadoCliente", "Descripcion");
            ViewBag.fieldOrigenCliente = new SelectList(_db.OrigenesCliente.Where(r => r.Estatus == 1), "IdOrigenCliente", "Descripcion");
            ViewBag.fieldTipoPersona = new SelectList(_db.TiposPersona.Where(r => r.Estatus == 1), "IdTipoPersona", "Descripcion");
            return View();
        }

        //
        // POST: /Cliente/Crear

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(cliente);

                cliente.IdUsuario = WebSecurity.CurrentUserId;
                //cliente.FecMod = DateTime.Now;
                //cliente.FecAlta = DateTime.Now;
                if(validaContactosDirecciones(cliente))
                { 
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(cliente);
        }

        private bool validaContactosDirecciones(Cliente cliente)
        {
            var clientesContacto = _db.ClientesContacto.Include("IdCliente").Where(x => x.IdCliente == cliente.IdCliente);
            /*var contactos = _db.Contactos.Include("IdContacto").Where(x => x.IdContacto == clientesContacto.IdContacto, x => x.Estatus == 1);
            if(clientesContacto == null || contactos == null)
            {
                return false;
            }
            var direcciones = _db.Direcciones.Include(contactos.IdContacto).Where(x => x.IdContacto == contactos.IdContacto, x => x.Estatus == 1);
            if(direcciones == null )
            {
                return false;
            }*/
            return true;
            //throw new NotImplementedException();
        }

        //
        // GET: /Cliente/Editar/5

        public ActionResult Editar(decimal id = 0)
        {
            Cliente cliente = _db.Clientes.Find(id);
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
                _db.Entry(cliente).State = EntityState.Modified;

                cliente.IdUsuario = WebSecurity.CurrentUserId;
                //cliente.FecMod = DateTime.Now;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Borrar/5

        public ActionResult Borrar(decimal id = 0)
        {
            Cliente cliente = _db.Clientes.Find(id);
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
            Cliente cliente = _db.Clientes.Find(id);
            _db.Entry(cliente).State = EntityState.Modified;

            cliente.IdUsuario = WebSecurity.CurrentUserId;
            //cliente.FecMod = DateTime.Now;
            cliente.Estatus = 0;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
