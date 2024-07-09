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


    }

}
