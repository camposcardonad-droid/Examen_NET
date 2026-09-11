using System.Security.Cryptography.X509Certificates;

namespace ExamenRuleta
{
    //NOTA IMPOTANTE: una vez hizo los metodos me di cuenta que podia hacerlos en Apuesta para ya solo
    //invocarlos pero por la cantidad de tiemo que me queda quizas sea demasiado reacomodo
    internal class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador = new Jugador();
            Ruleta ruleta = new Ruleta();
            bool jugando = true;
            Console.WriteLine("Juego de Ruleta");
            Console.WriteLine("===============");
            Console.WriteLine($"Dinero Inicial: {jugador.Dinero}");
            while (jugando && jugador.Dinero >  0)
            {
                Console.WriteLine();
                //Asi tenemos la idea de cuanto nos queda
                Console.WriteLine("Dinero disponible: $" + jugador.Dinero);
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Apostar a un numero");
                Console.WriteLine("2. Apostar a un color");
                Console.WriteLine("3. Apostar a par o impar");
                Console.WriteLine("4. Ver historial");
                Console.WriteLine("5. Retirarse");
                Console.WriteLine("=====================================");
                Console.Write("Selecciona una opcion: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        ApostarNumero(jugador, ruleta);
                        break;
                    case "2":
                        ApostarColor(jugador, ruleta);
                        break;
                    case "3":
                        ApostarParidad(jugador, ruleta);
                        break;
                    case "4":
                        jugador.MostrarHistorial();
                        break;
                    case "5":
                        jugando = false;
                        Console.WriteLine();
                        Console.WriteLine("Te retiraste");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
            Console.WriteLine();
            if (jugador.Dinero == 0)
            {
                Console.WriteLine("Te has quedado sin dinero");
                Console.WriteLine("Fin del Juego");
            }
            Console.WriteLine($"Dinero final: {jugador.Dinero}$");
            decimal resultado = jugador.Dinero - 300;
            if (resultado > 0)
            {
                Console.WriteLine($"Ganaste: {resultado}$");
            }
            else if (resultado < 0)
            {
                resultado = resultado * -1;
                Console.WriteLine($"Perdiste: {resultado}$");
            }
            else
            {
                Console.WriteLine("Terminaste con el mismo dinero inicial");
            }
            Console.WriteLine();
            Console.WriteLine("Fin Del Juego");
        }
        //Vemos si cada apuesta que hagamos es valida
        static Apuesta CrearApuesta(Jugador jugador)
        {
            Console.WriteLine("Aclaracion: Deber se dijito de 10!");
            Console.WriteLine("Cantidad a apostar: ");
            decimal cantidad;
            if (!decimal.TryParse(Console.ReadLine(), out cantidad))
            {
                Console.WriteLine("Caracter Invalido");
                return null;
            }
            Apuesta apuesta = new Apuesta(cantidad);
            if (!apuesta.EsValida(jugador.Dinero))
            {
                Console.WriteLine("La apuesta no es valida.");
                return null;
            }
            return apuesta;
        }
        static void ApostarNumero(Jugador jugador, Ruleta ruleta)
        {
            Console.WriteLine();
            Console.WriteLine("Apuesta un Numero entre entre el 0 y el 36: ");
            Console.WriteLine();
            int numero;
            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Caracter no Valido");
                return;
            }
            if (numero < 0 || numero > 36)
            {
                Console.WriteLine("Numero No valido");
                return;
            }
            Apuesta apuesta = CrearApuesta(jugador);
            if (apuesta == null)
            {
                return;
            }
            jugador.RestarDinero(apuesta.Cantidad);
            Giro giro = ruleta.LETSGOGAMBLING();
            jugador.AgregarGiro(giro);
            Console.WriteLine();
            Console.WriteLine(giro);
            if (giro.Numero == numero) 
            {
                decimal premio = apuesta.ApuestaNumero();
                jugador.AgregarDinero(premio);
                Console.WriteLine("¡GANASTE!");
                Console.WriteLine($"Premio:{premio} $");
            }
            else
            {
                Console.WriteLine("Suerte para la proxima!");
            }
        }
        static void ApostarColor(Jugador jugador, Ruleta ruleta)
        {
            Console.WriteLine();
            Console.WriteLine("Selecciona el color por el que apostaras:");
            Console.WriteLine("1. Rojo");
            Console.WriteLine("2. Negro");
            string opcion = Console.ReadLine();
            string colorElegido;
            if (opcion == "1")
            {
                colorElegido = "Rojo";
            }
            else if (opcion == "2")
            {
                colorElegido = "Negro";
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
                return;
            }
            Apuesta apuesta = CrearApuesta(jugador);
            if (apuesta == null)
            {
                return;
            }
            jugador.RestarDinero(apuesta.Cantidad);
            Giro giro = ruleta.LETSGOGAMBLING();
            jugador.AgregarGiro(giro);
            Console.WriteLine();
            Console.WriteLine(giro);
            if (giro.Color == colorElegido)
            {
                decimal premio = apuesta.ApuestaColor();
                jugador.AgregarDinero(premio);
                Console.WriteLine("¡GANASTE!");
                Console.WriteLine($"Premio:{premio} $");
            }
            else
            {
                Console.WriteLine("99% de las personas se retiran antes de ganar grande eres tu parte del monton?");
            }
        }
        static void ApostarParidad(Jugador jugador, Ruleta ruleta)
        {
            Console.WriteLine();
            Console.WriteLine("¿Par o Impar?");
            Console.WriteLine("1. Par");
            Console.WriteLine("2. Impar");
            string opcion = Console.ReadLine();
            string paridadElegida;
            if (opcion == "1")
            {
                paridadElegida = "Par";
            }
            else if (opcion == "2")
            {
                paridadElegida = "Impar";
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
                return;
            }
            Apuesta apuesta = CrearApuesta(jugador);
            if (apuesta == null)
            {
                return;
            }
            jugador.RestarDinero(apuesta.Cantidad);
            Giro giro = ruleta.LETSGOGAMBLING();
            jugador.AgregarGiro(giro);
            Console.WriteLine();
            Console.WriteLine(giro);
            if (giro.ParoImpar == paridadElegida)
            {
                decimal premio = apuesta.ApuestaPar();
                jugador.AgregarDinero(premio);
                Console.WriteLine("¡GANASTE!");
                Console.WriteLine($"Premio: {premio}$");
            }
            else
            {
                Console.WriteLine("ahi se fue el salario del mes...");
            }
        }
    }
}
