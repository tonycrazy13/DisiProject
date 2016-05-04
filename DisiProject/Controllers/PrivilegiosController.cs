using DisiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisiProject.Controllers
{
    [Authorize]
    public class PrivilegiosController : ComunController
    {
        
        //
        // GET: /Privilegios/

        public ActionResult Index()
        {

            //List<Area> lista = _db.Areas.Where(r = r.);
            //lista.ToList();
            List<Area> lista = _db.Areas.ToList();

            ViewBag.Areas = new SelectList(lista, "ID", "DESCRIPCION");
            
            List<Permiso> permiso = _db.Permisos.ToList();
            ViewBag.Permisos = new SelectList(permiso, "IdPermiso", "DesPermiso");

           

            return View();
             
        }

        [HttpPost]
        public ActionResult Index(AreaPrivilegio newAreaPriv)
        {

            if (ModelState.IsValid)
            {

                return RedirectToAction("Detalles", "Privilegios", newAreaPriv);
            }
           
            return View();
            
        }



        public ActionResult Todos( AreaPrivilegio newAreaPriv)
        {

            if (ModelState.IsValid)
            {
                List<AreaPrivilegio> priv = _db.AreasPrivilegio.Where( c => c.Estatus.Equals(1)).ToList();

                return RedirectToAction("Detalles", "Privilegios", newAreaPriv);
               
            }

            return View();

        }

        //
        // GET: /EDITAR

        public ActionResult Editar(int id, int idPermiso)
        {


            AreaPrivilegio area = _db.AreasPrivilegio.Single(p => p.IdArea == id);

            List<Permiso> permiso = _db.Permisos.Where(c => c.IdPermiso != idPermiso).ToList();
            ViewBag.Permisos = new SelectList(permiso, "IdPermiso", "DesPermiso");


            return View(area);
        }



        [HttpPost]
        public ActionResult Editar(AreaPrivilegio areaPriv)
        {

            AreaPrivilegio ap = _db.AreasPrivilegio.SingleOrDefault(p => p.IdArea == areaPriv.Area.ID && p.Estatus.Equals(1));
            
         
            if (ModelState.IsValid)
            {
               
                    
                   
                    ap.IdArea = areaPriv.Area.ID;
                    ap.IdPermiso = areaPriv.Permiso.IdPermiso;
                    Area area = new Area();
                    area.ID = areaPriv.Area.ID;
                    Permiso permiso = new Permiso();
                    permiso.IdPermiso = areaPriv.Permiso.IdPermiso;

                    ap.Area = area;
                    ap.Permiso = permiso;

          
                    ap.FecMod = DateTime.Now;
                    ap.FecAlta = DateTime.Now;


                    _db.SaveChanges();
                    
              
               
                    List<AreaPrivilegio> priv = _db.AreasPrivilegio.Where(c =>  c.Estatus == 1).ToList();
                    return RedirectToAction("Detalles", "Privilegios", priv.ToList());
           

            }

            return View(areaPriv);
        }

        //
        // GET: /DETALLES

        public ActionResult Detalles(AreaPrivilegio newAreaPriv)
        {

            if (newAreaPriv.IdArea == 0)
            {
                

              
                    
                List<AreaPrivilegio> priv = _db.AreasPrivilegio.Where(c => c.Estatus.Equals(1)).ToList();    
                    
                    
                  
                ViewBag.AreaPrivilegio = priv.ToList();
                return View(priv.ToList());
            }
            else
            {
                List<AreaPrivilegio> priv = _db.AreasPrivilegio.Where(c => c.IdArea.Equals(newAreaPriv.IdArea) && c.Estatus.Equals(1)).ToList();
                ViewBag.AreaPrivilegio = priv.ToList();
                return View(priv.ToList());
            }
            

            

            List<Area> area = _db.Areas.Where(a => a.ID == newAreaPriv.IdArea).ToList();
            ViewBag.Area = area;

            return View();
           
        }

        //
        // POST: /DETALLES

        [HttpPost]
        public ActionResult Detalles()
        {
            
            return View();
        }


        //
        // GET: /BORRAR

        public ActionResult Borrar(int id, int idPermiso)
        {

            var area = _db.AreasPrivilegio.Single(p => p.IdArea.Equals(id) && p.IdPermiso.Equals(idPermiso));

            if (ModelState.IsValid)
            {
                area.Estatus = 0;
                UpdateModel(area);
          
                _db.SaveChanges();

                List<AreaPrivilegio> priv = _db.AreasPrivilegio.Where(c => c.IdArea == id && c.Estatus == 1).ToList();

                return RedirectToAction("Detalles", "Privilegios", priv.ToList());

            }

            return View();
        }

      
    }
}
