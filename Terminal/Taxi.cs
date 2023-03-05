using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal {
    public class Taxi : TransportePublico {

        public Taxi(int pasajeros) : base(pasajeros) {

        }

        public override void Avanzar() {

            Console.WriteLine($"Arranca el taxi con {pasajeros} pasajeros");
        }
        public override void Detenerse() {

            Console.WriteLine($"frena el taxi con {pasajeros} pasajeros");
        }
    }
}
