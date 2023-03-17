using Lab.LINQ.Entities;
using Lab.LINQ.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic {
    public class ProductLogic : BaseLogic {

        public IEnumerable<Products> GetAll() {

            return from prod in _context.Products
                   select prod;
        }
 
        public List<Products> NoStock() {

            List<Products> noStock = _context.Products.Where(p => p.UnitsInStock == 0).ToList();
            if (noStock.Any() == false) {
            }
            return noStock;
        }
     
        public List<Products> Stock() {

            List<Products> stock = _context.Products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3).ToList();
            return stock;
        }
        
        public Products SpecificID() {

            var product = _context.Products.Where(p => p.ProductID == 789).FirstOrDefault();
            if (product == null) throw new NoRegisterException(); 

            return product;
        }
        
        public List<Products> GetAllOrderByName() {

            return ( from p in _context.Products
                     orderby p.ProductName ascending
                     select p
                   ).ToList();
        }
  
        public List<Products> GetAllOrderByStock() {

            return (from p in _context.Products
                    orderby p.UnitsInStock descending
                    select p
                   ).ToList();
        }
   
        public List<CategoryProduct> ProductCategory() {

            var category = from c in _context.Categories
                        join o in _context.Products
                        on c.CategoryID equals o.CategoryID
                        group c by new { c.CategoryID,c.CategoryName} into cp
                        select new CategoryProduct {
                            Id = cp.Key.CategoryID,
                            CategoryName = cp.Key.CategoryName,
                            CantProduct = cp.Count(),
                        };

            return category.ToList();
        }

        public Products GetFirst() {

            var product = (from p in _context.Products
                    select p
                   ).FirstOrDefault();

            if (product == null) throw new NoRegisterException();

            return product;
        }
    }   
}
