using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2 {
    public class Logic {

        public void ThrowException() { 

            throw new StackOverflowException();

        }
        public void ThrowMyException() {

            throw new InvalidDataPersonException();
        }

    }
}
