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
    public partial class Inconsistencia : System.Web.UI.Page
    {
        BLL.Usuario gUsu = new BLL.Usuario();
        BE.Usuario us;
        BE.Bitacora bi;
        BLL.Bitacora gBi = new BLL.Bitacora();
        Servicios.DV gDV = new Servicios.DV();
        protected void Page_Load(object sender, EventArgs e)
        {
            Permiso p = new Permiso(1, "ADMIN");
            if (SessionMannager.GetInstance != null)
            {
                us = SessionMannager.GetInstance.Usuario;
                if (gUsu.Validar(us, p))
                {
                    gDV.verificarDVs();
                    GridView1.DataSource = gDV.SortDV;
                    GridView1.DataBind();
                    GridView2.DataSource = gDV.GanDV;
                    GridView2.DataBind();
                }
                else
                {
                    gUsu.Bloquear(us);
                    bi = new BE.Bitacora();
                    bi.DESC = $"Intruso detectado, el usuario {us.Login} intento ingresar a herramientas administrativas y fue bloqueado";
                    bi.CRIT = 5;
                    gBi.insertar(bi);
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                bi = new BE.Bitacora();
                bi.DESC = "Se detecto un intento de intruso sin acceso";
                bi.CRIT = 5;
                gBi.insertar(bi);
                Response.Redirect("Default.aspx");
            }
        }
        protected void btnSolucionar_Click(object sender, EventArgs e)
        {

        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

    }
}