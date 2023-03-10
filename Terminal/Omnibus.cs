using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal {
    public class Omnibus : TransportePublico {

        public Omnibus(int pasajeros) : base(pasajeros) {

        }
        public override string Avanzar() {

            return $"Arranca el bondi con {pasajeros} pasajeros";

        }
        public override string Detenerse() {

            return $"frena el bondi con {pasajeros} pasajeros";
        }
    }
}
