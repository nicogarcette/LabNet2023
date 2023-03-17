using Lab.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.UI {
    public class Menu {
        
        public virtual void Access() {

            string menuOptions = "---NorthWind db---\n----Menu Ejercicios LINQ-\n 1/2/3/4/5/6/7/8/9/10/11/12/13\n 0- Salir";
            bool exit = false;
            Exercises exercises = new Exercises();

            while (!exit) {
                ShowOptions(menuOptions);
                string opc = Console.ReadLine();

                switch (opc) {

                    case "0":
                        exit = true;
                        Console.WriteLine("\nApagando el sistema...");
                        break;
                    case "1":
                        exercises.Exercise1();
                        break;
                    case "2":
                        exercises.Exercise2();
                        break;
                    case "3":
                        exercises.Exercise3();
                        break;
                    case "4":
                        exercises.Exercise4();
                        break;
                    case "5":
                        exercises.Exercise5();
                        break;
                    case "6":
                        exercises.Exercise6();
                        break;
                    case "7":
                        exercises.Exercise7();
                        break;
                    case "8":
                        exercises.Exercise8();
                        break;
                    case "9":
                        exercises.Exercise9();
                        break;
                    case "10":
                        exercises.Exercise10();
                        break;
                    case "11":
                        exercises.Exercise11();
                        break;
                    case "12":
                        exercises.Exercise12();
                        break;
                    case "13":
                        exercises.Exercise13();
                        break;

                    default:
                        Console.WriteLine("\nIngrese una opcion valida!");
                        Console.ReadLine();
                        break;
                }
                Console.ReadKey();
            }
        }

        public static void ShowOptions(string opc) {

            Console.Clear();
            Console.WriteLine(opc);
            Console.Write("\nIngrese opc:");
        }

    }
}
