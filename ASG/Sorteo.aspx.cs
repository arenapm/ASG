using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.Servicios;
using ASG.BE;
using ASG.BLL;
using ASG.DAL;

namespace ASG
{
    public partial class Sorteo : System.Web.UI.Page
    {
        BLL.Sorteo gSort = new BLL.Sorteo();
        BE.Sorteo sort;
        DV gDv = new DV();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(txtFecha.Text.ToString());
            if (fecha <= DateTime.Today)
            {
                Response.Write("<script>alert('La fecha debe ser mayor al dia de hoy.');</script>");
                lblFecha.Visible = true;
                return;
            }
            else
            {
                int valor = int.Parse(txtValorEntrada.Text);
                if (valor > 1000 && valor!=0)
                {
                    Response.Write("<script>alert('El valor de entrada debe ser entre 1-1000.');</script>");
                    lblFecha.Text = "El valor de entrada debe ser entre 1-1000";

                }
                else
                {

                    sort = new BE.Sorteo();
                    sort.Valor = valor;
                    sort.Nombre = txtNombre.Text;
                    sort.Descripcion = txtDescripcion.Text;
                    sort.Creador = SessionMannager.GetInstance.Usuario;
                    sort.Premio = txtPremio.Text;
                    sort.ID = gSort.MaxId();
                    sort.DV = gDv.calcularDV(sort);
                    gSort.insertar(sort);

                }
            }
        }

    }
}