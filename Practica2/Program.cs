using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practica2 {
    public class Program {
        static void Main(string[] args) {

            ProgramMethods methods = new ProgramMethods();

            methods.DivideByZero();

            methods.Separate();

            methods.DivideTwoNum();

            methods.Separate();

            methods.ViewException();

            methods.Separate();

            methods.ViewCustomException();
        
            Console.ReadKey();
        }
    }
}
