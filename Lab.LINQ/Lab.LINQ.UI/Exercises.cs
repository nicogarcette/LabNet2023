using Lab.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.UI {
    public class Exercises {

        private readonly ExerciseLogic _menuLogic = new ExerciseLogic();
        public void Exercise1() {

            Console.WriteLine("\n1. Devolver objeto customer");
            Console.WriteLine(_menuLogic.ShowOneCustomer());
        }
        public void Exercise2() {

            Console.WriteLine("\n2. Devolver todos los productos sin stock");
            Console.WriteLine(_menuLogic.ProductsNoStock());
        }
        public void Exercise3() {

            Console.WriteLine("\n3. Devolver todos los productos que tienen stock y que cuestan más de 3 por\r\nunidad");
            Console.WriteLine(_menuLogic.ProductsStock());
        }
        public void Exercise4() {

            Console.WriteLine("\n4. Devolver todos los customers de la Región WA");
            Console.WriteLine(_menuLogic.CustomerRegionWa());
        }
        public void Exercise5() {

            Console.WriteLine("\n5. Devolver el primer elemento o nulo de una lista de productos donde el ID de\r\nproducto sea igual a 789");
            Console.WriteLine(_menuLogic.ShowProduct());
        }
        public void Exercise6() {
            Console.WriteLine("\n6. Devolver los nombre de los Customers. Mostrarlos en Mayuscula y en\r\nMinuscula.");
            Console.WriteLine(_menuLogic.CustomersNamesUpperLower());
        }
        public void Exercise7() {

            Console.WriteLine("\n7. Devolver Join entre Customers y Orders donde los customers sean de la \r\nRegión WA y la fecha de orden sea mayor a 1/1/1997.");
            Console.WriteLine(_menuLogic.RegionWaAndOrderDate());
        }
        public void Exercise8() {

            Console.WriteLine("\n8. Devolver los primeros 3 Customers de la  Región WA");
            Console.WriteLine(_menuLogic.CustomerRegionWaTake());
        }
        public void Exercise9() {

            Console.WriteLine("\n9. Devolver lista de productos ordenados por nombre");
            Console.WriteLine(_menuLogic.ProductOrderByName());
        }
        public void Exercise10() {

            Console.WriteLine("\n10. Devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine(_menuLogic.ProductOrderByStock());
        }
        public void Exercise11() {
            Console.WriteLine("\n11. Devolver las distintas categorías asociadas a los productos");
            Console.WriteLine(_menuLogic.ShowProductCategory());
        }
        public void Exercise12() {
            Console.WriteLine("\n12. Devolver el primer elemento de una lista de productos");
            Console.WriteLine(_menuLogic.FirstProduct());
        }
        public void Exercise13() {
            Console.WriteLine("\n13.Devolver los customer con la cantidad de ordenes asociadas ");
            Console.WriteLine(_menuLogic.ShowCantCustomerOrder());
        }
    }
}
