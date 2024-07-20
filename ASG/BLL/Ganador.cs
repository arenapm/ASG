using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASG.BE;
using ASG.DAL;

namespace ASG.BLL
{
    public class Ganador
    {
        DAL.Ganador gGan = new DAL.Ganador();
        public List<BE.Ganador> Listar()
        {
            return gGan.Listar();
        }

        public int CorregirDV(BE.Ganador g)
        {
            return gGan.DvGan(g);
        }

        public int EliminarReg(BE.Ganador g)
        {
            return gGan.EliminarReg(g);
        }

    }
}