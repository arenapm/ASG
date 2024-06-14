using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.BE;
using ASG.BLL;
using ASG.DAL;
using ASG.Servicios;


namespace ASG
{
    public partial class Registro : System.Web.UI.Page
    {
        BLL.Usuario gUs = new BLL.Usuario();
        BE.Usuario us;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUser.Text)|| string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtpwd.Text) || string.IsNullOrEmpty(txtpwd1.Text) || string.IsNullOrEmpty(txtemail.Text))
            {
                Label1.Text = "Debe completar todos los campos";
                Label1.Visible = true;
            }else if (txtpwd.Text != txtpwd1.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden";
                lblMensaje.Visible = true;
            }
            else
            {
                us = new BE.Usuario();
                us.Login = txtUser.Text;
                us.Password = txtpwd.Text;
                gUs.insertar(us);
            }


        }
    }
}