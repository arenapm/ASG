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
    public class Acceso
    {
        private SqlConnection cn;
        private SqlTransaction tx;
        public void Abrir()
        {
            cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            cn.Open();

        }
        public void Cerrar()
        {
            cn.Close();
            cn = null;
            GC.Collect();
        }

        public void IniciarTX()
        {
            tx = cn.BeginTransaction();

        }


        public void ConfirmarTx()
        {
            tx.Commit();
            tx = null;

        }
        public void RollbackTx()
        {
            tx.Rollback();
            tx = null;
        }


        private SqlCommand CrearComando(string sp, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }
            if (tx != null)
            {
                cmd.Transaction = tx;

            }
            return cmd;

        }

        public DataTable Leer(string sp, List<SqlParameter> parametros = null)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = CrearComando(sp, parametros);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            da = null;
            return tabla;

        }

        public int LeerEscalar(string sp, List<SqlParameter> parametros = null)
        {
            int resultado;
            SqlCommand cmd = CrearComando(sp, parametros);
            try
            {
                resultado = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            { resultado = -1; }
            return resultado;

        }


        public int Escribir(string sp, List<SqlParameter> parametros = null)
        {
            int resultado;
            SqlCommand cmd = CrearComando(sp, parametros);
            try
            {
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                resultado = -1; 
            }
            return resultado;

        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, float valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Single;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, DateTime valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.DateTime;
            return parametro;
        }
    }
}
