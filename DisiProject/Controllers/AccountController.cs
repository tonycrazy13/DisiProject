using System;
using System.Web.Mvc;
using System.Web.Security;
using DisiProject.AddModelError;
using DisiProject.Datos;
using DisiProject.Models;
using DisiProject.Util;

namespace DisiProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        readonly DisiContext _db = new DisiContext();
        readonly Error _mensajes = new Error();
        static int _counter;

        static readonly object LockObj = new object();
        readonly linq _validacion = new linq();
        readonly Sha1 _sha = new Sha1();
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
                        //prueba
                        //revisamos si tiene una pass generica para enviarlo a cambio de contraseña


                        if (_validacion.ValidaAsociados(u.UserName.ToUpper(), u.Password))
                        {
                            _counter = 0;
                            return RedirectToAction("ResetContraseña", "Account", new { rt = u.UserName.ToUpper() });
                        }

                        //si no
                        //encriptamos la contraseña en sha1
                        var encriptado = _sha.GetSha1(u.Password);

                        //validamos x usuario y contraseña encriptada
                        if (_validacion.ValidaAsociados(u.UserName.ToUpper(), encriptado))
                        {
                            //revisamos que la cuenta no este bloqueada
                            var sesion = _validacion.Sesion(u.UserName.ToUpper());

                            //si no esta bloqueada accesa
                            if (sesion == false)
                            {

                                var v = _validacion.Validacion(u.UserName.ToUpper(), encriptado);
                                Session.Add("UserID", v.id.ToString());
                                Session.Add("UserFullName", v.IdEmpleado);
                                FormsAuthentication.SetAuthCookie(u.UserName.ToUpper(), false);
                                if (!string.IsNullOrEmpty(returnUrl))
                                {
                                    //si entra a la sesion reiniciamos contador
                                    _counter = 0;
                                    return Redirect(returnUrl);
                                }
                                _counter = 0;
                                return RedirectToAction("Index", "Home");
                            }

                            //si esta bloqueada regresamos a la vista y mandamos mensaje de notificacion
                            else
                            {

                                ViewBag.Error = _mensajes.CuentBloqueada(_counter);


                            }


                        }
                        //validacion mensaje
                        ViewBag.Error = _mensajes.AlertaContraseña();


                        ///////////
                        /// Intentos restantes
                        /// 

                        var bloqueado = _validacion.Sesion(u.UserName.ToUpper());
                        if (bloqueado == false)
                        {
                            //revisamos si existe el usuario para los intentos restantes antes de bloquear usuario

                            if (_validacion.ValidaUsuario(u.UserName.ToUpper()))
                            {
                                //tiliza el bloqueo de exclusión mutua de un objeto e iniciamos contador
                                lock (LockObj)
                                {
                                    _counter++;
                                }

                                //si los intentos llegan al limite mandamos bandera para bloquear cuenta
                                if (_counter == 3)
                                {
                                    _validacion.UpdateRegistro(u.UserName.ToUpper());
                                    ViewBag.Error = _mensajes.CuentBloqueada(_counter);
                                }
                                else
                                {

                                    ViewBag.Error = null;
                                    ViewBag.Info = _mensajes.CredencialesInvalidas(_counter);
                                }


                            }
                        }
                        else
                        {
                            ViewBag.Error = _mensajes.CuentBloqueada(_counter);

                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    ViewBag.Error = ex.ToString();
                }
            }

            ModelState.Clear();

            return View();
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

                try
                {
                    using (_db)
                    {
                        var user = _validacion.UsuarioEmail(model.Email);

                        if (user != null)
                        {

                            //insertamos o actualizamos la fecha de control 
                            _validacion.ActualizarFecha(model.Email);

                            // Generar el enlace HTML enviado por correo electrónico

                            string resetLink = UrlEmail(user);

                            // Intento de enviar el correo electrónico

                            var envio = new Email();
                            envio.Send(resetLink, model.Email);
                            ViewBag.Successful = _mensajes.AlertaCorreoEnviado();


                        }
                        else // correo no encontrado 
                        {

                            ViewBag.Error = _mensajes.AlertaCorreoErroneo();

                        }
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = _mensajes.AlertaCorreo() + e.Message;
                }

            }

            ModelState.Clear();

            return View();

        }


        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetContraseña(string rt)
        {
            ResetPasswordModel model = new ResetPasswordModel { ReturnUser = rt };
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
                    var registro = _validacion.ExisteUsuario(model.ReturnUser);


                    if (registro != null)
                    {
                        //var date = _validacion.Date(model.ReturnUser);
                        var email = _validacion.Email(model.ReturnUser);



                        var encriptado = _sha.GetSha1(model.ConfirmPassword);
                        _validacion.ActualizarfechaUsuario(registro, encriptado);

                        //envio correo de notificacion
                        var envio = new Email();

                        var returnUrl = this.returnUrl();
                        envio.SendPost(model.ReturnUser, email, model.ConfirmPassword, returnUrl);

                        ViewBag.Successful = _mensajes.AlertaCorreoEnviado();

                    }
                    else
                    {

                        ViewBag.Error = _mensajes.AlertaUrlError();
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

        public string returnUrl()
        {

            return "<a href='"
                          + Url.Action("Login", "Account", "http")
                          + "'>Ir a la Pagina Principal</a>";

        }


        ////



    }
}
