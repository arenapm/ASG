using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ASG.BE;
using System.Xml;
using System.Xml.Linq;

namespace ASG
{
    /// <summary>
    /// Descripción breve de Reportgen
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Reportgen : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string GenerarXML(int cantidadActivos, float dineroRecaudado, double dineroObtenido)
        {

            // Crear el XML con estos datos
            XDocument xmlDocument = new XDocument(
                new XElement("ResumenSorteos",
                    new XElement("CantidadSorteosActivos", cantidadActivos),
                    new XElement("DineroRecaudadoTotal", dineroRecaudado),
                    new XElement("DineroObtenido10Porciento", dineroObtenido)
                )
            );

            // Guardar el XML a un archivo
            string filePath = HttpContext.Current.Server.MapPath("~/SorteoResumen.xml");
            xmlDocument.Save(filePath);

            return "Archivo XML generado en: " + filePath;
        }
    }
}
