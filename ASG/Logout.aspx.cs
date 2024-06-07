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
    public partial class Logout : System.Web.UI.Page
    {
        BE.Bitacora bi = new BE.Bitacora();
        BLL.Bitacora gBit = new BLL.Bitacora();
        Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            BE.Usuario us = SessionMannager.GetInstance.Usuario;
            bi = new BE.Bitacora();
            bi.ID = rnd.Next(100, 200);
            bi.DESC = $"El usuario {us.Login} se deslogueo al sistema";
            bi.CRIT = 1;
            gBit.insertar(bi);
            string script = "setTimeout(function(){ window.location.href = 'Default.aspx'; }, 2500);"; // 10000 milisegundos = 10 segundos
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            lbllogout.Text = $"Gracias por utilizar nuestros servicios, hasta luego {us.Login}";
            SessionMannager.Logout();

        }
    }
}