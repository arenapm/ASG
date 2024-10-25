using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.BLL
{
    public class Sorteo
    {
        DAL.Sorteo mp_sorteo = new DAL.Sorteo();

        public int insertar(BE.Sorteo sort)
        {
            return mp_sorteo.insertar(sort);
        }

        public BE.Sorteo Obtener(int id)
        {
            return mp_sorteo.Obtener(id);
        }


        public List<BE.Sorteo> Listar()
        {
            return mp_sorteo.Listar();
        }

        public List<BE.Sorteo> ListarSortUs(BE.Usuario us)
        {
            return mp_sorteo.ListarSortUs(us);
        }

        public int MaxId()
        {
            return mp_sorteo.MaxId();
        }


    }
}