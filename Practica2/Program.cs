using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Practica2 {
    public class Program {
        static void Main(string[] args) {
            
            DivideByZero();

            Separate();
            
            DivideTwoNum();

            Separate();
            
            ViewException();

            Separate();
            
            ViewCustomException();
        
            Console.ReadKey();
        }

        public static decimal ConsultarNumero(string mensaje) {
            decimal num = 0;
            bool valido = false;

            while (!valido) {
                Console.Write(mensaje);

                try {
                  
                    num = decimal.Parse(Console.ReadLine());
                    valido = true;  

                } catch (FormatException) {

                    Console.WriteLine("Dale, no lo quieras explotar! solo numeros!");
                
                } catch (OverflowException) {
                
                    Console.WriteLine("Numeros no tan grandes!");

                }
            }

            return num;
        }
        public static void Separate() {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------\n");
            Console.ReadKey();
        }
        public static void DivideByZero() {

            Console.WriteLine("Se puede dividir por 0 ?");
            decimal result;
            decimal num = ConsultarNumero("Ingrese numero:");

            try {

                result = num.DivideBy(0);

            } catch (DivideByZeroException ex) {

                Console.WriteLine($"{ex.Message} No podes dividir por 0. Excepto una persona...");

            } finally {

                Console.WriteLine("*operacion finalizada*");

            }

        }

        public static void DivideTwoNum() {
            
            decimal result;
            Console.WriteLine("Pero estas seguro que no podes dividir por 0?");

            decimal num = ConsultarNumero("Ingrese dividendo:");
            decimal num1 = ConsultarNumero("Ingrese divisor:");

            try {

                result = num.DivideBy(num1);
                Console.WriteLine($"{num} / {num1} = {result}");

            } catch (DivideByZeroException) {

                Console.WriteLine($"jajaj, Solo Chuck Norris divide por cero!");

            }
        }

        public static void ViewException() {

            Logic exc = new Logic();

            try {

                exc.ThrowException();

            } catch (Exception e) {

                Console.WriteLine($"Hola soy {e.GetType().Name}. Aparezco cuando {e.Message}");
            }
        }

        public static void ViewCustomException() {

            Logic exc = new Logic();

            try {

                exc.ThrowMyException();

            } catch (Exception e) {

                Console.WriteLine($"Hola soy {e.GetType().Name}. Aparezco cuando {e.Message}");

            }
        }
    }
}
