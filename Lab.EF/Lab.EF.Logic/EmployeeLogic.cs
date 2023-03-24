using Lab.EF.Common;
using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic {
    public class EmployeeLogic : BaseLogic, IABMLogic<Employees> {

        public List<Employees> GetAll() {

            return _northwindContext.Employees.ToList();
        }

        public Employees GetOne(int id) {

            var employee = _northwindContext.Employees.FirstOrDefault(e => e.EmployeeID == id);

            if (employee == null) throw new NoRegisterException();

            return employee;
        }

        public void Insert(Employees obj) {

            try {
                _northwindContext.Employees.Add(obj);
                _northwindContext.SaveChanges();

            } catch (Exception) {

                throw;
            }
        }

        public void Delete(int id) {

            try {

                Employees employeeDelete = _northwindContext.Employees.Find(id);

                if (employeeDelete == null) throw new NoRegisterException();

                _northwindContext.Employees.Remove(employeeDelete);
                _northwindContext.SaveChanges();
              
            } catch (Exception) {

                throw;
            }
        }

        public void Update(Employees modified) {

            try {

                var employeeUpdate = _northwindContext.Employees.Find(modified.EmployeeID);
                if (employeeUpdate == null) throw new NoRegisterException();

                employeeUpdate.FirstName = modified.FirstName;
                employeeUpdate.LastName = modified.LastName;

                _northwindContext.Entry(employeeUpdate).State = EntityState.Modified;
                _northwindContext.SaveChanges();

            } catch (Exception) {

                throw;
            }
        }
    }
}
