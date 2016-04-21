using System.Net;
using System.Net.Mail;
using System.Text;

namespace DisiProject.Correo
{
    public class email
    {
        //envio de correo Peticion
        public void Send(string resetLink, string email)
        {

            MailMessage mmsg = new MailMessage();
            mmsg.To.Add("onlyinthedark666@hotmail.com");
            //Asunto
            mmsg.Subject = "Recuperacion de Cuenta";
            mmsg.SubjectEncoding = Encoding.UTF8;
            var htmlBody = "Prueba de Email";
            //htmlBody += "\n OCUPACION:" + form.ocupacion;
            //htmlBody += "\n NOMBRE DE CONTACTO:" + form.nombre;
            //htmlBody += "\n TELEFONO FIJO:" + form.tel;
            //htmlBody += "\n TELEFONO CELULAR:" + form.celular;
            //htmlBody += "\n \n" + form.comentarios;
            htmlBody += "\n \n" + resetLink;
            mmsg.Body = htmlBody;

            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = false;
            mmsg.From = new MailAddress("onlyinthedark666@gmail.com");
            SmtpClient cliente = new SmtpClient
            {
                Credentials = new NetworkCredential("onlyinthedark666@gmail.com", "nightwish123"),
                Port = 587,
                EnableSsl = true,
                Host = "smtp.gmail.com"
            };
            cliente.Send(mmsg);


        }


        //envio de correo Confirmacion
        public void SendPost(string user, string email, string pass)
        {

            MailMessage mmsg = new MailMessage();
            mmsg.To.Add("onlyinthedark666@hotmail.com");
            //Asunto
            mmsg.Subject = "Contraseña Reestablecida";
            mmsg.SubjectEncoding = Encoding.UTF8;
            var htmlBody = "Prueba de Email Restableciendo Contraseña";
            htmlBody += "\nSu nueva contraseña es: " + pass;
            //htmlBody += "\n NOMBRE DE CONTACTO:" + form.nombre;
            //htmlBody += "\n TELEFONO FIJO:" + form.tel;
            //htmlBody += "\n TELEFONO CELULAR:" + form.celular;
            //htmlBody += "\n \n" + form.comentarios;
            htmlBody += "\nSu usuario es: " + user;
            mmsg.Body = htmlBody;

            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = false;
            mmsg.From = new MailAddress("onlyinthedark666@gmail.com");
            SmtpClient cliente = new SmtpClient
            {
                Credentials = new NetworkCredential("onlyinthedark666@gmail.com", "nightwish123"),
                Port = 587,
                EnableSsl = true,
                Host = "smtp.gmail.com"
            };
            cliente.Send(mmsg);

           

        }

             
    }
}