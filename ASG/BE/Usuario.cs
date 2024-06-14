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

        public List<Permiso> permisos = new List<Permiso>();

        public List<Permiso> Permisos
        {
            get { return permisos; }
        }
    }
}