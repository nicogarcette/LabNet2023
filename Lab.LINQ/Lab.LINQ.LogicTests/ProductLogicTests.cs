using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.LINQ.Entities;
using Lab.LINQ.Data;
using System.Data.Entity;

namespace Lab.LINQ.Logic.Tests {
    [TestClass()]
    public class ProductLogicTests {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SpecificIDTest() {

            ProductLogic productLogic = new ProductLogic();

            productLogic.SpecificID();

        }
    }
}