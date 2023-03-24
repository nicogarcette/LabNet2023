using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Common {
    public class NoRegisterException : Exception {

        public NoRegisterException() : base("No se encontraron registros") {

        }
    }
}
