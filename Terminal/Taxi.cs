using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal {
    public class Taxi : TransportePublico {

        public Taxi(int pasajeros) : base(pasajeros) {

        }

        public override string Avanzar() {
            return $"Arranca el taxi con {pasajeros} pasajeros";
        }
        public override string Detenerse() {
            
            return $"frena el taxi con {pasajeros} pasajeros";
        }
    }
}
