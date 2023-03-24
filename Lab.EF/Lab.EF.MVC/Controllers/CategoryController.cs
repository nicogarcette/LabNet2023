using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            List<CategoryViewModel> categories = categoryLogic.GetAll().Select(c => new CategoryViewModel {
                Id = c.CategoryID,
                Name = c.CategoryName
            }).ToList();

            return View(categories);
        }

        public ActionResult Eliminar(int id) {

            CategoryLogic categoryLogic = new CategoryLogic();

            try {
                categoryLogic.Delete(id);

            } catch (DbUpdateException) {

                return RedirectToAction("Index", "Error", new { message = "No podra eliminar el registro, ya que tiene registros vinculados." });
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateInsert(int id) {

            if (id == 0) {
                return View();
            }

            CategoryLogic categoryLogic = new CategoryLogic();

            try {
                Categories category = categoryLogic.GetOne(id);
                CategoryViewModel categoryModel = new CategoryViewModel {
                    Id = category.CategoryID,
                    Name = category.CategoryName
                };

                return View(categoryModel);

            } catch (Exception) {

                return RedirectToAction("Index", "Error");
            }
        }
        [HttpPost]
        public ActionResult UpdateInsert(CategoryViewModel c) {

            if (!ModelState.IsValid) {

                return View(c);
            }

            CategoryLogic categoryLogic = new CategoryLogic();
            Categories category = new Categories { CategoryID = c.Id, CategoryName = c.Name};

            try {
                if (c.Id == 0) categoryLogic.Insert(category);

                categoryLogic.Update(category);

            } catch (Exception) {

                return RedirectToAction("Index", "Error");
            }

            return RedirectToAction("Index");
        }
    }
}