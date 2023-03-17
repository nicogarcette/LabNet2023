using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.LINQ.Entities;

namespace Lab.LINQ.Logic.Tests {
    [TestClass()]
    public class CustomerLogicTests {
        [TestMethod()]
        public void GetOneTest() {

            CustomerLogic customerLogic = new CustomerLogic();
            List<Customers> customers = customerLogic.GetAll();

            Customers obtenido = customerLogic.GetOne();

            Assert.AreEqual(customers[0].CustomerID, obtenido.CustomerID);

        }
    }
}