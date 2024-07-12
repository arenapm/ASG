using ASG.DAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Policy;

namespace LAB_Arena.DAL
{
    public class BackupData
    {
        public static string BackupDatabase()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\";
            string name = "ASG_" + DateTime.Now.ToFileTime() + ".bak";

            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BackupDatabase";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Directory", directory);
            cmd.Parameters.AddWithValue("@Name", name);

            con.ExecNonReader(cmd);

            return name;
        }

        public static void RestoreDatabase(string file)
        {
            SqlConnection conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True");
            string db = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Database.mdf";

            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "USE [master] " +
                $"ALTER DATABASE [{db}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                $"RESTORE DATABASE [{db}] FROM  DISK = N'{file}' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 5 " +
                $"ALTER DATABASE [{db}] SET MULTI_USER";
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la restauración: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            
            GC.Collect();
        }
    }
}