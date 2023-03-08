using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Tests {
    [TestClass()]
    public class DecimalExtensionTests {
        [TestMethod()]
        public void DivideByTest() {

            decimal dividendo = 64;
            decimal divisor = 32;
            decimal esperado = 2;

            decimal  resultado = dividendo.DivideBy(divisor);

            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByTest1() {

            decimal dividendo = 64;
            decimal divisor = 0;

            decimal resultado = dividendo.DivideBy(divisor);
        }
    }
}