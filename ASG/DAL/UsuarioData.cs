using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ASG.BE;

namespace ASG.DAL
{
    public class UsuarioData
    {
        public  Usuario Obtener(string user, string pass)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM USUARIO WHERE LOGIN='{user}' AND PASSWORD='{pass}'";
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

    }
}