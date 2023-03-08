using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2 {
    public class InvalidDataPersonException : Exception {

        public InvalidDataPersonException() :base("los datos de la persona son invalidos.")  { 
        
        }
    }
}
