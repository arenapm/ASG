using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.Servicios;
using ASG.BE;
using ASG.BLL;
namespace ASG
{
    public partial class Sorteo1 : System.Web.UI.Page
    {
        List<BE.Sorteo> sorteos;
        BLL.Sorteo gSort = new BLL.Sorteo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionMannager.GetInstance != null)
            {
                sorteos = gSort.ListarSortUs(SessionMannager.GetInstance.Usuario);
                GridView1.DataSource = sorteos;
                GridView1.DataBind();
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribirse")
            {
                // Obtener el índice de la fila
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Obtener el ID del sorteo
                int sorteoId = (int)GridView1.DataKeys[rowIndex].Value;

                if (SessionMannager.GetInstance.Usuario.car == null)
                {
                    SessionMannager.GetInstance.Usuario.car = new BE.Carrito();
                }
                SessionMannager.GetInstance.Usuario.car.Inscripciones.Add(sorteos[rowIndex]);

                // Mostrar un mensaje de confirmación
                Response.Write("<script>alert('Te has inscrito al sorteo " + sorteoId + "');</script>");
            }
        }
    }
}