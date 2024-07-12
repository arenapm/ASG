using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ASG.BE;


namespace ASG.DAL
{
    public class usuario
    {
        Acceso acceso = new Acceso();


        public BE.Usuario Convertir(DataRow registro)
        {
            BE.Usuario m = new BE.Usuario();
            m.ID = int.Parse(registro["ID"].ToString());
            m.Login = registro["LOGIN"].ToString();
            m.Login = registro["PASSWORD"].ToString();
            return m;
        }
        public int insertar(BE.Usuario entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@us", entidad.Login));
            parametros.Add(acceso.CrearParametro("@pwd", entidad.Password));
            acceso.Abrir();
            int res = acceso.Escribir("INSERTAR_US", parametros);
            acceso.Cerrar();
            return res;
        }


        public Usuario Obtener(int id)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM USUARIO WHERE ID='{id}'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = con.ExecReader(cmd);

            Usuario unUsuario = null;

            if (dt.Rows.Count > 0)
            {
                unUsuario = new Usuario();

                unUsuario.ID = (int)dt.Rows[0][0];
                unUsuario.Login = (string)dt.Rows[0][1];
                unUsuario.Password = (string)dt.Rows[0][2];
            }

            return unUsuario;
        }

        public bool ObtenerBloq(int id)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM Bloqueados WHERE id_usuario='{id}'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = con.ExecReader(cmd);

            bool bloq = false;

            if (dt.Rows.Count > 0)
            {
                 bloq = true;
            }

            return bloq;
        }

        public int Bloquear(BE.Usuario us)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@pwd", us.ID));
            acceso.Abrir();
            int res = acceso.Escribir("BLOQ_US", parametros);
            acceso.Cerrar();
            return res;
        }

    }

}
