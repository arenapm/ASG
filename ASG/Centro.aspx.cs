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
    public partial class Centro : System.Web.UI.Page
    {
        BLL.Usuario gUsu = new BLL.Usuario();
        BE.Usuario us;
        BE.Bitacora bi;
        BLL.Bitacora gBi = new BLL.Bitacora();
        protected void Page_Load(object sender, EventArgs e)
        {
            Permiso p = new Permiso(1, "ADMIN");
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
                Response.Redirect("Default.aspx");
            }
        }
        protected void btnBitacora_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bitacora.aspx");
        }

        protected void btnRespaldo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Respaldos.aspx");
        }

        protected void btnInconsistencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inconsistencia.aspx");
        }
    }
}