using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASG.BE;
using ASG.DAL;

namespace ASG.BLL
{
    public class Bitacora
    {
        DAL.Bitacora mp_bit = new DAL.Bitacora();
        public int insertar(BE.Bitacora bi)
        {
           return mp_bit.insertar(bi);

        }



        public List<BE.Bitacora> Listar()
        {
            return mp_bit.Listar();
        }
    }
}