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
    }
}