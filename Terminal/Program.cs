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
            int  countT = 0, countB = 0; 

            while (!entrar) {

                int opc = ValidarOpc();

                if (opc == 1 && countT < 5) {
                    countT++;
                    AddTaxi(ref transportePublicos);
                    Mensaje("Taxi", countT);

                } else if (opc == 2 && countB < 5) {
                    countB++;
                    AddOmnibus(ref transportePublicos);
                    Mensaje("Bondi", countB);
                }

                if (countB == 5 && countT == 5) entrar = true;
            }

            TransporteFuncionando(ref transportePublicos);

            Console.ReadKey();
        }
        public static int ControlException() {
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
        public static int ValidarOpc() {
            int opc = 0;
            bool valido = false;

            while (!valido) {
                Console.WriteLine("\n1-ingresar taxi\n2-ingresar bondi\n");

                opc = ControlException();

                if (opc > 0 && opc < 3) {
                    valido = true;
                } else {
                    Console.WriteLine("Ingrese una opcion correcta");
                }
            }
            return opc;
        }
        public static int ValidarPasajero(int limite) {
            bool entrar = false;
            int pasajero = 0;
            while (!entrar) {
                pasajero = ControlException();

                if (pasajero > 0 && pasajero <= limite) {
                    entrar = true;
                } else {
                    Console.Write($"Limite de pasajeros({limite}): ");
                }
            }
            return pasajero;
        }
        public static void AddOmnibus(ref List<TransportePublico> lista) {

            Console.Write("Ingrese pasajeros:");
            int pasajeros = ValidarPasajero(100);
            lista.Add(new Omnibus(pasajeros));
        }
        public static void AddTaxi(ref List<TransportePublico> lista) {

            Console.Write("Ingrese pasajeros:");
            int pasajeros = ValidarPasajero(4);
            lista.Add(new Taxi(pasajeros));
        }
        public static void Mensaje(string m,int cont) { 
            string msj = cont == 5 ? $"5 {m} ingresados.No podra ingresar mas!" : $"Ingreso de {m} exitoso!";
            Console.WriteLine(msj);
        }
        public static void TransporteFuncionando(ref List<TransportePublico> transportes) {

            foreach (var transporte in transportes) {

                Console.WriteLine(transporte.Avanzar());
            }

            Console.WriteLine("\n....accidente en mitre y josePerez\n");

            foreach (var transporte in transportes) {
                Console.WriteLine(transporte.Detenerse());
            }

        }
    }
}
