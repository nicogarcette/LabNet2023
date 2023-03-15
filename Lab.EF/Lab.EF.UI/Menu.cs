using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI {
    public class Menu {

        public virtual void Access() {

            string menuOptions = "---NorthWind db---\n----Menu Tablas-\n------- 1- Categorias\n------- 2- Empleados\n------- 0- Salir";
            bool exit = false;

            while (!exit) {

                ShowOptions(menuOptions);
                string opc = Console.ReadLine();

                switch (opc) {

                    case "0":
                        exit = true;
                        Console.WriteLine("\nApagando el sistema...");
                        break;

                    case "1":
                        CategoryMenu category = new CategoryMenu();
                        category.Access();
                        break;

                    case "2":
                        EmployeeMenu employee = new EmployeeMenu();
                        employee.Access();
                        break;

                    default:
                        Console.WriteLine("\nIngrese una opcion valida!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void ShowOptions(string opc) {

            Console.Clear();
            Console.WriteLine(opc);
            Console.Write("\nIngrese opc:");
        }
    }
}
