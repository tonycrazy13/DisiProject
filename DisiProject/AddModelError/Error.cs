using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisiProject.AddModelError
{
    public class Error
    {

        public string AlertaContraseña()
        {
            return "El usuario o contraseña son incorrectas";
        }


        public string AlertaCorreo()
        {
            return "Edición envío de correo electrónico";
        }

        public string AlertaCorreoErroneo()
        {
            return "Ningún usuario encontrado con el correo electrónico dado";
        }


        public string AlertaCorreoEnviado()
        {
            return "Se ha enviado un correo a su bandeja de entrada, por favor revise";
        }


        public string AlertaCorreoModificado()
        {
            return "Se ha cambiado correctamente";
        }

        public string AlertaCorreoError()
        {
            return "No se ha cambiado la nueva contraseña";
        }


        public string AlertaUrlError()
        {
            return "Esta Url ya no es valida favor de volver a solicitar correo de recuperacion";
        }

        public string Key()
        {
            return "1";
        }

        public string Fecha()
        {
            return "MM/dd/yyyy";
        }
            
      

        


    }
}