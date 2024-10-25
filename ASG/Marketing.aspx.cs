using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.BE;
using ASG.Servicios;
using ASG.BLL;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace ASG
{
    public partial class Marketing : System.Web.UI.Page
    {
        BLL.Usuario gUsu = new BLL.Usuario();
        BE.Usuario us;
        BE.Bitacora bi;
        BLL.Bitacora gBi = new BLL.Bitacora();
        List<BE.Sorteo> sorteos;
        BLL.Sorteo gSort = new BLL.Sorteo();
        string res;
        protected void Page_Load(object sender, EventArgs e)
        {
            Permiso p = new Permiso(2, "MARK");
            if (SessionMannager.GetInstance != null)
            {
                us = SessionMannager.GetInstance.Usuario;
                if (gUsu.Validar(us, p))
                {

                }
                else
                {
                    gUsu.Bloquear(us);
                    bi = new BE.Bitacora();
                    bi.DESC = $"Intruso detectado, el usuario {us.Login} intento ingresar a herramientas administrativas y fue bloqueado";
                    bi.CRIT = 5;
                    gBi.insertar(bi);
                    SessionMannager.Logout();
                    Response.Redirect("Default.aspx");

                }
            }
            else
            {
                bi = new BE.Bitacora();
                bi.DESC = "Se detecto un intento de intruso sin acceso";
                bi.CRIT = 5;
                gBi.insertar(bi);
                // Response.Redirect("Default.aspx");
                Response.Redirect("https://youtube.com/shorts/SXHMnicI6Pg?si=rLmFFk96Fc8f9bz8");
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Reportgen servicio = new Reportgen();
            sorteos = gSort.Listar();
            // Calcular la cantidad de sorteos activos
            int cantidadActivos = sorteos.Count();

            // Calcular el dinero recaudado total
            float dineroRecaudado = sorteos.Sum(s => s.Valor * s.CantPart);

            // Calcular el 10% del dinero recaudado
            double dineroObtenido = dineroRecaudado * 0.25;

            res = servicio.GenerarXML(cantidadActivos, dineroRecaudado, dineroObtenido);
            Session["reporte"] = res;
            Panel3.Visible = true;
         
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            if (Session["reporte"] != null)
            {
                Panel3.Visible = false;
                Panel1.Visible = false;
                string filePath = Server.MapPath("~/SorteoResumen.xml");

                // Cargar el XML y mostrar los datos
                DataTable dt = new DataTable();
                dt.Columns.Add("Descripción");
                dt.Columns.Add("Valor");

                XDocument xmlDoc = XDocument.Load(filePath);

                dt.Rows.Add("Cantidad de Sorteos Activos", xmlDoc.Root.Element("CantidadSorteosActivos").Value);
                dt.Rows.Add("Dinero Recaudado Total", xmlDoc.Root.Element("DineroRecaudadoTotal").Value);
                dt.Rows.Add("Dinero Obtenido (25%)", xmlDoc.Root.Element("DineroObtenido10Porciento").Value);

                GridView1.DataSource = dt;
                GridView1.DataBind();
                Panel2.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
            }

        }
    }
}