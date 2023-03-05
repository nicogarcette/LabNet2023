using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Terminal {
    public class Program {
        static void Main(string[] args) {

            Console.WriteLine("\n---------------Terminal---------------");
            Console.WriteLine("\nSe requiere registrar los pasajeros de los 5 Omnibus y 5 taxis en circulacion.");

            List<TransportePublico> transportePublicos = new List<TransportePublico>();

            bool entrar = false;

            int total = 0, countT = 0, countB = 0; 

            while (!entrar) {

                int opc = validarOpc();

                if (opc == 1 && countT < 5) {
                    countT++;
                    total++;
                    addTaxi(ref transportePublicos);
                    mensaje("Taxi",countT);

                } else if (opc == 2 && countB < 5) {
                    countB++;
                    total++;
                    addOmnibus(ref transportePublicos);
                    mensaje("Bondi", countB);
                }

                if (total == 10) {
                    entrar = true;
                }
            }

            foreach (var transporte in transportePublicos) {
                transporte.Avanzar();
            }
            Console.WriteLine("\n....accidente en mitre y josePerez\n");
            foreach (var transporte in transportePublicos) {
                transporte.Detenerse();
            }

            Console.ReadKey();
        }
        public static int controlException() {
            int opc = 0;

            try {
                opc = int.Parse(Console.ReadLine());
            } catch (FormatException) {
                Console.WriteLine("** Solo numeros **");
            } catch (OverflowException) {
                Console.WriteLine("** Numero fuera del limite **");
            }

            return opc;
        }
        public static int validarOpc() {
            int opc = 0;
            bool valido = false;

            while (!valido) {
                Console.WriteLine("\n1-ingresar taxi\n2-ingresar bondi\n");

                opc = controlException();

                if (opc > 0 && opc < 3) {
                    valido = true;
                } else {
                    Console.WriteLine("Ingrese una opcion correcta");
                }
            }
            return opc;
        }
        public static int validarPasajerosOmnibus() {
            bool entrar = false;
            int pasajero = 0;

            while (!entrar) {
                pasajero = controlException();

                if (pasajero > 0 && pasajero < 101) {
                    entrar = true;
                } else {
                    Console.Write("Limite de pasajeros(100): ");
                }
            }
            return pasajero;
        }
        public static int validarPasajerosTaxi() {
            bool entrar = false;
            int pasajero = 0;
            while (!entrar) {
                pasajero = controlException();

                if (pasajero > 0 && pasajero < 5) {
                    entrar = true;
                } else {
                    Console.Write("Limite de pasajeros(4): ");
                }
            }
            return pasajero;

        }
        public static void addOmnibus(ref List<TransportePublico> lista) {

            Console.Write("Ingrese pasajeros:");
            int pasajeros = validarPasajerosOmnibus();
            lista.Add(new Omnibus(pasajeros));
        }
        public static void addTaxi(ref List<TransportePublico> lista) {

            Console.Write("Ingrese pasajeros:");
            int pasajeros = validarPasajerosTaxi();
            lista.Add(new Taxi(pasajeros));
        }
        public static void mensaje(string m,int cont) { 
            string msj = cont == 5 ? $"5 {m} ingresados.No podra ingresar mas!" : $"Ingreso de {m} exitoso!";
            Console.WriteLine(msj);
        }
    }
}
