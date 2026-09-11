using System;
using System.Collections.Generic;
using System.Text;
namespace ExamenRuleta
{
    internal class Giro
    {
        public Giro(int numero, string color, string paroImpar)
        {
            Numero = numero;
            Color = color;
            ParoImpar = paroImpar;
        }

        public int Numero { get; set; }
        public string Color { get; set; }
        public string ParoImpar { get; set; }

        public override string ToString()
        {
            //Sobreescribimos este to string de forma diferente
            return $"Numero: {Numero} | Color: {Color} | Par o Impar: {ParoImpar}";
        }
    }
}
