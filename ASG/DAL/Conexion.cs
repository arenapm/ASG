using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace ASG.DAL
{
    public class Conexion
    {
        private SqlConnection conexion;

        public void Abrir()
        {
            conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }

        public DataTable ExecReader(SqlCommand cmd)
        {
            SqlDataReader reader;
            DataTable dt = new DataTable();

            try
            {
                Abrir();
                cmd.Connection = conexion;
                reader = cmd.ExecuteReader();
                if (reader.HasRows) { dt.Load(reader); };
                Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }

        public void ExecNonReader(SqlCommand cmd)
        {
            try
            {
                Abrir();
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
                Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}