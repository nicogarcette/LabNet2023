using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;
using Moq;
using System.Data.Entity;
using Lab.EF.Data;

namespace Lab.EF.Logic.Tests {

    [TestClass()]
    public class CategoryLogicTests {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteTest() {

            IABMLogic<Categories> categoryLogic = new CategoryLogic();

            categoryLogic.Delete(99);

        }

        [TestMethod()]
        public void GetAllTest() {

            IABMLogic<Categories> categoryLogic = new CategoryLogic();

            List<Categories> listCategory = categoryLogic.GetAll();


            Assert.IsTrue(listCategory.Any());

        }

        [TestMethod()]
        public void InsertTest() {

            var mockSet = new Mock<DbSet<Categories>>();
            var mockContext = new Mock<NorthwindContext>();

            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            CategoryLogic categoryLogic = new CategoryLogic(mockContext.Object);

            categoryLogic.Insert(new Categories {
                CategoryName = "Indumentaria"
            });

            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}