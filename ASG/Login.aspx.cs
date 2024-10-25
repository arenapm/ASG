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
        Servicios.DV gdv = new Servicios.DV();
        BE.Bitacora bi;
        BLL.Usuario gUsuario = new BLL.Usuario();
        BLL.Bitacora gBit = new BLL.Bitacora();
        Permiso p = new Permiso(1, "ADMIN");
        Permiso m = new Permiso(2, "MARK");
        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Si el usuario ya esta logeado no deberia de poder entrar por URL, si no esta logeado compruebo inconsistencias
            if (SessionMannager.GetInstance != null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                int incons = gdv.verificarDVs();
                if (incons == -1)
                {
                    Panel3.Visible = true;
                }
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            int incons = gdv.verificarDVs();
            BE.Usuario unUsuario = gUsuario.buscarUsuario(txtUser.Text, txtPass.Text);
            //Si el usuario no existe salta cartel de usuario no existente si existe compruebo si el usuario esta bloqueado por infractor
            if (unUsuario != null)
            {
                bool usBloq = gUsuario.ObtenerBloq(unUsuario.ID);
                //Si el usuario no es un infractor compruebo sus intentos de ingreso, si el usuario esta bloqueado es un infractor no entra
                if (usBloq == false)
                {
                    //Si el usuario tiene 3 o mas intentos no puede entrar tiene que resetear contraseña, sino  compruebo las passowrd
                    if (unUsuario.Intentos >= 3)
                    {
                        Panel2.Visible = true;
                    }
                    else
                    {
                        //Si las passwords coinciden verifico que tipo de usuario es, sino coinciden se le suma 1 intento al usuario
                        if (unUsuario.Password == txtPass.Text)
                        {
                            //Si el usuario es 1 le agrego el permiso de admin
                            if (unUsuario.ID == 1)
                            {
                                unUsuario.Permisos.Add(p);
                            }
                            if (unUsuario.ID == 5)
                            {
                                unUsuario.Permisos.Add(m);
                            }
                            //Si tengo inconsistencias en la base me fijo si el usuario que se logeo es admin, si no hay inconsistencias entra el pibe
                            if (incons == -1)
                            {
                                //Si el usuario es admin lo dejo pasar, sino es admin largo cartel de que estamos trabajando loco
                                if (unUsuario.ID == 1)
                                {
                                    SessionMannager.Login(unUsuario);
                                    bi = new BE.Bitacora();
                                    bi.ID = rnd.Next(1, 100);
                                    bi.DESC = $"El usuario {unUsuario.Login} ingreso al sistema";
                                    bi.CRIT = 1;
                                    gBit.insertar(bi);
                                    gUsuario.reset(unUsuario);
                                    Response.Redirect("Default.aspx");
                                }
                                else
                                {
                                    Panel3.Visible = true;
                                }
                            }
                            else
                            {
                                SessionMannager.Login(unUsuario);
                                bi = new BE.Bitacora();
                                bi.ID = rnd.Next(1, 100);
                                bi.DESC = $"El usuario {unUsuario.Login} ingreso al sistema";
                                bi.CRIT = 1;
                                gBit.insertar(bi);
                                gUsuario.reset(unUsuario);
                                Response.Redirect("Default.aspx");
                            }

                        }
                        else
                        {
                            gUsuario.sumInt(unUsuario);
                            txtLogin.Visible = true;
                        }
                    }
                }
                else
                {
                    Panel1.Visible = true;
                }

            }
            else
            {
                Panel4.Visible = true;
            }
        }
    }
}