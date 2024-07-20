using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASG.Servicios;

namespace ASG.BE
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private int intentos;

        public int Intentos
        {
            get { return intentos; }
            set { intentos = value; }
        }


        public List<Permiso> permisos = new List<Permiso>();

        public List<Permiso> Permisos
        {
            get { return permisos; }
        }
    }
}