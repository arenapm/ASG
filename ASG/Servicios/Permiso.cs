using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ASG.Servicios
{
    public class Permiso
    {
        public Permiso()
        {

        }
        public Permiso(int i)
        {
            id = i;
        }
        public Permiso(int i, string n)
        {
            id = i;
            this.nombre = n;
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public virtual bool Validar(Permiso p)
        {
            return p.id == this.id;

        }

        public override string ToString()
        {
            return id.ToString() + " " + nombre;
        }
    }
}