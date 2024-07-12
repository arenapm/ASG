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
        DAL.usuario mp_usuario2 = new DAL.usuario();
        DAL.usuario mpu = new DAL.usuario();

        public BE.Usuario buscarUsuario(string usr,string pwd)
        {
            return mp_usuario.Obtener(usr, pwd);
        }

        public BE.Usuario Obtener(int id)
        {
            return mp_usuario2.Obtener(id);
        }

        public bool ObtenerBloq(int id)
        {
            return mp_usuario2.ObtenerBloq(id);
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

        public int insertar(BE.Usuario us)
        {
            return mpu.insertar(us);
        }

        public int Bloquear(BE.Usuario us)
        {
            return mpu.Bloquear(us);
        }
    }
}