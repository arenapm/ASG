using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASG.BLL
{
    public class Carrito
    {
        public void calcularTotal(BE.Carrito car)
        {
            int sum = 0;
            foreach(BE.Sorteo s in car.Inscripciones)
            {
                sum += s.Valor;
            }
            car.precTotal = sum;
        }
    }
}