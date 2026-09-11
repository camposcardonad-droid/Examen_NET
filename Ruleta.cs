using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenRuleta
{
    internal class Ruleta
    {
        //https://learn.microsoft.com/es-es/dotnet/api/system.random?view=net-10.0
        //de ahi obtuve la funcion random al buscar como hacer que la ruleta sea aleatoria
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
        public Giro LETSGOGAMBLING()
        {
            int numero = random.Next(0, 37);
            string color = ObtenerColor(numero);
            string paridad = ParOImpar(numero);
            return new Giro(numero, color, paridad);
        }
    }
}
