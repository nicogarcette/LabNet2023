using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab.EF.UI {
    public class EmployeeMenu : Menu {

        public override void Access() {
            
            string Opciones = "\n--EMPLEADOS--\nOpciones \n 1-Todos los registros\n 2- Insert\n 3- Delete\n 4- Update \n 0- salir";
            bool exit = false;

            while (!exit) {

                ShowOptions(Opciones);
                string opc = Console.ReadLine();

                switch (opc) {

                    case "0":
                        exit = true;
                        break;
                    case "1":
                        GetAll();
                        break;
                    case "2":
                        InsertEmployee();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        UpdateEmployee();
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida!");
                        break;
                }
               
                Console.ReadKey();
            }
        }

        public void GetAll() {

            IABMLogic<Employees> _employeeLogic = new EmployeeLogic();

            Console.WriteLine("\nConsulta: Empleados\nID | NAME");
    
            foreach (var emp in _employeeLogic.GetAll()) {

                Console.WriteLine($" {emp.EmployeeID} | {emp.LastName}, {emp.FirstName}");
            }
        }

        public void InsertEmployee() {

            IABMLogic<Employees> _employeeLogic = new EmployeeLogic();
            Employees employee = new Employees();
            ValidData data = new ValidData();

            Console.Write("Ingrese nombre: ");
            string name = data.AskForString("nombre");
            employee.FirstName = name;

            Console.Write("Ingrese Apellido: ");
            string lastName = data.AskForString("apellido");
            employee.LastName = lastName;

            try {
                _employeeLogic.Insert(employee);
                Console.WriteLine("Empleado agregado!");

            } catch(Exception ex) {

                Console.WriteLine($"Error:{ex.Message}");
            }

        }

        public void DeleteEmployee() {

            IABMLogic<Employees> _employeeLogic = new EmployeeLogic();
            ValidData data = new ValidData();

            Console.WriteLine("Ingrese ID del usuario a eliminar");
            int id = data.AskForNumber();

            try {
                _employeeLogic.Delete(id);
                Console.WriteLine("Empleado eliminada");

            } catch (ArgumentNullException ex) {
                Console.WriteLine($"{ex.ParamName}. No se encuentra en los registros.");

            } catch (DbUpdateException) {
                Console.WriteLine("No es posible eliminar el registro, ya que atenta contra la integridad de los datos vinculados al mismo.");

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateEmployee() {

            IABMLogic<Employees> _employeeLogic = new EmployeeLogic();
            Employees employee = new Employees();
            ValidData data = new ValidData();

            Console.WriteLine("Ingrese ID del usuario a modificar");
            int id = data.AskForNumber();
            employee.EmployeeID = id;

            Console.Write("Ingrese nombre: ");
            string name = data.AskForString("nombre");
            employee.FirstName = name;

            Console.Write("Ingrese Apellido: ");
            string lastName = data.AskForString("apellido");
            employee.LastName = lastName;

            try {
                _employeeLogic.Update(employee);
                Console.WriteLine("Empleado modificado correctamente!");

            } catch (ArgumentNullException ex) {
                Console.WriteLine($"{ex.ParamName}. No se encuentra en los registros.");

            } catch (DbUpdateException) {
                Console.WriteLine("No es posible eliminar el registro, ya que atenta contra la integridad de los datos vinculados al mismo.");

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
