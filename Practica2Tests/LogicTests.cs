using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Tests {
    [TestClass()]
    public class LogicTests {
        [TestMethod()]
        [ExpectedException(typeof(StackOverflowException))]
        public void ThrowExceptionTest() {

            Logic logic = new Logic();

            logic.ThrowException();

        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataPersonException))]
        public void ThrowMyExceptionTest() {

            Logic logic = new Logic();

            logic.ThrowMyException();

        }
    }
}