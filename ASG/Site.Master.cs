﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASG.Servicios;
using ASG.BLL;

namespace ASG
{
    public partial class SiteMaster : MasterPage
    {
        BLL.Usuario gUsu = new BLL.Usuario();
        Permiso p = new Permiso(1, "ADMIN");
        protected void Page_Load(object sender, EventArgs e)
        {
                GenerateNavbar();
            if (!IsPostBack)
            {
            }
        }

        private void GenerateNavbar()
        {
            if (SessionMannager.GetInstance != null)
            {
                BE.Usuario us = SessionMannager.GetInstance.Usuario;

                if (gUsu.Validar(us, p))
                {
                    // Navbar para usuarios autenticados como admin
                    AgregarElementoNavbar("Home", "Default.aspx");
                    AgregarElementoNavbar("Nosotros", "Nosotros.aspx");
                    AgregarElementoNavbar("Centro", "Centro.aspx");
                    AgregarElementoNavbar("Logout", "Logout.aspx");
                    Usuario.Text = "Bienvenido: " + us.Login;
                }
                else
                {
                    AgregarElementoNavbar("Home", "Default.aspx");
                    AgregarElementoNavbar("Sorteos", "Sorteo.aspx");
                    AgregarElementoNavbar("Nosotros", "Nosotros.aspx");
                    AgregarElementoNavbar("Carrito", "Carrito.aspx");
                    AgregarElementoNavbar("Logout", "Logout.aspx");
                    Usuario.Text = "Bienvenido: "+us.Login;
                }
                

            }
            else
            {
                // Navbar para visitantes no autenticados
                AgregarElementoNavbar("Home", "Default.aspx");
                AgregarElementoNavbar("Nosotros", "Nosotros.aspx");
                AgregarElementoNavbar("Registrarse", "Registro.aspx");
                AgregarElementoNavbar("Login", "Login.aspx");
                Usuario.Text = "Bienvenido";
            }
        }

        private void AgregarElementoNavbar(string texto, string url)
        {
            var li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "nav-item");

            var a = new HtmlGenericControl("a");
            a.Attributes.Add("class", "nav-link");
            a.Attributes.Add("href", url);
            a.InnerText = texto;

            li.Controls.Add(a);
            navItems.Controls.Add(li);
        }

        private void AgregarUsuario(string texto, string url)
        {
            
        }
    }
}