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
    public class Ganador
    {
        Acceso acceso = new Acceso();
        BLL.Usuario gUsu = new BLL.Usuario();
        BLL.Sorteo gSort = new BLL.Sorteo();

        public BE.Ganador Convertir(DataRow registro)
        {
            BE.Ganador m = new BE.Ganador();
            m.ID = int.Parse(registro["idGanador"].ToString());
            m.Usurario = gUsu.Obtener(int.Parse(registro["idUsuario"].ToString()));
            m.Sorteo = gSort.Obtener(int.Parse(registro["idSorteo"].ToString()));
            m.DV = int.Parse(registro["DV"].ToString());
            return m;
        }


        public List<BE.Ganador> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_GANADORES");
            acceso.Cerrar();

            List<BE.Ganador> ganadores = new List<BE.Ganador>();
            foreach (DataRow registro in tabla.Rows)
            {
                ganadores.Add(Convertir(registro));
            }

            return ganadores;
        }


        public int DvGan(BE.Ganador entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id", entidad.ID));
            parametros.Add(acceso.CrearParametro("@dv", entidad.DV));
            acceso.Abrir();
            int res = acceso.Escribir("GAN_DV", parametros);
            acceso.Cerrar();
            return res;
        }

        public int EliminarReg(BE.Ganador entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id", entidad.ID));
            acceso.Abrir();
            int res = acceso.Escribir("GAN_DEL", parametros);
            acceso.Cerrar();
            return res;
        }

    }
}