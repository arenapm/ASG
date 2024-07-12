using LAB_Arena.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASG
{
    public partial class Respaldos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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