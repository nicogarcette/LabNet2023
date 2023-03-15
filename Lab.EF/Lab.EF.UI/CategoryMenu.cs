using Lab.EF.Entities;
using Lab.EF.Logic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI {
    public class CategoryMenu : Menu {

        public override void Access() {

            string categoryOpctions = "\n--Categorias--\nOpciones \n 1-Todos los registros\n 2- Insert\n 3- Delete\n 4- Update \n 0- salir";
            bool exit = false;

            while (!exit) {

                ShowOptions(categoryOpctions);
                string opc = Console.ReadLine();

                switch (opc) {

                    case "0":
                        exit = true;
                        break;
                    case "1":
                        GetAll();
                        break;
                    case "2":
                        InsertCategory();
                        break;
                    case "3":
                        DeleteCategory();
                        break;
                    case "4":
                        UpdateCategory();
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida!");
                        break;
                }
                Console.ReadKey();
            }
        }

        public void GetAll() {

            IABMLogic<Categories> _categoryLogic = new CategoryLogic();

            Console.WriteLine("\nConsulta: Categorias\nID | NAME");
          
            foreach (var emp in _categoryLogic.GetAll()) {

                Console.WriteLine($" {emp.CategoryID} | {emp.CategoryName}");
            }
        }
       
        public void InsertCategory() {

            IABMLogic<Categories> _categoryLogic = new CategoryLogic();
            Categories category = new Categories();
            ValidData data = new ValidData();

            Console.Write("Ingrese categoria: ");
            string name = data.AskForString("Categoria");
            category.CategoryName = name;

            try {
                _categoryLogic.Insert(category);
                Console.WriteLine("Categoria agregado!");

            } catch (Exception ex) {

                Console.WriteLine($"Error:{ex.Message}");
            }
        }

        public void DeleteCategory() {

            IABMLogic<Categories> _categoryLogic = new CategoryLogic();
            ValidData data = new ValidData();

            Console.WriteLine("Ingrese ID de la categoria a eliminar");
            int id = data.AskForNumber();

            try {
                _categoryLogic.Delete(id);
                Console.WriteLine("Categoria eliminada");

            } catch (ArgumentNullException ex) {
                Console.WriteLine($"{ex.ParamName}. No se encuentra en los registros.");

            } catch (DbUpdateException) {
                Console.WriteLine("No es posible eliminar el registro, ya que atenta contra la integridad de los datos vinculados al mismo.");

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateCategory() {

            IABMLogic<Categories> _categoryLogic = new CategoryLogic();
            Categories category = new Categories();
            ValidData data = new ValidData();

            Console.WriteLine("Ingrese ID del usuario a modificar");

            int id = data.AskForNumber() ;
            category.CategoryID = id;

            Console.Write("Ingrese categoria: ");
            string name = data.AskForString("Categoria");
            category.CategoryName = name;

            try {
                _categoryLogic.Update(category);
                Console.WriteLine("Categoria modificada correctamente!");

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
