using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.BE
{
    public class Ganador
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private Usuario usuario;

        public Usuario Usurario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private Sorteo sorteo;

        public Sorteo Sorteo
        {
            get { return sorteo; }
            set { sorteo = value; }
        }

        private int dv;

        public int DV
        {
            get { return dv; }
            set { dv = value; }
        }



    }
}