using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.BE;
using ASG.Servicios;
using ASG.BLL;

namespace ASG
{
    public partial class Bitacora : System.Web.UI.Page
    {
        BLL.Usuario gUsu = new BLL.Usuario();
        BE.Usuario us;
        BLL.Bitacora gBit = new BLL.Bitacora();
        BE.Bitacora bi;
        List<BE.Bitacora> bitacoras, eventos;
        protected void Page_Load(object sender, EventArgs e)
        {

            Permiso p = new Permiso(1, "ADMIN");
            if (SessionMannager.GetInstance != null)
            {
                us = SessionMannager.GetInstance.Usuario;
                if (gUsu.Validar(us, p))
                {
                    bitacoras = gBit.Listar();
                    GridView1.DataSource = bitacoras;
                    GridView1.DataBind();
                }
                else
                {
                    gUsu.Bloquear(us);
                    bi = new BE.Bitacora();
                    bi.DESC = $"Intruso detectado, el usuario {us.Login} intento ingresar a herramientas administrativas y fue bloqueado";
                    bi.CRIT = 5;
                    gBit.insertar(bi);
                    SessionMannager.Logout();
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                bi = new BE.Bitacora();
                bi.DESC = "Se detecto un intento de intruso sin acceso";
                bi.CRIT = 5;
                gBit.insertar(bi);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Capturar las fechas desde los controles TextBox
            DateTime fechaInicial, fechaFinal;

            // Validar si las fechas son correctas
            bool fechaInicialValida = DateTime.TryParse(txtFechaInicial.Text, out fechaInicial);
            bool fechaFinalValida = DateTime.TryParse(txtFechaFinal.Text, out fechaFinal);

            if (fechaInicialValida && fechaFinalValida)
            {
                // Filtrar la lista entre las fechas seleccionadas usando LINQ
                eventos = bitacoras.Where(ev => ev.DATE >= fechaInicial && ev.DATE <= fechaFinal).ToList();
                Session["EventosFiltrados"] = eventos;
                // Actualizar el GridView con los eventos filtrados
                GridView1.DataSource = eventos;
                GridView1.DataBind();
            }
            else
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Establecer el nuevo índice de página
            GridView1.PageIndex = e.NewPageIndex;
            if (Session["EventosFiltrados"] != null)
            {
                eventos = (List<BE.Bitacora>)Session["EventosFiltrados"];
                GridView1.DataSource = eventos;
            }
            else
            {

                GridView1.DataSource = bitacoras;
            }
            GridView1.DataBind();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Session.Remove("EventosFiltrados");
            txtFechaFinal.Text = "";
            txtFechaInicial.Text = "";
            GridView1.DataSource = bitacoras;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}