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
    public class CategoryLogic : BaseLogic, IABMLogic<Categories> {

        public CategoryLogic(NorthwindContext context) {

            _northwindContext = context;
        }

        public CategoryLogic() {

        }
        public List<Categories> GetAll() {

            return _northwindContext.Categories.ToList();
        }
      
        public void Insert(Categories obj) {
            try {
                _northwindContext.Categories.Add(obj);
                _northwindContext.SaveChanges();

            } catch (Exception) {

                throw;            
            }
        }

        public void Delete(int id) {
            
            try {

                var categoryDelete = _northwindContext.Categories.Find(id);

                if (categoryDelete == null) throw new ArgumentNullException("ID invalida");
           
                _northwindContext.Categories.Remove(categoryDelete);
                _northwindContext.SaveChanges();

            } catch (Exception) {

                throw;
            }
        }

        public void Update(Categories modified) {

            try {

                var categoryUpdate = _northwindContext.Categories.Find(modified.CategoryID);

                if (categoryUpdate == null) throw new ArgumentNullException("ID invalida");

                categoryUpdate.CategoryName = modified.CategoryName;

                _northwindContext.Entry(categoryUpdate).State = EntityState.Modified;
                _northwindContext.SaveChanges();

            }  catch (Exception) {

                throw;
            }
        }
    }
}
