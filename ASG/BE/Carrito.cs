using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.BE
{
    public class Carrito
    {
        private List<BE.Sorteo> inscripciones = new List<Sorteo>();

        public List<BE.Sorteo> Inscripciones
        {
            get { return inscripciones; }
            set { inscripciones = value; }
        }

        private double PrecTotal;

        public double precTotal
        {
            get { return PrecTotal; }
            set { PrecTotal = value; }
        }


    }
}