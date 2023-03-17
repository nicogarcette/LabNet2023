using Lab.LINQ.Common;
using Lab.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab.LINQ.Logic {
    public class ExerciseLogic {
        
        public string ShowOneCustomer() { 
            
            CustomerLogic customerLogic = new CustomerLogic();
            try {
                Customers customer = customerLogic.GetOne();
                return $"Id: {customer.CustomerID} Nombre: {customer.ContactName}";

            } catch (NoRegisterException ex) {

                return ex.Message;
            }
        }
    
        public string ProductsNoStock() {

            ProductLogic productLogic = new ProductLogic();

            List<Products> sinStock = productLogic.NoStock();

            string products = string.Empty;

            foreach (var item in sinStock) {

                products += $"Nombre: {item.ProductName} | stock: {item.UnitsInStock}\n";
            }

            return products;
        }
      
        public string ProductsStock() {

            ProductLogic productLogic = new ProductLogic();
            List<Products> conStock = productLogic.Stock();
            string products = string.Empty;

            foreach (var item in conStock) {

                products += $"{item.ProductID} | {item.ProductName} | {item.UnitsInStock} | {item.UnitPrice}\n";
            }

            return products;
        }
        
        public string CustomerRegionWa() {

            CustomerLogic customerLogic = new CustomerLogic();

            List<Customers> customersList = customerLogic.RegionWA();
            string customers = string.Empty;

            foreach (var item in customersList) {
                customers += $" {item.CustomerID} {item.ContactName} {item.Region}\n";
            }

            return customers;
        }

        public string ShowProduct() {
            ProductLogic productLogic = new ProductLogic();

            try {
                Products product = productLogic.SpecificID();
                return $"{product.ProductID} {product.ProductName}";

            } catch (NoRegisterException ex) {

                return ex.Message;
            }
        }
        
        public string CustomersNamesUpperLower() {

            CustomerLogic customerLogic = new CustomerLogic();
            List<string> NameList = customerLogic.CustomersName();

            string names = string.Empty;

            foreach (var name in NameList) {

                names += $"{name.ToLower()} || {name.ToUpper()}\n";
            }
        
            return names;
        }
        
        public string RegionWaAndOrderDate() {

            CustomerLogic customerLogic = new CustomerLogic();
            List<CustomerDTO> customerDTOs = customerLogic.CustomerOrder();

            string dtos = string.Empty;

            foreach (var dto in customerDTOs) {

                dtos += $"{dto.Id} {dto.Name} {dto.OrderDate} {dto.Region}\n";
            }

            return dtos;
        }
   
        public string CustomerRegionWaTake() {

            CustomerLogic customerLogic = new CustomerLogic();
            List<Customers> customersList = customerLogic.RegionWaThree();
            string customers = string.Empty;

            foreach (var c in customersList) {
                customers += $" {c.CustomerID} {c.ContactName} {c.Region}\n";
            }

            return customers;
        }

        public string ProductOrderByName() {

            ProductLogic productLogic = new ProductLogic();
            List<Products> productsList = productLogic.GetAllOrderByName();
            string products = "ID | Nombre\n";

            foreach (var p in productsList) {
                products += $"{p.ProductID} | {p.ProductName}\n";
            }

            return products;
        }

        public string ProductOrderByStock() {

            ProductLogic productLogic = new ProductLogic();
            List<Products> productsList = productLogic.GetAllOrderByStock();
            string products = string.Empty;

            foreach (var p in productsList) {
                products += $"Id: {p.ProductID} | precio: {p.UnitsInStock} | nombre: {p.ProductName} \n";
            }

            return products;
        }

        public string ShowProductCategory() {

            ProductLogic productLogic = new ProductLogic();
            List<CategoryProduct> categories = productLogic.ProductCategory();

            string names = string.Empty;

            categories.ForEach(c => { names += $"Id:{c.Id} | nombre:{c.CategoryName} | cantProd:{c.CantProduct}\n"; });

            return names; 
        }
   
        public string FirstProduct() {
            ProductLogic productLogic = new ProductLogic();

            try {
                Products product = productLogic.GetFirst();

                return $"{product.ProductID} {product.ProductName}";

            } catch (NoRegisterException ex) {
                return ex.Message;

            } catch (Exception ex) { 
                return ex.Message;
            }
        }
        
        public string ShowCantCustomerOrder() {

            CustomerLogic customerLogic = new CustomerLogic();
            List<CustomerOrder> customerDTOs = customerLogic.CantCustomerOrder();

            string customers = " ID   | CANT ORDER\n";

            foreach (var c in customerDTOs) {

                customers += $"{c.Id} | {c.CantOrder} \n";
            }

            return customers;

        }
    }
}
