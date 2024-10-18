using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.Servicios;
using ASG.BE;

namespace ASG
{
    public partial class _Default : Page
    {
        BLL.Usuario gUsu = new BLL.Usuario();
        BE.Usuario us;
        Servicios.DV gdv = new Servicios.DV();
        BLL.Sorteo gSort = new BLL.Sorteo();
        protected void Page_Load(object sender, EventArgs e)
        {
            int incons = gdv.verificarDVs();
            Permiso p = new Permiso(1, "ADMIN");
            if (SessionMannager.GetInstance != null)
            {
                us = SessionMannager.GetInstance.Usuario;
                if (gUsu.Validar(us, p) & incons == -1)
                {
                    Panel1.Visible = true;
                }
                else
                {

                }
            }

            GridView1.DataSource = gSort.Listar();
            GridView1.DataBind();


        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

    }
}