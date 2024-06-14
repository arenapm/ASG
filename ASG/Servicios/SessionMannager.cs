using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ASG.BE;

namespace ASG.Servicios
{
    public class SessionMannager
    {
        private static object _lock = new Object();
        private static SessionMannager _session;

        private string idioma;

        public string Idioma
        {
            get { return idioma; }
            set { idioma = value; }
        }
        public BE.Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        public static SessionMannager GetInstance
        {
            get
            {
                return _session;
            }
        }

        public static void Login(BE.Usuario usuario)
        {

            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new SessionMannager();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }


        }

        private SessionMannager()
        {

        }

    }
}