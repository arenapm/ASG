using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ASG.Servicios
{
    public class Grupo:Permiso
    {
        List<Permiso> permisos = new List<Permiso>();
        public List<Permiso> Permisos
        {
            get { return permisos; }

        }
        public override bool Validar(Permiso p)
        {
            bool encontrado = false;
            int i = 0;

            while (i < permisos.Count && !encontrado)
            {
                encontrado = permisos[i].Validar(p);
                i++;
            }
            return encontrado;
        }
    }
}