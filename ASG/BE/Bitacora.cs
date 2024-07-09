using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.BE
{
    public class Bitacora
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string desc;

        public string DESC
        {
            get { return desc; }
            set { desc = value; }
        }

        private int crit;

        public int CRIT
        {
            get { return crit; }
            set { crit = value; }
        }

        private DateTime date;

        public DateTime DATE
        {
            get { return date; }
            set { date = value; }
        }




    }
}