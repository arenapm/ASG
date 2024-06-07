using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ASG.DAL;
using ASG.BE;
using ASG.Servicios;

namespace ASG.BLL
{
    public class Usuario
    {
        UsuarioData mp_usuario = new UsuarioData();

        public BE.Usuario buscarUsuario(string usr,string pwd)
        {
            return mp_usuario.Obtener(usr, pwd);
        }

        public bool Validar(BE.Usuario us,Permiso p)
        {
            bool encontrado = false;
            int i = 0;

            while (i < us.permisos.Count && !encontrado)
            {
                encontrado = us.permisos[i].Validar(p);
                i++;
            }
            return encontrado;
        }
    }
}