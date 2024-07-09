using LAB_Arena.DAL;
using System;
using System.Collections.Generic;
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
            string backupFileName = BackupData.BackupDatabase();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ASG_backup.bak");
            Response.TransmitFile(backupFileName);
            Response.End();
        }

        protected void Restaurar_Click(object sender, EventArgs e)
        {

        }
    }
}