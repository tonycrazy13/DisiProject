using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisiProject.Common
{
    public static class MyHelpers
    {
        public static MvcHtmlString Imagen(this HtmlHelper helper, String src, String alterText)
        {
            var cadena = new TagBuilder("img");
            cadena.MergeAttribute("src", src);
            cadena.MergeAttribute("alt", alterText);
            return MvcHtmlString.Create(cadena.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Boton de imagen
        /// </summary>
        /// <param name="helper">hola</param>
        /// <param name="src">Ruta de imagen</param>
        /// <param name="alterText"></param>
        /// <param name="abilitado"></param>
        /// <param name="estilo"></param>
        /// <param name="onClick"></param>
        /// <returns></returns>
        public static MvcHtmlString BtnImagen(this HtmlHelper helper, String rutaAccion, String src, String alterText, String clase = "", String estilo = "")
        {
            var cadena = new TagBuilder("input");
            cadena.MergeAttribute("type", "image");
            cadena.MergeAttribute("src", src);
            cadena.MergeAttribute("alt", alterText);
            cadena.MergeAttribute("class", clase);
            cadena.MergeAttribute("title", alterText);
            cadena.MergeAttribute("onclick", rutaAccion);
            cadena.MergeAttribute("style", estilo);
            return MvcHtmlString.Create(cadena.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="texto"></param>
        /// <param name="onclick"></param>
        /// <param name="onmouseover"></param>
        /// <param name="onmouseout"></param>
        /// <param name="estilo"></param>
        /// <returns></returns>
        public static MvcHtmlString Boton(this HtmlHelper helper, String texto, String type, String onclick = "", String clase = "", String estilo = "")
        {
            var cadena = new TagBuilder("input");
            cadena.MergeAttribute("type", type);
            cadena.MergeAttribute("value", texto);
            if (!String.IsNullOrEmpty(clase))
                cadena.MergeAttribute("class", clase);
            if (!String.IsNullOrEmpty(onclick))
                cadena.MergeAttribute("onclick", onclick);
            if (!String.IsNullOrEmpty(estilo))
                cadena.MergeAttribute("style", estilo);
            return MvcHtmlString.Create(cadena.ToString(TagRenderMode.SelfClosing));
        }
    }
}