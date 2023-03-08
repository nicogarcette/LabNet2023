using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2 {
    public static class DecimalExtension {
        public static decimal DivideBy(this decimal num, decimal num1) {
            decimal result;

            try {
                result = num / num1;
            } catch (DivideByZeroException ex) {
                throw ex;
            }

            return result;
        }
    }
}
