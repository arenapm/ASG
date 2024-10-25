using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.Servicios;
namespace ASG
{
    public partial class Carrito : System.Web.UI.Page
    {
        BE.Usuario us;
        BLL.Carrito car = new BLL.Carrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionMannager.GetInstance != null)
            {
                us = SessionMannager.GetInstance.Usuario;
                if (us.car == null)
                {
                    us.car = new BE.Carrito();
                }
                else
                {
                    if (us.car.Inscripciones.Count != 0)
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        GridView1.DataSource = us.car.Inscripciones;
                        GridView1.DataBind();
                        car.calcularTotal(us.car);
                        Label1.Text = us.car.precTotal.ToString();
                        Panel3.Visible = true;
                    }
                    else
                    {
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        Panel1.Visible = true;
                    }
                }

                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}