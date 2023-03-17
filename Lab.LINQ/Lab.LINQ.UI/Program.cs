using Lab.LINQ.Entities;
using Lab.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.UI {
    public class Program {
        static void Main(string[] args) {

            Menu menu = new Menu();
            menu.Access();

            Console.WriteLine("...");

            Console.ReadKey();
        }
    }
}
