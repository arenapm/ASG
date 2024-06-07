using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.BLL;
using ASG.BE;
using ASG.Servicios;
namespace ASG
{
    public partial class Login : System.Web.UI.Page
    {
        BE.Bitacora bi;
        BLL.Usuario gUsuario = new BLL.Usuario();
        BLL.Bitacora gBit = new BLL.Bitacora();
        Permiso p = new Permiso(1, "ADMIN");
        Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            BE.Usuario unUsuario = gUsuario.buscarUsuario(txtUser.Text, txtPass.Text);
            if (unUsuario != null)
            {
                if(unUsuario.ID == 1)
                {
                    unUsuario.Permisos.Add(p);
                }
                SessionMannager.Login(unUsuario);
                bi = new BE.Bitacora();
                bi.ID = rnd.Next(1, 100);
                bi.DESC = $"El usuario {unUsuario.Login} ingreso al sistema";
                bi.CRIT = 1;
                gBit.insertar(bi);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}