using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Lab.EF.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeLogic employeeLogic = new EmployeeLogic();
            List<EmployeeViewModel> employees = employeeLogic.GetAll().Select(e => new EmployeeViewModel 
            {   Id =e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList();

            return View(employees);
        }

        public ActionResult Eliminar(int id) {

            EmployeeLogic employeeLogic = new EmployeeLogic();

            try {
                employeeLogic.Delete(id);

            } catch (DbUpdateException) {

                return RedirectToAction("Index", "Error", new { message = "No podra eliminar el registro, ya que tiene registros vinculados." });
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateInsert(int id) {

            if (id == 0) {
                return View();
            }

            EmployeeLogic employeeLogic = new EmployeeLogic();

            try {
                Employees employee = employeeLogic.GetOne(id);
                EmployeeViewModel employeeModel = new EmployeeViewModel 
                { 
                    Id = employee.EmployeeID, 
                    FirstName = employee.FirstName, 
                    LastName = employee.LastName
                };
                 return View(employeeModel);

            } catch (Exception) {

                return RedirectToAction("Index", "Error");
            }            
        }

        [HttpPost]
        public ActionResult UpdateInsert(EmployeeViewModel e) {

            if (!ModelState.IsValid) {
               
                return View(e);//chequea los requerimientos del modelo.
            }

            EmployeeLogic employeeLogic = new EmployeeLogic();
            Employees employee = new Employees { EmployeeID = e.Id, FirstName = e.FirstName,LastName = e.LastName };

            try {
                if (e.Id == 0)  employeeLogic.Insert(employee);

                employeeLogic.Update(employee);
            } catch (Exception ex) {

                return RedirectToAction("Index", "Error", new { message = ex.Message+ ex.InnerException+ ex.GetType() });
            }

            //Validation failed for one or more entities.
            //See 'EntityValidationErrors' property for more details.System.Data.Entity.Validation.DbEntityValidationException

            //19.22
            return RedirectToAction("Index");
        }
    }
}