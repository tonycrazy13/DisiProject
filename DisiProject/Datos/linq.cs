using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DisiProject.AddModelError;

namespace DisiProject.Datos
{
    public class linq
    {
        readonly PruebaUsuarioDisiDataContext _db = new PruebaUsuarioDisiDataContext();
        readonly Error _mensajes = new Error();

        public Boolean ValidaAsociados(string username, string password)
        {

            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis);
            if (compara == -1)
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(username) && a.Contraseña.Equals(password));
                return validacion != null;
            }
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.Correo.Equals(username) && a.Contraseña.Equals(password));
                return validacion != null;
            }


        }

        public Boolean ValidaGenerica(string username, string password)
        {

            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis, StringComparison.Ordinal);
            if (compara == -1)
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(username) && a.Contraseña.Equals(password));
                return validacion != null;
            }
            {
                var validacion = _db.Usuarios.FirstOrDefault(a => a.Correo.Equals(username) && a.Contraseña.Equals(password));
                return validacion != null;
            }


        }



        public Usuario Validacion(string username, string password)
        {
            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis);
            if (compara == -1)
            {
                return _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(username) && a.Contraseña.Equals(password));
            }
            {
                return _db.Usuarios.FirstOrDefault(a => a.Correo.Equals(username) && a.Contraseña.Equals(password));
            }



        }



        public Usuario ValidacionNueva(string username, string password)
        {
            string searchForThis = "@";
            var compara = username.IndexOf(searchForThis);
            if (compara == -1)
            {
                return _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(username) && a.Contraseña.Equals(password));
            }
            {
                return _db.Usuarios.FirstOrDefault(a => a.Correo.Equals(username) && a.Contraseña.Equals(password));
            }



        }


        public int? Sesion(string username)
        {
            return (from a in _db.Usuarios where a.UsuarioEmpleado == username select a.Bloqueado).FirstOrDefault();


        }


        public Boolean ValidaUsuario(string username)
        {
            var validacion = _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(username));
            return validacion != null;

        }



        public Usuario ValidacionUsuario(string username)
        {
            return _db.Usuarios.FirstOrDefault(a => a.UsuarioEmpleado.Equals(username));
        }

        public void UpdateRegistro(string username)
        {
            var registro = _db.Usuarios.SingleOrDefault(w => w.UsuarioEmpleado == username);
            registro.Bloqueado = 1;
            registro.FechaBloqueado = DateTime.Now.ToString(_mensajes.Fecha());
            _db.SubmitChanges();
        }


        public string UsuarioEmail(string email)
        {
            return (from u in _db.Usuarios
                    where u.Correo == email
                    select u.UsuarioEmpleado).FirstOrDefault();


        }

        public void ActualizarFecha(string email)
        {
            var registro = _db.Usuarios.SingleOrDefault(w => w.Correo == email);
            registro.FechaContraseña = DateTime.Now.ToString(_mensajes.Fecha());
            _db.SubmitChanges();
        }

        public Usuario ExisteUsuario(string username)
        {

            return _db.Usuarios.SingleOrDefault(w => w.UsuarioEmpleado == username);

        }


        public string Date(string username)
        {
            return (from u in _db.Usuarios
                    where u.UsuarioEmpleado == username
                    select u.FechaContraseña).FirstOrDefault();

        }


        public string Email(string username)
        {
            return (from u in _db.Usuarios
                    where u.UsuarioEmpleado == username
                    select u.Correo).FirstOrDefault();
        }


        public void ActualizarfechaUsuario(Usuario registro, string encriptado)
        {
            registro.FechaContraseña = DateTime.Now.ToString(_mensajes.Fecha());
            registro.Contraseña = encriptado;
            registro.Bloqueado = 0;
            _db.SubmitChanges();
        }



    }
}