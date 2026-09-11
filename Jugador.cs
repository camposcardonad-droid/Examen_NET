using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenRuleta
{
    internal class Jugador
    { 
        public decimal Dinero {  get; set; }
        private List<Giro> historial;

        public Jugador()
        {
            Dinero = 300;
            historial = new List<Giro>();
        }
        public void RestarDinero(decimal cantidad)
        {
            Dinero = Dinero - cantidad;
        }
        public void AgregarDinero(decimal cantidad)
        {
            Dinero = Dinero + cantidad;
        }
        public void AgregarGiro(Giro giro)
        {
            historial.Add(giro);
        }
        public void MostrarHistorial()
        {
            Console.WriteLine();
            Console.WriteLine("Historial");
            Console.WriteLine("=========");
            if (historial.Count == 0)
            {
                Console.WriteLine("Todavia no hay giros");
                return;
            }
            for (int i = 0; i < historial.Count; i++ )
            {
                Console.WriteLine((i + 1) + ". " + historial[i]);
            }
        }
    }
}
