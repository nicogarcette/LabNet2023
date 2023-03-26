using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Lab.EF.WebApi.Controllers
{
    public class EmployeeController : ApiController {

        private readonly EmployeeLogic employeeLogic = new EmployeeLogic();

        //GET api/employee
        public IHttpActionResult Get() {

            List<EmployeeViewModel> data = employeeLogic.GetAll().Select(e => new EmployeeViewModel {
                Id = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList();

            if (data.Count == 0) 
                return Content(HttpStatusCode.NotFound, "Sin registros");
            
            return Ok(data);
        }

        // DELETE api/employee/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id) {

            try {
                employeeLogic.Delete(id);
                return Ok("Empleado eliminado");

            } catch (Exception) {

                return BadRequest("ERROR! no es posible eliminar el registro.");
            }
        }

        // POST  api/employee
        [HttpPost]
        public IHttpActionResult Create(EmployeeViewModel e) {

            if (!ModelState.IsValid) 
                return BadRequest("Datos invalidos!");
            
            try {

                Employees employees = new Employees {
                    EmployeeID = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName
                };

                employeeLogic.Insert(employees);
                return Ok("Empleado agregado");

            } catch (Exception) {

                return BadRequest("ERROR");
            }
        }

        // PUT  api/employee
        [HttpPut]
        public IHttpActionResult Update(EmployeeViewModel e) {

            if (!ModelState.IsValid) 
                return BadRequest("Datos invalidos!");

            try {
                Employees employees = new Employees {
                    EmployeeID = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName
                };

                employeeLogic.Update(employees);
                return Ok("Empleado modificado.");

            } catch (Exception) {

               return BadRequest("ERROR");
            }
        }

    }
}
