using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal {
    public class Omnibus : TransportePublico {

        public Omnibus(int pasajeros) : base(pasajeros) {

        }
        public override void Avanzar() {

            Console.WriteLine($"Arranca el bondi con {pasajeros} pasajeros");
        }
        public override void Detenerse() {

            Console.WriteLine($"frena el bondi con {pasajeros} pasajeros");
        }
    }
}
