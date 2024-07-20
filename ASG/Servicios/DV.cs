using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.Servicios
{
    public class DV
    {
        private List<BE.Sorteo> sortDV = new List<BE.Sorteo>();

        public List<BE.Sorteo> SortDV
        {
            get { return sortDV ; }
        }

        private List<BE.Ganador> ganDV = new List<BE.Ganador>();

        public List<BE.Ganador> GanDV
        {
            get { return ganDV; }
        }

        DAL.Sorteo gSort = new DAL.Sorteo();
        DAL.Ganador gGan = new DAL.Ganador();
        List<BE.Sorteo> sorteos;
        List<BE.Ganador> ganadores;

        public int calcularDV(BE.Sorteo sort)
        {
            string cadena = sort.ID.ToString() + sort.Descripcion + sort.Premio + sort.CantPart.ToString() + sort.Creador.ID.ToString() + sort.Nombre + sort.Valor.ToString();
            int suma = 0;
            foreach (char c in cadena)
            {
                suma += (int)c;
            }
            return suma%10;
        }

        public int calcularDV(BE.Ganador ga)
        {
            string cadena = ga.Usurario.ID.ToString() + ga.Sorteo.ID.ToString() + ga.ID.ToString();
            int suma = 0;
            foreach (char c in cadena)
            {
                suma += (int)c;
            }
            return suma % 10;
        }

        public int verificarDVs()
        {
            int verificador = 0;

            ganadores = null;
            sorteos = null;
            ganadores = gGan.Listar();
            sorteos = gSort.Listar();

            foreach(BE.Ganador gan in ganadores)
            {
                int dv = calcularDV(gan);

                if (dv != gan.DV)
                {
                    ganDV.Add(gan);
                }

            }

            foreach (BE.Sorteo sort in sorteos)
            {
                int dv = calcularDV(sort);

                if (dv != sort.DV)
                {
                    sortDV.Add(sort);
                }

            }

            if(ganDV.Count>0 || sortDV.Count > 0)
            {
                verificador = -1;
            }
            else
            {
                verificador = 0;
            }
            return verificador;
        }

        public int SolucionarDV(BE.Sorteo sort)
        {
            return gSort.DvSort(sort);
        }

        public int SolucionarDV(BE.Ganador gan)
        {
            return gGan.DvGan(gan);
        }

        public int EliminarReg(BE.Sorteo sort)
        {
            return gSort.EliminarReg(sort);
        }
        public int EliminarReg(BE.Ganador gan)
        {
            return gGan.EliminarReg(gan);
        }

    }
}