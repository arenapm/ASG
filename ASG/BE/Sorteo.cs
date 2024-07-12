using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.BE
{
    public class Sorteo
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private Usuario creador;

        public Usuario Creador
        {
            get { return creador; }
            set { creador = value; }
        }

        private string premio;

        public string Premio
        {
            get { return premio; }
            set { premio = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string desc;

        public string Descripcion
        {
            get { return desc; }
            set { desc = value; }
        }

        private int cantPart;

        public int CantPart
        {
            get { return cantPart; }
            set { cantPart = value; }
        }

        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private int dv;

        public int DV
        {
            get { return dv; }
            set { dv = value; }
        }



    }
}