using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ASG.BE;
using ASG.BLL;

namespace ASG.DAL
{
    public class Sorteo
    {
        Acceso acceso = new Acceso();
        BLL.Usuario gUsu = new BLL.Usuario();
        public BE.Sorteo Convertir(DataRow registro)
        {
            BE.Sorteo m = new BE.Sorteo();
            m.ID = int.Parse(registro["idSorteo"].ToString());
            m.Nombre =registro["Nombre"].ToString();
            m.Descripcion = registro["descripcion"].ToString();
            m.Creador = gUsu.Obtener(int.Parse(registro["idCreador"].ToString()));
            m.CantPart = int.Parse(registro["CantParticipantes"].ToString());
            m.Valor = int.Parse(registro["valor"].ToString());
            m.Premio = registro["Premio"].ToString();
            m.DV = int.Parse(registro["DV"].ToString());
            return m;
        }


        public int insertar(BE.Sorteo entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@nombre", entidad.Nombre));
            parametros.Add(acceso.CrearParametro("@desc", entidad.Descripcion));
            parametros.Add(acceso.CrearParametro("@crea", entidad.Creador.ID));
            parametros.Add(acceso.CrearParametro("@cant", entidad.CantPart));
            parametros.Add(acceso.CrearParametro("@valor", entidad.Valor));
            parametros.Add(acceso.CrearParametro("@premio", entidad.Premio));
            parametros.Add(acceso.CrearParametro("@dv", entidad.DV));
            acceso.Abrir();
            int res = acceso.Escribir("INSERTAR_SORT", parametros);
            acceso.Cerrar();
            return res;
        }

        public List<BE.Sorteo> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_SORT");
            acceso.Cerrar();

            List<BE.Sorteo> sorteos = new List<BE.Sorteo>();
            foreach (DataRow registro in tabla.Rows)
            {
                sorteos.Add(Convertir(registro));
            }

            return sorteos;
        }


        public BE.Sorteo Obtener(int id)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM Sorteo WHERE idSorteo='{id}'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = con.ExecReader(cmd);

            BE.Sorteo sort = null;

            if (dt.Rows.Count > 0)
            {
                sort = new BE.Sorteo();

                sort.ID = (int)dt.Rows[0][0];
                sort.Creador = gUsu.Obtener((int)dt.Rows[0][1]);
                sort.Nombre = (string)dt.Rows[0][2];
                sort.CantPart = (int)dt.Rows[0][4];
                sort.Descripcion = (string)dt.Rows[0][5];
                sort.Valor = (int)dt.Rows[0][6];
                sort.DV = (int)dt.Rows[0][7];
            }

            return sort;
        }

        public int MaxId()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT MAX(idSorteo) FROM Sorteo";
            cmd.CommandType = CommandType.Text;

            DataTable dt = con.ExecReader(cmd);
            int mId=0;
            if (dt.Rows.Count > 0)
            {
                mId = (int)dt.Rows[0][0];
            }
            return mId;
        }

        public int DvSort(BE.Sorteo entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id", entidad.ID));
            parametros.Add(acceso.CrearParametro("@dv", entidad.DV));
            acceso.Abrir();
            int res = acceso.Escribir("SORT_DV", parametros);
            acceso.Cerrar();
            return res;
        }

        public int EliminarReg(BE.Sorteo entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id", entidad.ID));
            acceso.Abrir();
            int res = acceso.Escribir("SORT_DEL", parametros);
            acceso.Cerrar();
            return res;
        }

    }
}