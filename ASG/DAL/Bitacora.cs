using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ASG.BE;


namespace ASG.DAL
{
    public class Bitacora
    {

        Acceso acceso = new Acceso();

        public  BE.Bitacora Convertir(DataRow registro)
        {
            BE.Bitacora m = new BE.Bitacora();
            m.ID = int.Parse(registro["id"].ToString());
            m.DESC = registro["descripcion"].ToString();
            m.CRIT = int.Parse(registro["criticidad"].ToString());
            m.DATE = DateTime.Parse(registro["fecha"].ToString());


            return m;
        }


        public int insertar(BE.Bitacora entidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@desc", entidad.DESC));
            parametros.Add(acceso.CrearParametro("@crit", entidad.CRIT));
            parametros.Add(acceso.CrearParametro("@dat", DateTime.Now));
            acceso.Abrir();
            int res = acceso.Escribir("INSERTAR_BIT", parametros);
            acceso.Cerrar();
            return res;
        }

        public List<BE.Bitacora> Listar()
        {
            acceso.Abrir();
            DataTable tabla = acceso.Leer("LISTAR_BIT");
            acceso.Cerrar();

            List<BE.Bitacora> bitacoras = new List<BE.Bitacora>();
            foreach (DataRow registro in tabla.Rows)
            {
                bitacoras.Add(Convertir(registro));
            }

            return bitacoras;
        }

    }

 }