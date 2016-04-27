using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DisiProject.AddModelError;
using DisiProject.Models;

namespace DisiProject.Datos
{
    public class linq
    {
        DisiContext _db = new DisiContext();
        readonly Error _mensajes = new Error();

        public Boolean ValidaAsociados(string username, string password)
        {

            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis);
            if (compara == -1)
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.username.Equals(username) && a.password.Equals(password));
                return validacion != null;
            }
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.correo.Equals(username) && a.password.Equals(password));
                return validacion != null;
            }


        }

        public Boolean ValidaGenerica(string username, string password)
        {

            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis, StringComparison.Ordinal);
            if (compara == -1)
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.username.Equals(username) && a.password.Equals(password));
                return validacion != null;
            }
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.correo.Equals(username) && a.password.Equals(password));
                return validacion != null;
            }


        }



        public Usuario Validacion(string username, string password)
        {
            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis);
            if (compara == -1)
            {
                return _db.Usuarios.FirstOrDefault(a => a.username.Equals(username) && a.password.Equals(password));
            }
            {
                return _db.Usuarios.FirstOrDefault(a => a.correo.Equals(username) && a.password.Equals(password));
            }



        }



        public Usuario ValidacionNueva(string username, string password)
        {
            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis);
            if (compara == -1)
            {
                return _db.Usuarios.FirstOrDefault(a => a.username.Equals(username) && a.password.Equals(password));
            }
            {
                return _db.Usuarios.FirstOrDefault(a => a.correo.Equals(username) && a.password.Equals(password));
            }



        }


        public bool? Sesion(string username)
        {
            return (from a in _db.Usuarios where a.username == username select a.bloqueado).FirstOrDefault();


        }


        public Boolean ValidaUsuario(string username)
        {
            var validacion = _db.Usuarios.FirstOrDefault(a => a.username.Equals(username));
            return validacion != null;

        }



        public Usuario ValidacionUsuario(string username)
        {
            return _db.Usuarios.FirstOrDefault(a => a.username.Equals(username));
        }

        public void UpdateRegistro(string username)
        {
            var registro = _db.Usuarios.SingleOrDefault(w => w.username == username);
            registro.bloqueado = true;
            registro.fechaBloqueado = DateTime.Now;
            _db.SaveChanges();
        }


        public string UsuarioEmail(string email)
        {
            return (from u in _db.Usuarios
                    where u.correo == email
                    select u.username).FirstOrDefault();


        }

        public void ActualizarFecha(string email)
        {
            var registro = _db.Usuarios.SingleOrDefault(w => w.correo == email);
            registro.fechaContrasenia = DateTime.Now;
            _db.SaveChanges();
        }

        public Usuario ExisteUsuario(string username)
        {

            return _db.Usuarios.SingleOrDefault(w => w.username == username);

        }


        public string Date(string username)
        {
            DateTime fecha = (from u in _db.Usuarios
                    where u.username == username
                    select u.fechaContrasenia).FirstOrDefault();
            return fecha.ToString(_mensajes.Fecha());
        }


        public string Email(string username)
        {
            return (from u in _db.Usuarios
                    where u.username == username
                    select u.correo).FirstOrDefault();
        }


        public void ActualizarfechaUsuario(Usuario registro, string encriptado)
        {
            registro.fechaContrasenia = DateTime.Now;
            registro.password = encriptado;
            registro.bloqueado = false;
            _db.SaveChanges();
        }
    }
}