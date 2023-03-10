using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal {
    public abstract class TransportePublico {

        protected int pasajeros;

        public TransportePublico(int pasajeros) {

            this.pasajeros = pasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
