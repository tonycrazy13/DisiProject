using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Security;
using DisiProject.Correo;
using DisiProject.AddModelError;
using DisiProject.Models;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace DisiProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        readonly PruebaUsuarioDisiDataContext _db = new PruebaUsuarioDisiDataContext();
        readonly Error _mensajes = new Error();
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel u, string returnUrl)
        {


            if (ModelState.IsValid)
            {
                try
                {
                     using (_db)
                     {
                         //valida x usuario o por correo
                         var v = _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(u.UserName) && a.Contraseña.Equals(u.Password));
                         if (v != null)
                         {
                             Session["LogedUserID"] = v.UserId.ToString();
                             Session["LogedUserFullName"] = v.NombreEmpleado;
                             FormsAuthentication.SetAuthCookie(u.UserName, false);
                             if (!string.IsNullOrEmpty(returnUrl))
                             {
                                 return Redirect(returnUrl);
                             }
                             else
                             {
                                 return RedirectToAction("Index", "Home");
                             }
                         }
                     } 
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(_mensajes.Key(), ex.ToString());
                }
            }
            ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaContraseña());
            return View(u);
        }





        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }



        //GET: /Account/RecuperarContraseña
        [AllowAnonymous]
        public ActionResult RecuperarContraseña()
        {
            return View();
        }

        //
        // POST: /Account/RecuperarContraseña

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarContraseña(CorreoModel model)
        {

            if (ModelState.IsValid)
            {
                using (_db)
                {
                    var user = (from u in _db.Usuarios
                                where u.Correo== model.Email
                                select u.UsuarioEmpleado ).FirstOrDefault();
                    
                    if (user != null)
                    {
                     
                       
                        //insertamos o actualizamos la fecha de control 
                        var fecha = DateTime.Now.ToString(_mensajes.Fecha());
                        var registro = _db.Usuarios.SingleOrDefault(w => w.Correo == model.Email);
                        registro.FechaContraseña = fecha;
                        _db.SubmitChanges();
                        
                        // Generar el enlace HTML enviado por correo electrónico

                        string resetLink = UrlEmail(user);
                       
                        // Intento de enviar el correo electrónico
                        try
                        {
                            var envio = new email();
                            envio.Send(resetLink, model.Email);
                            ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaCorreoEnviado());
                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaCorreo() + e.Message);
                        }
                    }
                    else // correo no encontrado 
                    {
                        ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaCorreoErroneo());
                    }
                }
            }

            return View(model);
            
        }


        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetContraseña(string rt)
        {
            ResetPasswordModel model = new ResetPasswordModel {ReturnUser = rt};
            return View(model);
        }


        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetContraseña(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                
                using (_db)
                {
                    var registro = _db.Usuarios.SingleOrDefault(w => w.UsuarioEmpleado == model.ReturnUser);

                    if (registro != null)
                    {
                        var date = (from u in _db.Usuarios
                                    where u.UsuarioEmpleado == model.ReturnUser
                                    select u.FechaContraseña).FirstOrDefault();

                        var email = (from u in _db.Usuarios
                                    where u.UsuarioEmpleado == model.ReturnUser
                                    select u.Correo).FirstOrDefault();

                        if (DateTime.Now.ToString(_mensajes.Fecha()) == date)
                        {
                            registro.FechaContraseña = DateTime.Now.ToString(_mensajes.Fecha());
                            registro.Contraseña = model.ConfirmPassword;
                            _db.SubmitChanges();

                            //envio correo de notificacion
                            var envio = new email();
                            envio.SendPost(model.ReturnUser,email,model.ConfirmPassword);
                            //ViewBag.Message = "Se ha cambiado correctamente";

                            ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaCorreoEnviado());
                        }
                        else
                        {
                            //ViewBag.Message = "No se ha cambiado la nueva contraseña"; 
                            ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaCorreoError());
                        }

                    }
                    else
                    {
                        //ViewBag.Message = "Esta Url ya no es valida favor de volver a solicitar correo de recuperacion";

                        ModelState.AddModelError(_mensajes.Key(), _mensajes.AlertaUrlError());
                    }
                 
                }
            }
            return View(model);
        }


        //
        // GET: /Account/Register

        
        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
               
            }

          
            return View(model);
        }

       

        public string UrlEmail(string user)
        {
            return "<a href='"
                          + Url.Action("ResetContraseña", "Account", new { rt = user }, "http")
                          + "'>Restablezca su Contraseña</a>";
        }
           
    }
}
