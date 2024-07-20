using LAB_Arena.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASG.BE;
using ASG.BLL;
using ASG.Servicios;
namespace ASG
{
    public partial class Respaldos : System.Web.UI.Page
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
                if (!gUsu.Validar(us, p))
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

        protected void Respaldar_Click(object sender, EventArgs e)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\";
            string name = BackupData.BackupDatabase();
            string backupFilePath = directory + name;
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={name}");
            Response.TransmitFile(backupFilePath);
            Response.End();
        }

        protected void Restaurar_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    // Guardar el archivo subido en el servidor temporalmente
                    string backupFilePath = Server.MapPath("~/App_Data/" + fileUpload.FileName);
                    fileUpload.SaveAs(backupFilePath);

                    // Restaurar la base de datos desde el archivo subido
                    BackupData.RestoreDatabase(backupFilePath);

                    lblMessage.Text = "Restauración exitosa.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    bi = new BE.Bitacora();
                    bi.DESC = $"El usuario {us.Login} restauro la base de datos";
                    bi.CRIT = 5;
                    gBi.insertar(bi);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error al restaurar la base de datos: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Por favor, seleccione un archivo de backup.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}