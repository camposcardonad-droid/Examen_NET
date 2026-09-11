using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenRuleta
{
    internal class Apuesta
    {
        public Apuesta(decimal cantidad)
        {
            Cantidad = cantidad;
        }

        public decimal Cantidad { get; set;  }
        public bool EsValida(decimal cantidadActual)
        {
            //cantidadActual = cantidad de dinero que tenemos disponible
            if (Cantidad == 0)
            {
                return false;
            }
            if (Cantidad % 10 != 0)
            {
                return false;
            }
            if (Cantidad > cantidadActual)
            {
                return false;
            }
            return true;
        }
        public decimal ApuestaNumero()
        {
            decimal resultado = Cantidad * 10;
            return resultado;
        }
        public decimal ApuestaColor()
        {
            decimal resultado = Cantidad * 5;
            return resultado;
        }
        public decimal ApuestaPar()
        {
            decimal resultado = Cantidad * 2;
            return resultado;
        }
        public override string ToString()
        {
            return $"Apuesta Actual: {Cantidad}$";
        }
    }
}
