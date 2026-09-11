using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenRuleta
{
    internal class Ruleta
    {
        private Random random;
        public Ruleta()
        {
            random = new Random();
        }

        private string ObtenerColor(int numero)
        {
            if (numero == 0)
            {
                return "Sin color"; //<- un numero no valido
            }
            int[] negros = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            foreach (int numeroNegro in negros)
            {
                if (numero == numeroNegro)
                {
                    return "Negro";
                }
            }
            return "Rojo";
        }
        private string ParOImpar(int numero)
        {
            if (numero == 0)
            {
                return "No valido";
            }
            if (numero % 2 == 0)
            {
                return "Par";
            }
            return "Impar";
        }
        //agregar una manera de utilizar random que tambien guarde los datos para el historial
    }
}
